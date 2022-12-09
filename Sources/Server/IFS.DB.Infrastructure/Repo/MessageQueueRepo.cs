using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Data;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class MessageQueueRepo : BaseRepo, IMessageQueueRepo
    {
        private readonly IDateTimeProvider _DateTimeProvider;
        private readonly IParameterService _ParameterSvc;
        private readonly IAccountApplicationRepo _AccountApplicationRepo;

        public MessageQueueRepo(DigitalBankingDBContext dbContext,
            IDateTimeProvider dateTimeProvider,
            IParameterService parameterSvc,
            IAccountApplicationRepo accountApplicationRepo)
            : base(dbContext)
        {
            _DateTimeProvider = dateTimeProvider;
            _ParameterSvc = parameterSvc;
            _AccountApplicationRepo = accountApplicationRepo;
        }

        #region Queries
        public async Task<Mqmessage> GetMessageByMessageId(int messageId)
        {
            return await DBContext.Mqmessages.FirstOrDefaultAsync(x => x.MessageId == messageId);
        }

        public async Task<IEnumerable<Mqmessage>> GetMessageByAdditional1(string additional1)
        {
            return await DBContext.Mqmessages.Where(x => x.AdditionalInfo1 == additional1).ToListAsync();
        }

        public async Task<MqmessageQueue> GetMessageQueueByMessageId(int messageId)
        {
            return await DBContext.MqmessageQueues.FirstOrDefaultAsync(x => x.MessageId == messageId);
        }

        public async Task<IEnumerable<Mqmessage>> GetMessageByStatusAndDirection(MQMessageStatusEnum status, string direction)
        {
            IEnumerable<Mqmessage> lst = await (from msg in DBContext.Mqmessages
                                                 join queue in DBContext.MqmessageQueues on msg.MessageId equals queue.MessageId
                                                 where queue.Status == (int)status && msg.Direction == direction
                                                 select msg).ToListAsync();

            return lst;
        }
        #endregion Queries

        #region Commands
        public async Task InsertAsync(Mqmessage message, string createdBy, string note)
        {
            //Create MQMessage
            await DBContext.Mqmessages.AddAsync(message);
            await DBContext.SaveChangesAsync();

            //Create MQMessageQueue
            MqmessageQueue msgQueueEntity = new MqmessageQueue()
            {
                MessageId = message.MessageId,
                Status = (int)MQMessageStatusEnum.Pending,
                RetryCount = 0
            };
            await DBContext.MqmessageQueues.AddAsync(msgQueueEntity);
            await DBContext.SaveChangesAsync();

            //Create MQUserActionLog
            MquserActionLog msgUserActionLogEntity = new MquserActionLog()
            {
                MessageId = message.MessageId,
                UserActionTypeId = (int)MQUserActionTypeEnum.Created,
                CreatedOn = _DateTimeProvider.Now(),
                CreatedBy = createdBy,
                Note = note
            };
            await DBContext.MquserActionLogs.AddAsync(msgUserActionLogEntity);
            await DBContext.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int messageId, MQMessageStatusEnum status, string note, string errorMessage)
        {
            //Get Message and Queue
            Mqmessage message = await GetMessageByMessageId(messageId);
            if (message == null)
                return;

            MqmessageQueue messageQueue = await GetMessageQueueByMessageId(messageId);
            if (messageQueue == null)
                return;

            switch (status)
            {
                case MQMessageStatusEnum.Pending:
                    {
                        //Update Message
                        message.Status = (int)MQMessageStatusEnum.Pending;

                        //Reset Message Queue
                        messageQueue.RetryCount = 0;
                        messageQueue.ErrorDesc = string.Empty;
                        messageQueue.Status = (int)MQMessageStatusEnum.Pending;
                        DBContext.MqmessageQueues.Update(messageQueue);
                        await DBContext.SaveChangesAsync();

                        break;
                    }

                case MQMessageStatusEnum.Success:
                    {
                        //If success, update status and clear queue
                        message.Status = (int)MQMessageStatusEnum.Success;

                        DBContext.MqmessageQueues.Remove(messageQueue);
                        await DBContext.SaveChangesAsync();

                        break;
                    }      

                case MQMessageStatusEnum.Failed:
                    {
                        //If fail, update Retry Count to re-processs
                        messageQueue.RetryCount = messageQueue.RetryCount ?? 0;

                        //Get Max Retry
                        byte maxRetry = await _ParameterSvc.GetHBProcessMQMaxRetryAsync();

                        if (messageQueue.RetryCount < maxRetry)
                        {
                            messageQueue.RetryCount++;
                            messageQueue.ErrorDesc = errorMessage.Replace(Environment.NewLine, "<br>");
                        }
                        else
                        {
                            message.Status = messageQueue.Status = (int)MQMessageStatusEnum.Failed;
                            messageQueue.ErrorNotified = false;

                            //Check if Registration of Tourist Card and Onboarding, Update Account Application can ReSubmit
                            if (message.MessageType == (int)MessageTypeEnum.TouristCard || message.MessageType == (int)MessageTypeEnum.OnBoarding)
                            {
                                AccountApplication accApp = await _AccountApplicationRepo.GetByIdAsync(new Guid(message.AdditionalInfo1));
                                if (accApp != null)
                                {
                                    accApp.CanResubmit = true;
                                    DBContext.AccountApplications.Update(accApp);
                                    await DBContext.SaveChangesAsync();
                                }
                            }
                        }

                        DBContext.MqmessageQueues.Update(messageQueue);
                        await DBContext.SaveChangesAsync();

                        break;
                    }

                case MQMessageStatusEnum.Hold:
                    {
                        //Update Message
                        message.Status = (int)MQMessageStatusEnum.Hold;

                        //Update Message Queue
                        messageQueue.Status = (int)MQMessageStatusEnum.Hold;
                        DBContext.MqmessageQueues.Update(messageQueue);
                        await DBContext.SaveChangesAsync();
                        break;
                    }

                default:
                    break;
            }

            //Update Message
            DBContext.Mqmessages.Update(message);
            await DBContext.SaveChangesAsync();


            MQUserActionTypeEnum actiongType = status switch
            {
                MQMessageStatusEnum.Pending => MQUserActionTypeEnum.Continue,
                MQMessageStatusEnum.Hold => MQUserActionTypeEnum.Ignore,
                _ => MQUserActionTypeEnum.Processed
            };

            //Save User Action Log
            MquserActionLog actionLog = new MquserActionLog()
            {
                UserActionTypeId = (int)actiongType,
                MessageId = message.MessageId,
                Note = note,
                CreatedOn = _DateTimeProvider.Now()
            };

            DBContext.MquserActionLogs.Update(actionLog);
            await DBContext.SaveChangesAsync();
        }
        #endregion Commands
    }
}

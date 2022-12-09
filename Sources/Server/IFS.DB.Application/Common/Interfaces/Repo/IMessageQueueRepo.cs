using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IMessageQueueRepo : IBaseRepo
    {
        #region Queries
        Task<Mqmessage> GetMessageByMessageId(int messageId);
        Task<IEnumerable<Mqmessage>> GetMessageByAdditional1(string additional1);
        Task<MqmessageQueue> GetMessageQueueByMessageId(int messageId);
        Task<IEnumerable<Mqmessage>> GetMessageByStatusAndDirection(MQMessageStatusEnum status, string direction);
        #endregion Queries

        #region Commands
        Task InsertAsync(Mqmessage message, string createdBy, string note);
        Task UpdateStatusAsync(int messageId, MQMessageStatusEnum status, string note, string errorMessage);
        #endregion Commands
    }
}

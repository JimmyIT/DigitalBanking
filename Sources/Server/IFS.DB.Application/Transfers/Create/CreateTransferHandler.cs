using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.ErrorMessage;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Constants;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Mapster;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Transfers.Create
{
    public interface ICreateTransferHandler : IBaseHandler
    {
        Task<ActionResult<CreateTransferResponse>> DoActionAsync(CreateTransferRequest transfer);
    }

    public class CreateTransferHandler : BaseHandler, ICreateTransferHandler
    {
        private readonly ICreateTransferValidator _Validator;
        private readonly IMessageQueueRepo _MessageQueueRepo;
        private readonly ITransferRepo _TransferRepo;
        private readonly IDateTimeProvider _DateTimeProvider;

        public CreateTransferHandler(IErrorMessageService errorMessageSvc, 
            IAPIHeaderValidator headerValidator,
            ICreateTransferValidator validator,
            IMessageQueueRepo messageQueueRepo,
            ITransferRepo transferRepo,
            IDateTimeProvider dateTimeProvider)
            : base(errorMessageSvc, headerValidator)
        {
            _Validator = validator;
            _MessageQueueRepo = messageQueueRepo;
            _TransferRepo = transferRepo;
            _DateTimeProvider = dateTimeProvider;
        }

        public async Task<ActionResult<CreateTransferResponse>> DoActionAsync(CreateTransferRequest transfer)
        {
            ActionResult<CreateTransferResponse> result = new ActionResult<CreateTransferResponse>()
            {
                Result = new CreateTransferResponse() { iBankReference = transfer.iBankReference }
            };

            //Validate Header
            ValidationResult valResult = _HeaderValidator.AddIdempotencyKey().Validate(Header);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Validate Content
            valResult = _Validator.Validate(transfer);
            if (!valResult.IsValid)
            {
                result.Validation = valResult;
                return result;
            }

            //Map Model to Entity
            CustomerTransfer transferEntity = transfer.Adapt<CustomerTransfer>();

            //Do some logic to test
            transferEntity.DebitAmount = transferEntity.CreditAmount;
            transferEntity.ExchangeRate = 1;
            transferEntity.Status = (int)TransactionStatusEnum.UNSIGNED;
            transferEntity.HostReference = transferEntity.IBankReference;
            transferEntity.RequiredSignatures = 1;
            transferEntity.CurrentSignatures = 1;
            transferEntity.PendingOperation = (int)OperationEnum.New;
            transferEntity.ExpiryDate = transferEntity.ValueDate.AddDays(1);
            transferEntity.AboutToExpireNotify = false;
            transferEntity.CreatedOn = _DateTimeProvider.Now();

            IDbContextTransaction transaction = _TransferRepo.DBContext.Database.BeginTransaction();

            try
            {
                //Create Transfer
                await _TransferRepo.InsertAsync(transferEntity);

                //Insert Messgae to Queue
                Mqmessage mqmessageEntity = new Mqmessage()
                {
                    MessageContent = JsonConvert.SerializeObject(transferEntity),
                    Direction = DirectionConst.Outbound,
                    MessageType = (int)MessageTypeEnum.Transfer,
                    ActionType = (int)ActionTypeEnum.Insert,
                    Reference = transferEntity.HostReference,
                    ClientNumber = transferEntity.ClientNumber,
                    AccountNumber = transferEntity.DebitAccount,
                    OriginalReference = transferEntity.IBankReference,
                    CreatedOn = _DateTimeProvider.Now()
                };

                await _MessageQueueRepo.InsertAsync(mqmessageEntity, transferEntity.CreatedBy, string.Empty);

                transaction.Commit();

                result.Result.CustomerTransferId = transferEntity.CustomerTransferId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

            return result;
        }
    }
}

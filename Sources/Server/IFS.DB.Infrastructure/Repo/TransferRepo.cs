using IFS.DB.Application.Common;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class TransferRepo : BaseRepo, ITransferRepo
    {
        private readonly IDateTimeProvider _DateTimeProvider;

        public TransferRepo(DigitalBankingDBContext dbContext,
            IDateTimeProvider dateTimeProvider)
            : base(dbContext)
        {
            _DateTimeProvider = dateTimeProvider;
        }

        #region Queries
        #endregion Queries

        #region Commands
        public async Task InsertAsync(CustomerTransfer transfer)
        {
            //Create Customer Transfer
            await DBContext.CustomerTransfers.AddAsync(transfer);
            await DBContext.SaveChangesAsync();

            //Create Transaction Journal
            TransactionJournal txnJournalEntity = new TransactionJournal()
            {
                TransactionType = (int)TransactionTypeEnum.Transfers,
                JournalItemType = (int)JournalItemTypeEnum.Created,
                AuditItemDate = _DateTimeProvider.Now(),
                ActionedBy = transfer.CreatedBy,
                CustomerTransferId = transfer.CustomerTransferId
            };
            await DBContext.TransactionJournals.AddAsync(txnJournalEntity);
            await DBContext.SaveChangesAsync();
        }
        #endregion Commands
    }
}

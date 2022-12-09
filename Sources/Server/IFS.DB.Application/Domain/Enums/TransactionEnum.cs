using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Enums
{
    public enum TransactionTypeEnum
    {
        Payments = 0,
        Transfers = 1,
        Templates = 2,
        BatchPayments = 3
    }

    public enum JournalItemTypeEnum
    {
        Created = 0,
        Signed = 1,
        Released = 2,
        Amended = 3,
        AcceptedByHost = 4,
        RejectedByHost = 5,
        CancelledByUser = 6,
        CancelledByHost = 7,
        ActionedByHost = 8,
        ProcessingAboutToExpire = 9,
        SendBankwareFailure = 10,
        RemovedByHistory = 11,
        Submitted = 12,
        Inused = 13
    }

    public enum TransactionStatusEnum
    {
        UNSIGNED = 0,
        SIGNED = 1,
        /// <summary>
        /// Item is ready sent to the host.
        /// </summary>
        RELEASED = 2,
        /// <summary>
        /// Item has been cancelled by the user and the host confirmed that the cancellation has taken place.
        /// </summary>
        CANCELLED = 3,
        /// <summary>
        /// Item is in the host and we are waiting for a response.
        /// </summary>
        PENDING = 4,
        /// <summary>
        /// Item is accepted by the host but not due yet.
        /// </summary>
        OUTSTANDING = 5,
        /// <summary>
        /// 
        /// </summary>
        PAID = 6,
        /// <summary>
        /// 
        /// </summary>
        CANCELLEDBYHOST = 7,
        /// <summary>
        /// Item is in FTTRANS waiting for transferring money but it is cancelled by the bankware.
        /// </summary>
        REJECTED = 8,
        /// <summary>
        /// Item is not paid yet but the value date has been overdue.
        /// </summary>
        EXPIRED = 9,
        /// <summary>
        /// Item was removed after number of days history.
        /// </summary>
        HISTORYREMOVED = 10
    }

    public enum OperationEnum
    {
        New = 0,
        Amend = 1,
        Cancel = 2
    };

    public enum ActionTypeEnum
    {
        Insert = 0,
        Update = 1,
        Delete = 2,
        Rebuild = 3,
        Reject = 4,
        Paid = 5,
        Verify = 6,
        Cancel = 7,
        RejectCancellation = 8
    }
}

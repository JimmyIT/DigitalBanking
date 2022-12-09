using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Domain.Enums
{
    public enum CardStatusEnum
    {
        Unknown = 0,
        Active = 1,
        Blocked = 2,
        Expired = 3,
        Lost = 4,
        Stolen = 5,
        Inactive = 6,
        Faulty = 7,
        Cancelled = 8,
        NotRequested = 9,
        WaitingAuthorization = 10,
        Refer = 11,
        WaitingActivation = 12,
        PINChangeRequired = 14,
        AccountClosed = 15,
        FrozenByCardHolder = 16,
        BlockedByCardHolder = 17,
        PINAttempts = 18,
        UnloadRequested = 19,
        KYCBlocked = 20,
        UnloadFailed = 21
    }
}

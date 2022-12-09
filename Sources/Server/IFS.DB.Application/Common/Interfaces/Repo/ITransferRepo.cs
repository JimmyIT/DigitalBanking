using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface ITransferRepo : IBaseRepo
    {
        #region Queries
        #endregion Queries

        #region Commands
        Task InsertAsync(CustomerTransfer transfer);
        #endregion Commands
    }
}

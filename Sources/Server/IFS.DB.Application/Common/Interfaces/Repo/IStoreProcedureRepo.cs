using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IStoreProcedureRepo : IBaseRepo
    {
        Task CreateDefaultPreference(string internalID, string logonID, string userID);
    }
}

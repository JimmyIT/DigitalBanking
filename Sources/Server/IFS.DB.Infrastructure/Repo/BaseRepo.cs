using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class BaseRepo : IBaseRepo
    {
        public DigitalBankingDBContext DBContext { get; set; }

        public BaseRepo(DigitalBankingDBContext dBContext)
        {
            DBContext = dBContext;
        }
    }
}

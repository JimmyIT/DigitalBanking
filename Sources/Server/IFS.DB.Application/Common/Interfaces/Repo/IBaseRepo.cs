using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IBaseRepo
    {
        public DigitalBankingDBContext DBContext { get; set; }
    }
}

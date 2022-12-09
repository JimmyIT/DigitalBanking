using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Transfers.Create
{
    public class CreateTransferResponse
    {
        public string iBankReference { get; set; }
        public int CustomerTransferId { get; set; }
    }
}

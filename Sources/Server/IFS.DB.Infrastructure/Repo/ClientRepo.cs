using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class ClientRepo : BaseRepo, IClientRepo
    {
        public ClientRepo(DigitalBankingDBContext dBContext)
            : base(dBContext)
        {

        }

        #region Queries
        public async Task<Client?> GetByClientNumberAsync(string clientNumber)
        {
            return await DBContext.Clients.FirstOrDefaultAsync(x => x.ClientNumber == clientNumber);
        }
        #endregion Queries

        #region Commands
        public async Task InsertAsync(Client client)
        {
            await DBContext.Clients.AddAsync(client);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string clientNumber)
        {
            Client entity = await DBContext.Clients.FirstOrDefaultAsync(x => x.ClientNumber == clientNumber);
            if (entity != null)
            {
                DBContext.Clients.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
        }
        #endregion Commands
    }
}

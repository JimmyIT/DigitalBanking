using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.Enums;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo
{
    public class OpenAPIRepo : BaseRepo, IOpenAPIRepo
    {
        public OpenAPIRepo(DigitalBankingDBContext dbContext)
            : base(dbContext)
        { 
        }

        #region Queries
        public async Task<OpenApiUser> GetUserByUsernameAsync(string username)
        {
            return await DBContext.OpenApiUsers.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> CheckActiveUserAsync(string username, string password)
        {
            OpenApiUser? userEntity = await DBContext.OpenApiUsers.FirstOrDefaultAsync(x => x.Username == username 
                                                                                && x.Password == password
                                                                                && x.Status == (int)OpenAPIUserStatusEnum.Active);
            return userEntity != null;
        }

        public async Task<OpenApiMessage?> GetMessageByIdAsync(int messageId)
        {
            return await DBContext.OpenApiMessages.FirstOrDefaultAsync(x => x.MessageId == messageId);
        }

        public async Task<IEnumerable<OpenApiMessage>> GetMessageByIdempotencyKeyAsync(string idempotencyKey)
        {
            return await DBContext.OpenApiMessages.Where(x => x.IdempotencyKey == idempotencyKey).ToListAsync();
        }
        #endregion Queries

        #region Commands

        public async Task InsertMessageAsync(OpenApiMessage openAPIMsg)
        {
            await DBContext.OpenApiMessages.AddAsync(openAPIMsg);
            await DBContext.SaveChangesAsync();
        }

        public async Task UpdateMessageAsync(OpenApiMessage openAPIMsg)
        {
            OpenApiMessage? openAPIMsgObj = await GetMessageByIdAsync(openAPIMsg.MessageId);
            if (openAPIMsgObj != null)
            {
                openAPIMsgObj.Status = openAPIMsg.Status;
                openAPIMsgObj.ResponseMessage = openAPIMsg.ResponseMessage;
                openAPIMsgObj.ErrorMessage = openAPIMsg.ErrorMessage;
                DBContext.OpenApiMessages.Update(openAPIMsgObj);
                await DBContext.SaveChangesAsync();
            }
        }

        #endregion Commands
    }
}

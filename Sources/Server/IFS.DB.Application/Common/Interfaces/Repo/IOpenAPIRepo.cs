using IFS.DB.Application.Domain.API;
using IFS.DB.Application.Domain.Results;
using IFS.DB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common.Interfaces.Repo
{
    public interface IOpenAPIRepo : IBaseRepo
    {
        #region Queries
        Task<OpenApiUser> GetUserByUsernameAsync(string username);
        Task<bool> CheckActiveUserAsync(string username, string password);
        Task<OpenApiMessage> GetMessageByIdAsync(int messageId);
        Task<IEnumerable<OpenApiMessage>> GetMessageByIdempotencyKeyAsync(string idempotencyKey);
        #endregion Queries

        #region Commands
        Task InsertMessageAsync(OpenApiMessage openAPIMessage);
        Task UpdateMessageAsync(OpenApiMessage openAPIMessage);

        #endregion Commands
    }
}

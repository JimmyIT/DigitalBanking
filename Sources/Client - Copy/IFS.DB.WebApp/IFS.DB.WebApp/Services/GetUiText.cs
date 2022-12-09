using IFS.DB.Resources.EF;
using Microsoft.EntityFrameworkCore;

namespace IFS.DB.WebApp.Services;

public interface IGetUiTextService
{
    Task<string?> Lookup(string langCode, string textKey, string? fallback = null);
}

public class GetUiTextService : IGetUiTextService
{
    readonly DigitalBankingDBContext _dbContext;

    public GetUiTextService(DigitalBankingDBContext dbContext)
        => _dbContext = dbContext;
    
    public async Task<string?> Lookup(string langCode, string textKey,  string? fallback = null)
    {
        UILanguageResource? languageResource = await _dbContext.UilanguageResources.AsNoTracking()
            .FirstOrDefaultAsync(x => x.LanguageCode == langCode && x.ResourceKey == textKey);
        
        return languageResource != null ? languageResource.ResourceText : fallback ?? string.Empty;
    }
}
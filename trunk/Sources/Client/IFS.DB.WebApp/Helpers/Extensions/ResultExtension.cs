using System.Net;
using FluentResults;
using Newtonsoft.Json.Linq;
using ApiError = IFS.DB.OpenAPI.Client.Errors.Error;

namespace IFS.DB.WebApp.Helpers.Extensions;

public static class ResultExtension
{
    public const string ErrorCode = "ErrorCode";
    public const string ErrorMessage = "ErrorMessage";

    public static async Task<Result<T>> AsResultAsync<T>(this Task<HttpResponseMessage> responseTask)
    {
        using HttpResponseMessage response = await responseTask.ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            T? data = response.StatusCode == HttpStatusCode.NoContent
                ? default
                : await response.Content.ReadFromJsonAsync<T>();

            return Result.Ok(data ?? default);
        }

        var jsonResponseStr = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        if (string.IsNullOrEmpty(jsonResponseStr))
        {
            return Result.Fail<T>("Response content was null unexpectedly");
        }

        var parsedJToken = Result.Try(() => JToken.Parse(jsonResponseStr));

        if (parsedJToken.IsSuccess && parsedJToken.Value is JArray jsonObjArray)
        {
            var apiErrors = jsonObjArray.ToObject<IReadOnlyCollection<ApiError>>()!;
            return Result.Fail<T>(apiErrors.Select(x => new Error(x.Message)
                .WithMetadata(ErrorCode, x.Code)
                .WithMetadata(ErrorMessage, x.Message)
            ));
        }

        if (parsedJToken.IsSuccess && parsedJToken.Value is JObject jsonObj)
        {
            var apiError = jsonObj.ToObject<ApiError>()!;
            return Result.Fail<T>(new Error(apiError.Message)
                .WithMetadata(ErrorCode, apiError.Code)
                .WithMetadata(ErrorMessage, apiError.Message)
            );
        }
        
        return Result.Fail<T>(parsedJToken.Errors);
    }
}
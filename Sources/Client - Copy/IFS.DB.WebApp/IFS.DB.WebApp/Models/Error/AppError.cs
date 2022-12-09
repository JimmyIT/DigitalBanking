using IError = FluentResults.IError;

namespace IFS.DB.WebApp.Models.Error;

public class AppError : FluentResults.Error
{
    public string Code { get; } = String.Empty;

    public AppError(string message)
        : base()
    {
        Message = message;
    }

    public AppError(string message, string code)
        : base()
    {
        Message = message;
        Code = code;
    }
    
    public AppError(string message, IError causedBy)
        : base(message)
    {
        if (causedBy == null)
            throw new ArgumentNullException(nameof(causedBy));

        Reasons.Add(causedBy);
    }
    
    public AppError(string message, AppError causedBy)
        : base(message)
    {
        if (causedBy == null)
            throw new ArgumentNullException(nameof(causedBy));

        Reasons.Add(causedBy);
    }

    
}
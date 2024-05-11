using NsiKlk1.Application.Common.Exceptions;

namespace NsiKlk1.Application.Developers.Exceptions;

public class DeveloperException : BaseException
{
    public DeveloperException(string message, object? additionalData = null) : base(message, additionalData)
    {
        
    }
}
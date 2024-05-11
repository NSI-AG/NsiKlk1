using NsiKlk1.Application.Common.Exceptions;

namespace NsiKlk1.Application.Games.Exceptions;

public class GameException : BaseException
{
    public GameException(string message, object? additionalData = null) : base(message,
        additionalData)
    {
    }
}
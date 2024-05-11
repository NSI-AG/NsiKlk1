using NsiKlk1.Application.Common.Exceptions;

namespace NsiKlk1.Infrastructure.Exceptions;

public class InfrastructureException(string message, object? additionalData = null) : BaseException(message,
    additionalData);

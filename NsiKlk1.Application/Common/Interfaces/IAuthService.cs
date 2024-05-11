using NsiKlk1.Application.Common.Dto.Auth;

namespace NsiKlk1.Application.Common.Interfaces;

public interface IAuthService
{
    Task<BeginLoginResponseDto> BeginLoginAsync(string emailAddress);
    Task<CompleteLoginResponseDto> CompleteLoginAsync(string token);
}

using Microsoft.AspNetCore.Identity;

namespace NsiKlk1.Infrastructure.Auth.Options;

public class PasswordlessLoginTokenProviderOptions : DataProtectionTokenProviderOptions
{
    public PasswordlessLoginTokenProviderOptions()
    {
        Name = "PasswordlessLoginTokenProvider";
        TokenLifespan = TimeSpan.FromMinutes(15);
    }
}

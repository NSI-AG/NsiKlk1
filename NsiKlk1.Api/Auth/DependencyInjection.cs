using NsiKlk1.Api.Auth.Constants;
using NsiKlk1.Api.Auth.Options;
using NsiKlk1.Api.Auth.Schemes;

namespace NsiKlk1.Api.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddNsiKlk1SdkAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddScheme<HeaderBasicAuthenticationSchemeOptions, HeaderBasicAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
                schemeOptions => configuration.GetSection("Auth:Header")
                    .Bind(schemeOptions));
        
        // services.AddAuthentication()
        //     .AddScheme<JwtAuthenticationSchemeOptions, JwtAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
        //         schemeOptions => configuration.GetSection("Auth:Header")
        //             .Bind(schemeOptions));

        return services;
    }
}
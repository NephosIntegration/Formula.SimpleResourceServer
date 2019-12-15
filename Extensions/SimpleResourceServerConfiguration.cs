using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Formula.SimpleResourceServer
{
    public static class SimpleResourceServerConfiguration
    {
        public static IServiceCollection AddSimpleResourceServer(this IServiceCollection services, AuthenticationBuilder authenticationBuilder, ISimpleResourceServerConfig resourceConfig = null)
        {
            if (resourceConfig == null) resourceConfig = SimpleResourceServerConfigDemo.Get();


            // If our configuration specifies details on how to 
            var jwtOptions = resourceConfig.GetJWTBearerOptions();
            if (jwtOptions != null) 
            {
                authenticationBuilder.AddJwtBearer(jwtOptions);
            }

            return services;
        }

        public static IApplicationBuilder UseSimpleResourceServer(this IApplicationBuilder app) {
            // Adds the authentication middleware to the pipeline so authentication will be performed automatically on every call into the host.
            return app.UseAuthentication();
        }
    }
}

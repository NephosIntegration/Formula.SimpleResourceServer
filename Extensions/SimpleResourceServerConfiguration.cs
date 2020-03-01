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
        public static IServiceCollection AddSimpleResourceServer(this IServiceCollection services, ISimpleResourceServerConfig resourceConfig, AuthenticationBuilder authenticationBuilder = null)
        {
            // Necessary in order to support IdentityDetails class
            services.AddHttpContextAccessor();

            // If we were given an authentication builder, use it, otherwise create one now
            if (authenticationBuilder == null)
            {
                authenticationBuilder = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            }
            
            var jwtOptions = resourceConfig.GetJWTBearerOptions();
            if (jwtOptions != null) 
            {
                authenticationBuilder.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtOptions);
            }

            return services;
        }

        public static IApplicationBuilder UseSimpleResourceServer(this IApplicationBuilder app) {
            // Adds the authentication middleware to the pipeline so authentication will be performed automatically on every call into the host.
            return app.UseAuthentication();
        }
    }
}

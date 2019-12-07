using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication;

namespace Formula.SimpleResourceServer
{
    public static class SimpleResourceServerConfiguration
    {
        public static IServiceCollection AddSimpleResourceServer(this IServiceCollection services, IConfiguration configuration, ISimpleResourceServerConfig resourceConfig)
        {
            if (resourceConfig != null) 
            {
                var jwtOptions = resourceConfig.GetJWTBearerOptions();
                if (jwtOptions != null) 
                {
                    // Adds the authentication services to DI and configures Bearer as the default scheme.                    
                    var jwtBearerBuilder = services.AddAuthentication("Bearer");
                    foreach(var options in jwtOptions)
                    {
                        jwtBearerBuilder.AddJwtBearer("Bearer", options);
                    }
                }
            }

            /*
            jwtBearerBuilder.AddJwtBearer("Bearer", options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.Audience = "api1";
            });
            */

            return services;
        }

        public static IApplicationBuilder UseSimpleResourceServer(this IApplicationBuilder app) {
            // Adds the authentication middleware to the pipeline so authentication will be performed automatically on every call into the host.
            return app.UseAuthentication();
        }
    }
}

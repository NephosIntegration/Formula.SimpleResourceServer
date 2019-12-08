using System;
using IdentityServer4.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Formula.SimpleResourceServer
{
    public class SimpleResourceServerConfigDemo : ISimpleResourceServerConfig
    {
        public virtual Action<JwtBearerOptions> GetJWTBearerOptions()
        {
            var output = new Action<JwtBearerOptions>( options => {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.Audience = "api";
            });

            return output;
        }

        public static SimpleResourceServerConfigDemo Get() 
        {
            return new SimpleResourceServerConfigDemo();
        }
    }
}
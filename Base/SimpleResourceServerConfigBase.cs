using System;
using IdentityServer4.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Formula.SimpleResourceServer
{
    public class SimpleResourceServerConfigDemo : SimpleResourceServerConfigBase
    {
        public static SimpleResourceServerConfigDemo Get() 
        {
            return new SimpleResourceServerConfigDemo();
        }
    }
    
    public abstract class SimpleResourceServerConfigBase : ISimpleResourceServerConfig
    {
        public virtual IEnumerable<Action<JwtBearerOptions>> GetJWTBearerOptions()
        {
            var output = new List<Action<JwtBearerOptions>>();

            output.Add( options => {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.Audience = "api";
            });

            return output;
        }

    }
}
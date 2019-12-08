using System;
using IdentityServer4.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Formula.SimpleResourceServer
{
    public interface ISimpleResourceServerConfig
    {
        Action<JwtBearerOptions> GetJWTBearerOptions();
    }
}
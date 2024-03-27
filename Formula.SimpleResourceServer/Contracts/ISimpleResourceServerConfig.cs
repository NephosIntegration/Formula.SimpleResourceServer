using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Formula.SimpleResourceServer
{
    public interface ISimpleResourceServerConfig
    {
        Action<JwtBearerOptions> GetJWTBearerOptions();
    }
}
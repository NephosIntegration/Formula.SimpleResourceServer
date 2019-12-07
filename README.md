# Formula.SimpleResourceServer
A simple OAuth2 / OpenID Connect Resource Server wrapper for Identity Server

# Adding Resource Server
To in enable the resource server uncomment two sections in the Startup.cs
- **ConfigureServices** - services.AddSimpleResourceServer(this.Configuration, SimpleResourceServerConfigDemo.Get());
- **Configure** - app.UseSimpleResourceServer();

# Relavant Links
- [IdentityServer4 Docs](https://identityserver4.readthedocs.io)

# Packages / Projects Used
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/)

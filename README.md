# Formula.SimpleResourceServer
A simple OAuth2 / OpenID Connect Resource Server wrapper for Identity Server

# Adding Resource Server
To in enable the resource server uncomment two sections in the Startup.cs
- **ConfigureServices** - services.AddSimpleResourceServer(this.Configuration);
- **Configure** - app.UseSimpleResourceServer();

## Defining Authentication Options
You will need to specify the authentication type options available on this resource.

This can be done by creating your own class that implements the ISimpleResourceServerConfig contract.

This can be passed as the second parameter to AddSimpleResourceServer.

For demo / testing purposes, an example JWT Bearer will be set up (see SimpleResourceServerConfigDemo for details).

# Relavant Links
- [IdentityServer4 Docs](https://identityserver4.readthedocs.io)

# Packages / Projects Used
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/)

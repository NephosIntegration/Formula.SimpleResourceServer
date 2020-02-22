# Formula.SimpleResourceServer
A simple OAuth2 / OpenID Connect Resource Server wrapper for Identity Server.

By default, Simple Resource Server validates authentication against an authority using JWT 
( [see here for more on jwt](https://jwt.io/introduction/) ) passed using using a *Bearer* token in the Authorization header of the request made from the client.

# Adding Resource Server
To enable a project to serve as a resource server against an authority you will need to prepare
configuration and inject it correctly in Startup.cs.

Add the following using;

```c#
using Formula.SimpleResourceServer;
```

## Startup.cs - ConfigureServices

Some extension methods have been provided for you register your configuration.
Within the **ConfigureServices** function of **Startup.cs** you can call **services.AddSimpleResourceServer** providing it with an implementation of **ISimpleResourceServerConfig**.  

This can be done by creating your own class that implements the ISimpleResourceServerConfig contract, manually, however a more common way to provide configuration is via a JSON configuration file within the project using the ResourceServerConfigLoader.

*(See ResourceServerConfigDefinition for configuration options)*

```c#
services.AddSimpleResourceServer(ResourceServerConfigLoader.Get("resourceServerConfig.json"));
```

You may also provide some defaults using a delegate.

```c#
services.AddSimpleResourceServer(ResourceServerConfigLoader.Get("resourceServerConfig.json", () =>
{
    var def = new ResourceServerConfigDefinition();
    def.Authority = "http://localhost:5000";
    def.RequireHttpsMetadata = false;
    def.Audience = "my-api";
    return def;
}));
```

*(See ConfigLoader in Formula.SimpleCore for details on how this functionality may be leverage for other task)*

If you handle other additional authentication mechanisms, you may pass your **AuthenticationBuilder** as a second parameter to this function, otherwise it is assumed that no other calls to **AddAuthentication** have been configured.

## Startup.cs - Configure

In the configure section of your app, you may call;

```c#
app.UseSimpleResourceServer();
```

This should be done before other calls to UseAuthorization.

# Relavant Links
- [IdentityServer4 Docs](https://identityserver4.readthedocs.io)

# Packages / Projects Used
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/)

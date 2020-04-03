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

## Obtaining Authorization / Identity Details
A service is provided, allowing you to extract certain claims about the user making the request.  This class **IdentityDetails** can provide the user id, and other details (providing you have configured your authorization server to provide these claims).  This was designed with Open ID Connect / OAuth 2  and was tested using IdentityServer 4.  Obtaining the user id available without any additional configuration, however some properties require additional claims be set up.

You can retrieve the identity details as follows.

```c#
var details = new Formula.SimpleResourceServer.IdentityDetails(httpContextAccessor);
var userId = details.UserId;

// The following properties require additional configuration on the authorization server
var email = details.Email;
var roles = details.Roles;

var isAdmin = details.HasRole("Administrator");
```

### Additional Configuration for Roles
In order to use "Role Based Authorization", the "scope" for your resource, needs to include additional claims.  At a minimum role, however it is suggested to enable the following useful claims (role, email, name).

This configuration will be mentioned from the perspective of IdentityServer 4.
For your resource (see ApiResources table), you need to set up API Claims for; role, email and name (see the ApiClaims table).


*References used for this were;*
* https://leastprivilege.com/2016/08/21/why-does-my-authorize-attribute-not-work/
* https://stackoverflow.com/questions/53976553/identityserver4-role-based-authorization-for-web-api-with-asp-net-core-identity/56641862#56641862

# Relavant Links
- [IdentityServer4 Docs](https://identityserver4.readthedocs.io)

# Packages / Projects Used
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/)

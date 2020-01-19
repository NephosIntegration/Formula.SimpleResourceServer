using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Formula.SimpleResourceServer
{
    //
    // Summary:
    //     Options class provides information needed to control Bearer Authentication handler
    //     behavior
    public class ResourceServerConfigDefinition
    {
        public ResourceServerConfigDefinition()
        {

        }

        #region Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions
        //
        // Summary:
        //     Gets or sets if HTTPS is required for the metadata address or authority. The
        //     default is true. This should be disabled only in development environments.
        public bool RequireHttpsMetadata { get; set; }
        //
        // Summary:
        //     Gets or sets the discovery endpoint for obtaining metadata
        public string MetadataAddress { get; set; }
        //
        // Summary:
        //     Gets or sets the Authority to use when making OpenIdConnect calls.
        public string Authority { get; set; }
        //
        // Summary:
        //     Gets or sets a single valid audience value for any received OpenIdConnect token.
        //     This value is passed into TokenValidationParameters.ValidAudience if that property
        //     is empty.
        public string Audience { get; set; }
        //
        // Summary:
        //     Gets or sets the challenge to put in the "WWW-Authenticate" header.
        public string Challenge { get; set; }
        //
        // Summary:
        //     The object provided by the application to process events raised by the bearer
        //     authentication handler. The application may implement the interface fully, or
        //     it may create an instance of JwtBearerEvents and assign delegates only to the
        //     events it wants to process.
        public JwtBearerEvents Events { get; set; }
        //
        // Summary:
        //     The HttpMessageHandler used to retrieve metadata. This cannot be set at the same
        //     time as BackchannelCertificateValidator unless the value is a WebRequestHandler.
        public HttpMessageHandler BackchannelHttpHandler { get; set; }
        //
        // Summary:
        //     Gets or sets the timeout when using the backchannel to make an http call.
        public TimeSpan? BackchannelTimeout { get; set; }
        //
        // Summary:
        //     Configuration provided directly by the developer. If provided, then MetadataAddress
        //     and the Backchannel properties will not be used. This information should not
        //     be updated during request processing.
        public OpenIdConnectConfiguration Configuration { get; set; }
        //
        // Summary:
        //     Responsible for retrieving, caching, and refreshing the configuration from metadata.
        //     If not provided, then one will be created using the MetadataAddress and Backchannel
        //     properties.
        public IConfigurationManager<OpenIdConnectConfiguration> ConfigurationManager { get; set; }
        //
        // Summary:
        //     Gets or sets if a metadata refresh should be attempted after a SecurityTokenSignatureKeyNotFoundException.
        //     This allows for automatic recovery in the event of a signature key rollover.
        //     This is enabled by default.
        public bool RefreshOnIssuerKeyNotFound { get; set; }
        //
        // Summary:
        //     Gets the ordered list of Microsoft.IdentityModel.Tokens.ISecurityTokenValidator
        //     used to validate access tokens.
        //public IList<ISecurityTokenValidator> SecurityTokenValidators { get; }
        //
        // Summary:
        //     Gets or sets the parameters used to validate identity tokens.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     if 'value' is null.
        //
        // Remarks:
        //     Contains the types and definitions required for validating a token.
        public TokenValidationParameters TokenValidationParameters { get; set; }
        //
        // Summary:
        //     Defines whether the bearer token should be stored in the Microsoft.AspNetCore.Authentication.AuthenticationProperties
        //     after a successful authorization.
        public bool SaveToken { get; set; }
        //
        // Summary:
        //     Defines whether the token validation errors should be returned to the caller.
        //     Enabled by default, this option can be disabled to prevent the JWT handler from
        //     returning an error and an error_description in the WWW-Authenticate header.
        public bool IncludeErrorDetails { get; set; }

        #endregion







        #region Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions
        //
        // Summary:
        //     Gets or sets the issuer that should be used for any claims that are created
        public string ClaimsIssuer { get; set; }
        //
        // Summary:
        //     If set, will be used as the service type to get the Events instance instead of
        //     the property.
        public Type EventsType { get; set; }
        //
        // Summary:
        //     If set, this specifies the target scheme that this scheme should forward AuthenticateAsync
        //     calls to. For example Context.AuthenticateAsync("ThisScheme") => Context.AuthenticateAsync("ForwardAuthenticateValue");
        //     Set the target to the current scheme to disable forwarding and allow normal processing.
        public string ForwardAuthenticate { get; set; }
        //
        // Summary:
        //     If set, this specifies the target scheme that this scheme should forward ChallengeAsync
        //     calls to. For example Context.ChallengeAsync("ThisScheme") => Context.ChallengeAsync("ForwardChallengeValue");
        //     Set the target to the current scheme to disable forwarding and allow normal processing.
        public string ForwardChallenge { get; set; }
        //
        // Summary:
        //     If set, this specifies a default scheme that authentication handlers should forward
        //     all authentication operations to by default. The default forwarding logic will
        //     check the most specific ForwardAuthenticate/Challenge/Forbid/SignIn/SignOut setting
        //     first, followed by checking the ForwardDefaultSelector, followed by ForwardDefault.
        //     The first non null result will be used as the target scheme to forward to.
        public string ForwardDefault { get; set; }
        //
        // Summary:
        //     Used to select a default scheme for the current request that authentication handlers
        //     should forward all authentication operations to by default. The default forwarding
        //     logic will check the most specific ForwardAuthenticate/Challenge/Forbid/SignIn/SignOut
        //     setting first, followed by checking the ForwardDefaultSelector, followed by ForwardDefault.
        //     The first non null result will be used as the target scheme to forward to.
        public Func<HttpContext, string> ForwardDefaultSelector { get; set; }
        //
        // Summary:
        //     If set, this specifies the target scheme that this scheme should forward ForbidAsync
        //     calls to. For example Context.ForbidAsync("ThisScheme") => Context.ForbidAsync("ForwardForbidValue");
        //     Set the target to the current scheme to disable forwarding and allow normal processing.
        public string ForwardForbid { get; set; }
        //
        // Summary:
        //     If set, this specifies the target scheme that this scheme should forward SignInAsync
        //     calls to. For example Context.SignInAsync("ThisScheme") => Context.SignInAsync("ForwardSignInValue");
        //     Set the target to the current scheme to disable forwarding and allow normal processing.
        public string ForwardSignIn { get; set; }
        //
        // Summary:
        //     If set, this specifies the target scheme that this scheme should forward SignOutAsync
        //     calls to. For example Context.SignOutAsync("ThisScheme") => Context.SignOutAsync("ForwardSignOutValue");
        //     Set the target to the current scheme to disable forwarding and allow normal processing.
        public string ForwardSignOut { get; set; }

        #endregion

    }
}
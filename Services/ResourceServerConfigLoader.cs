using System;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Formula.SimpleCore;

namespace Formula.SimpleResourceServer
{
    public class ResourceServerConfigLoader : ConfigLoader<ResourceServerConfigDefinition>,  ISimpleResourceServerConfig
    {
        public Action<JwtBearerOptions> GetJWTBearerOptions()
        {
            var output = new Action<JwtBearerOptions>(options => {
                options.Authority = this.instance.Authority;
                options.RequireHttpsMetadata = this.instance.RequireHttpsMetadata;
                options.Audience = this.instance.Audience;

                options.MetadataAddress = this.instance.MetadataAddress;
                options.Challenge = this.instance.Challenge;
                options.RefreshOnIssuerKeyNotFound = this.instance.RefreshOnIssuerKeyNotFound;
                options.SaveToken = this.instance.SaveToken;
                options.IncludeErrorDetails = this.instance.IncludeErrorDetails;
                options.ClaimsIssuer = this.instance.ClaimsIssuer;
                options.ForwardAuthenticate = this.instance.ForwardAuthenticate;
                options.ForwardChallenge = this.instance.ForwardChallenge;
                options.ForwardDefault = this.instance.ForwardDefault;
                options.ForwardForbid = this.instance.ForwardForbid;
                options.ForwardSignIn = this.instance.ForwardSignIn;
                options.ForwardSignOut = this.instance.ForwardSignOut;
                options.BackchannelHttpHandler = this.instance.BackchannelHttpHandler;
                options.Configuration = this.instance.Configuration;
                options.ConfigurationManager = this.instance.ConfigurationManager;
                options.EventsType = this.instance.EventsType;
                options.ForwardDefaultSelector = this.instance.ForwardDefaultSelector;
                options.Events = this.instance.Events;

                if (this.instance.TokenValidationParameters != null)
                {
                    options.TokenValidationParameters = this.instance.TokenValidationParameters;
                }

                if (this.instance.BackchannelTimeout != null)
                {
                    options.BackchannelTimeout = this.instance.BackchannelTimeout.Value;
                }
            });

            return output;
        }

        public static new ResourceServerConfigLoader Get(String fileName, GetDefaults getDefaults = null)
        {
            var output = new ResourceServerConfigLoader();

            output.LoadFromFile(fileName, getDefaults);

            return output;
        }
    }
}
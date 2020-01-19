using System;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Formula.SimpleResourceServer
{
    public class ResourceServerConfigLoader : ISimpleResourceServerConfig
    {
        protected ResourceServerConfigDefinition instance = null;

        public ResourceServerConfigLoader LoadFromFile(String fileName)
        {
            var json = File.ReadAllText(fileName);
            this.instance = JsonSerializer.Deserialize<ResourceServerConfigDefinition>(json);
            return this;
        }

        public ResourceServerConfigLoader SaveToFile(String fileName)
        {
            if (this.InstanceValid())
            {
                var json = JsonSerializer.Serialize(this.instance);
                var fileStream = File.Open(fileName, FileMode.Append, FileAccess.Write);
                var fileWriter = new StreamWriter(fileStream);
                fileWriter.Write(json);
                fileWriter.Flush();
                fileWriter.Close();
            }

            return this;
        }

        protected Boolean InstanceValid(Boolean throwIfNot = true)
        {
            Boolean output = false;

            if (this.instance == null)
            {
                if (throwIfNot)
                {
                    throw new Exception("Resource Server Configuration not found");
                }
            }
            else
            {
                output = true;
            }

            return output;
        }

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
    }
}
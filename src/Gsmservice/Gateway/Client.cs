//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Gsmservice.Gateway
{
    using Gsmservice.Gateway.Hooks;
    using Gsmservice.Gateway.Models.Components;
    using Gsmservice.Gateway.Models.Errors;
    using Gsmservice.Gateway.Utils.Retries;
    using Gsmservice.Gateway.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System;

    /// <summary>
    /// Messaging Gateway GSMService.pl<br/>
    /// 
    /// <remarks>
    /// <br/>
    /// This package includes Messaging SDK for C# to send SMS and MMS messages directly from your app via <a href="https://bramka.gsmservice.pl">https://bramka.gsmservice.pl</a> messaging platform.<br/>
    /// <br/>
    /// *Client* class is used to initialize SDK environment.<br/>
    /// <br/>
    /// Please initialize it this way:<br/>
    /// <br/>
    /// ```<br/>
    /// using Gsmservice.Gateway;<br/>
    /// <br/>
    /// var sdk = new Client(bearer: &quot;YOUR API ACCESS TOKEN&quot;);<br/>
    /// ```<br/>
    /// <br/>
    /// If you want to use a Sandbox test system please initialize it as follows:<br/>
    /// <br/>
    /// ```<br/>
    /// var sdk = new Client(bearer: &quot;YOUR API ACCESS TOKEN&quot;, null, SDKConfig.Server.Sandbox);<br/>
    /// ```
    /// </remarks>
    /// 
    /// <see>https://bramka.gsmservice.pl} - Bramka GSMService.pl</see>
    /// </summary>
    public interface IClient
    {
        public IAccounts Accounts { get; }
        public IOutgoing Outgoing { get; }
        public IIncoming Incoming { get; }
        public ICommon Common { get; }
        public ISenders Senders { get; }
    }

    public class SDKConfig
    {
        /// <summary>
        /// Server identifiers available to the SDK.
        /// </summary>
        public enum Server {
        Prod,
        Sandbox,
        }

        /// <summary>
        /// Server URLs available to the SDK.
        /// </summary>
        public static readonly Dictionary<Server, string> ServerMap = new Dictionary<Server, string>()
        {
            { Server.Prod, "https://api.gsmservice.pl/rest" },
            { Server.Sandbox, "https://api.gsmservice.pl/rest-sandbox" },
        };

        public string ServerUrl = "";
        public Server? ServerName = null;
        public SDKHooks Hooks = new SDKHooks();
        public RetryConfig? RetryConfig = null;

        public string GetTemplatedServerUrl()
        {
            if (!String.IsNullOrEmpty(this.ServerUrl))
            {
                return Utilities.TemplateUrl(Utilities.RemoveSuffix(this.ServerUrl, "/"), new Dictionary<string, string>());
            }
            if (this.ServerName is null)
            {
                this.ServerName = SDKConfig.Server.Prod;
            }
            else if (!SDKConfig.ServerMap.ContainsKey(this.ServerName.Value))
            {
                throw new Exception($"Invalid server \"{this.ServerName.Value}\"");
            }

            Dictionary<string, string> serverDefault = new Dictionary<string, string>();

            return Utilities.TemplateUrl(SDKConfig.ServerMap[this.ServerName.Value], serverDefault);
        }

        public ISpeakeasyHttpClient InitHooks(ISpeakeasyHttpClient client)
        {
            string preHooksUrl = GetTemplatedServerUrl();
            var (postHooksUrl, postHooksClient) = this.Hooks.SDKInit(preHooksUrl, client);
            if (preHooksUrl != postHooksUrl)
            {
                this.ServerUrl = postHooksUrl;
            }
            return postHooksClient;
        }
    }

    /// <summary>
    /// Messaging Gateway GSMService.pl<br/>
    /// 
    /// <remarks>
    /// <br/>
    /// This package includes Messaging SDK for C# to send SMS and MMS messages directly from your app via <a href="https://bramka.gsmservice.pl">https://bramka.gsmservice.pl</a> messaging platform.<br/>
    /// <br/>
    /// *Client* class is used to initialize SDK environment.<br/>
    /// <br/>
    /// Please initialize it this way:<br/>
    /// <br/>
    /// ```<br/>
    /// using Gsmservice.Gateway;<br/>
    /// <br/>
    /// var sdk = new Client(bearer: &quot;YOUR API ACCESS TOKEN&quot;);<br/>
    /// ```<br/>
    /// <br/>
    /// If you want to use a Sandbox test system please initialize it as follows:<br/>
    /// <br/>
    /// ```<br/>
    /// var sdk = new Client(bearer: &quot;YOUR API ACCESS TOKEN&quot;, null, SDKConfig.Server.Sandbox);<br/>
    /// ```
    /// </remarks>
    /// 
    /// <see>https://bramka.gsmservice.pl} - Bramka GSMService.pl</see>
    /// </summary>
    public class Client: IClient
    {
        public SDKConfig SDKConfiguration { get; private set; }

        private const string _language = "csharp";
        private const string _sdkVersion = "2.1.6";
        private const string _sdkGenVersion = "2.438.15";
        private const string _openapiDocVersion = "1.1.2";
        private const string _userAgent = "speakeasy-sdk/csharp 2.1.6 2.438.15 1.1.2 Gsmservice.Gateway";
        private string _serverUrl = "";
        private SDKConfig.Server? _server = null;
        private ISpeakeasyHttpClient _client;
        private Func<Gsmservice.Gateway.Models.Components.Security>? _securitySource;
        public IAccounts Accounts { get; private set; }
        public IOutgoing Outgoing { get; private set; }
        public IIncoming Incoming { get; private set; }
        public ICommon Common { get; private set; }
        public ISenders Senders { get; private set; }

        public Client(string? bearer = null, Func<string>? bearerSource = null, SDKConfig.Server? server = null, string? serverUrl = null, Dictionary<string, string>? urlParams = null, ISpeakeasyHttpClient? client = null, RetryConfig? retryConfig = null)
        {
            if (server != null)
            {
              _server = server;
            }

            if (serverUrl != null)
            {
                if (urlParams != null)
                {
                    serverUrl = Utilities.TemplateUrl(serverUrl, urlParams);
                }
                _serverUrl = serverUrl;
            }

            _client = client ?? new SpeakeasyHttpClient();

            if(bearerSource != null)
            {
                _securitySource = () => new Gsmservice.Gateway.Models.Components.Security() { Bearer = bearerSource() };
            }
            else if(bearer != null)
            {
                _securitySource = () => new Gsmservice.Gateway.Models.Components.Security() { Bearer = bearer };
            }

            SDKConfiguration = new SDKConfig()
            {
                ServerName = _server,
                ServerUrl = _serverUrl,
                RetryConfig = retryConfig
            };

            _client = SDKConfiguration.InitHooks(_client);


            Accounts = new Accounts(_client, _securitySource, _serverUrl, SDKConfiguration);


            Outgoing = new Outgoing(_client, _securitySource, _serverUrl, SDKConfiguration);


            Incoming = new Incoming(_client, _securitySource, _serverUrl, SDKConfiguration);


            Common = new Common(_client, _securitySource, _serverUrl, SDKConfiguration);


            Senders = new Senders(_client, _securitySource, _serverUrl, SDKConfiguration);
        }
    }
}
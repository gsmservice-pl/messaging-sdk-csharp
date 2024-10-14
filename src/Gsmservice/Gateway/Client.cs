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
    /// Messaging Gateway GSMService.pl: <br/>
    /// 
    /// <remarks>
    /// # Introduction<br/>
    /// <br/>
    /// This document was created to explain the process of integration any application or system with the **GSMService.pl** SMS Gateway via the *REST API*. Currently, there are several ways to send messages with the GSMService.pl platform:<br/>
    /// <br/>
    /// * Directly from the <a href="https://bramka.gsmservice.pl">https://bramka.gsmservice.pl</a> website <a href="https://panel.gsmservice.pl">User Panel</a><br/>
    /// * Via this *REST API* and provided *SDKs*<br/>
    /// * Via the legacy (deprecated) versions API: *Webservices (SOAP)* and *HTTP* <br/>
    /// * Via the *MAIL2SMS* service<br/>
    /// <br/>
    /// This document describes the possibilities offered by **REST API**.<br/>
    /// <br/>
    /// &gt; **We kindly ask you to read this documentation carefully before starting the integration. This will make the whole process easier and will help you avoid many problems.**<br/>
    /// <br/>
    /// ## Documentation and Try Outs<br/>
    /// <br/>
    /// This documentation is available in two formats: <a href="https://api.gsmservice.pl/rest/">**REDOC**</a> and <a href="https://api.gsmservice.pl/rest/swagger">**SWAGGER**</a>. You can test any endpoint directly from documentation using **Try Out** feature of Swagger. Also you can <a href="https://api.gsmservice.pl/rest/swagger/messaging.yaml">download a **YAML** file</a> with doc in OpenApi 3.0 format.<br/>
    /// <br/>
    /// ## Account signup and setup<br/>
    /// <br/>
    /// Firstly, it is necessary to create your personal account at the GSMService.pl SMS Gateway platform if you haven&apos;t one and activate access to the API. To register a new account please <a href="https://panel.gsmservice.pl/rejestracja">signup the form</a>. After signing up and fully activation of an account you have to activate an access to the API.<br/>
    /// <br/>
    /// To do it please use <a href="https://panel.gsmservice.pl/api">this site</a> - fill the *New API Access* form with your preferred API login, set your API password, select which API standard you want to activate for this account (select **REST API** there). Optionally you can add IP adresses (or IP pool with CIDR notation) from which access to your API account will be possible. You can also set a callback address there to collect any messages status updates automatically. When a status of a messaga changes, the callback address will be called with passing parameters with new message status.<br/>
    /// <br/>
    /// After setup an API access you will get an unique **API Access Token** - please write it down as there won&apos;t be possible to display it again (you will have the possibility to regenerate it only). This token will be required to authenticate all the requests made with API on your account.<br/>
    /// <br/>
    /// ## Authentication of API requests<br/>
    /// <br/>
    /// All the endpoints of this REST API have to be authenticated using your API Access Token with one exception: * /rest/ping* endpoint which doesn&apos;t need an authentication. <br/>
    /// <br/>
    /// To make an authenticated request you should add to all requests an ***Authorization* header** which you have generated in previous step:<br/>
    /// <br/>
    /// ```<br/>
    /// Authorization: Bearer &amp;lt;YOUR_API_ACCESS_TOKEN&amp;gt;<br/>
    /// ```<br/>
    /// <br/>
    /// ## URLs to connect to API<br/>
    /// <br/>
    /// Please use this SSL secured adresses to connect to REST API:<br/>
    /// <br/>
    /// * ```https://api.gsmservice.pl/rest``` - for production system<br/>
    /// <br/>
    /// * ```https://api.gsmservice.pl/rest-sandbox``` - for test system (Sandbox)<br/>
    /// <br/>
    /// &gt; [!NOTE]<br/>
    /// &gt; **When calling our API, make sure you are using TLS version 1.2 or higher. Older versions are no longer supported.**<br/>
    /// <br/>
    /// # SDK Client Libraries<br/>
    /// <br/>
    /// For developers integrating SMS functionality into their app, we provide a convenient SDK Libraries.<br/>
    /// <br/>
    /// Our SDKs allow you to quickly start interacting with the Gateway using your favorite programming language. Currently we support the following languages:<br/>
    /// <br/>
    /// ## PHP 8<br/>
    /// <br/>
    /// To install PHP SDK issue the following command:<br/>
    /// <br/>
    /// ```shell<br/>
    /// composer require gsmservice-pl/messaging-sdk-php<br/>
    /// ```<br/>
    /// More information and documentation you can find at our <a href="https://github.com/gsmservice-pl/messaging-sdk-php">GitHub</a> <br/>
    /// <br/>
    /// ## Typescript<br/>
    /// <br/>
    /// To install Typescript SDK issue the following command:<br/>
    /// <br/>
    /// ### NPM<br/>
    /// <br/>
    /// ```shell<br/>
    /// npm add @gsmservice-pl/messaging-sdk-typescript<br/>
    /// ```<br/>
    /// <br/>
    /// More information and documentation you can find at our <a href="https://github.com/gsmservice-pl/messaging-sdk-typescript">GitHub</a> <br/>
    /// <br/>
    /// 
    /// </remarks>
    /// </summary>
    public interface IClient
    {
        public IAccounts Accounts { get; }
        public IOutgoing Outgoing { get; }
        public IIncoming Incoming { get; }

        /// <summary>
        /// This section describes other usefull operations and tools
        /// </summary>
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
    /// Messaging Gateway GSMService.pl: <br/>
    /// 
    /// <remarks>
    /// # Introduction<br/>
    /// <br/>
    /// This document was created to explain the process of integration any application or system with the **GSMService.pl** SMS Gateway via the *REST API*. Currently, there are several ways to send messages with the GSMService.pl platform:<br/>
    /// <br/>
    /// * Directly from the <a href="https://bramka.gsmservice.pl">https://bramka.gsmservice.pl</a> website <a href="https://panel.gsmservice.pl">User Panel</a><br/>
    /// * Via this *REST API* and provided *SDKs*<br/>
    /// * Via the legacy (deprecated) versions API: *Webservices (SOAP)* and *HTTP* <br/>
    /// * Via the *MAIL2SMS* service<br/>
    /// <br/>
    /// This document describes the possibilities offered by **REST API**.<br/>
    /// <br/>
    /// &gt; **We kindly ask you to read this documentation carefully before starting the integration. This will make the whole process easier and will help you avoid many problems.**<br/>
    /// <br/>
    /// ## Documentation and Try Outs<br/>
    /// <br/>
    /// This documentation is available in two formats: <a href="https://api.gsmservice.pl/rest/">**REDOC**</a> and <a href="https://api.gsmservice.pl/rest/swagger">**SWAGGER**</a>. You can test any endpoint directly from documentation using **Try Out** feature of Swagger. Also you can <a href="https://api.gsmservice.pl/rest/swagger/messaging.yaml">download a **YAML** file</a> with doc in OpenApi 3.0 format.<br/>
    /// <br/>
    /// ## Account signup and setup<br/>
    /// <br/>
    /// Firstly, it is necessary to create your personal account at the GSMService.pl SMS Gateway platform if you haven&apos;t one and activate access to the API. To register a new account please <a href="https://panel.gsmservice.pl/rejestracja">signup the form</a>. After signing up and fully activation of an account you have to activate an access to the API.<br/>
    /// <br/>
    /// To do it please use <a href="https://panel.gsmservice.pl/api">this site</a> - fill the *New API Access* form with your preferred API login, set your API password, select which API standard you want to activate for this account (select **REST API** there). Optionally you can add IP adresses (or IP pool with CIDR notation) from which access to your API account will be possible. You can also set a callback address there to collect any messages status updates automatically. When a status of a messaga changes, the callback address will be called with passing parameters with new message status.<br/>
    /// <br/>
    /// After setup an API access you will get an unique **API Access Token** - please write it down as there won&apos;t be possible to display it again (you will have the possibility to regenerate it only). This token will be required to authenticate all the requests made with API on your account.<br/>
    /// <br/>
    /// ## Authentication of API requests<br/>
    /// <br/>
    /// All the endpoints of this REST API have to be authenticated using your API Access Token with one exception: * /rest/ping* endpoint which doesn&apos;t need an authentication. <br/>
    /// <br/>
    /// To make an authenticated request you should add to all requests an ***Authorization* header** which you have generated in previous step:<br/>
    /// <br/>
    /// ```<br/>
    /// Authorization: Bearer &amp;lt;YOUR_API_ACCESS_TOKEN&amp;gt;<br/>
    /// ```<br/>
    /// <br/>
    /// ## URLs to connect to API<br/>
    /// <br/>
    /// Please use this SSL secured adresses to connect to REST API:<br/>
    /// <br/>
    /// * ```https://api.gsmservice.pl/rest``` - for production system<br/>
    /// <br/>
    /// * ```https://api.gsmservice.pl/rest-sandbox``` - for test system (Sandbox)<br/>
    /// <br/>
    /// &gt; [!NOTE]<br/>
    /// &gt; **When calling our API, make sure you are using TLS version 1.2 or higher. Older versions are no longer supported.**<br/>
    /// <br/>
    /// # SDK Client Libraries<br/>
    /// <br/>
    /// For developers integrating SMS functionality into their app, we provide a convenient SDK Libraries.<br/>
    /// <br/>
    /// Our SDKs allow you to quickly start interacting with the Gateway using your favorite programming language. Currently we support the following languages:<br/>
    /// <br/>
    /// ## PHP 8<br/>
    /// <br/>
    /// To install PHP SDK issue the following command:<br/>
    /// <br/>
    /// ```shell<br/>
    /// composer require gsmservice-pl/messaging-sdk-php<br/>
    /// ```<br/>
    /// More information and documentation you can find at our <a href="https://github.com/gsmservice-pl/messaging-sdk-php">GitHub</a> <br/>
    /// <br/>
    /// ## Typescript<br/>
    /// <br/>
    /// To install Typescript SDK issue the following command:<br/>
    /// <br/>
    /// ### NPM<br/>
    /// <br/>
    /// ```shell<br/>
    /// npm add @gsmservice-pl/messaging-sdk-typescript<br/>
    /// ```<br/>
    /// <br/>
    /// More information and documentation you can find at our <a href="https://github.com/gsmservice-pl/messaging-sdk-typescript">GitHub</a> <br/>
    /// <br/>
    /// 
    /// </remarks>
    /// </summary>
    public class Client: IClient
    {
        public SDKConfig SDKConfiguration { get; private set; }

        private const string _language = "csharp";
        private const string _sdkVersion = "0.0.15";
        private const string _sdkGenVersion = "2.438.3";
        private const string _openapiDocVersion = "0.9.2";
        private const string _userAgent = "speakeasy-sdk/csharp 0.0.15 2.438.3 0.9.2 Gsmservice.Gateway";
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
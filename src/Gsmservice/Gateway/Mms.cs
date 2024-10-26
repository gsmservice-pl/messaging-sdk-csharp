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
    using Gsmservice.Gateway.Models.Requests;
    using Gsmservice.Gateway.Utils.Retries;
    using Gsmservice.Gateway.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System;

    public interface IMms
    {

        /// <summary>
        /// Check the price of MMS Messages
        /// 
        /// <remarks>
        /// <br/>
        /// Check the price of single or multiple MMS messages at the same time before sending them. You can pass a single `MmsMessage` object using `GetMmsPriceRequestBody.CreateMmsMessage()` method (for single message) or `List&lt;MmsMessage&gt;` using `GetMmsPriceRequestBody.CreateArrayOfMmsMessage()` method (for multiple messages). Each `MmsMessage` object has several properties, describing message parameters such as recipient phone number, content of the message, attachments, etc.<br/>
        /// The method will accept maximum **50** messages in one call.<br/>
        /// <br/>
        /// As a successful result a `GetMmsPriceResponse` object will be returned  containing a `Price` objects, one object per each single message. You should check the `Error` property of each `Price` object to make sure which messages were priced successfully and which finished with an error. Successfully priced messages will have `null` value of `Error` property.<br/>
        /// <br/>
        /// `GetSmsPriceResponse` object will include also `Headers` property with `X-Success-Count` (a count of messages which were processed successfully) and `X-Error-Count` (count of messages which were rejected) elements.
        /// </remarks>
        /// </summary>
        Task<GetMmsPriceResponse> GetPriceAsync(GetMmsPriceRequestBody request, RetryConfig? retryConfig = null);

        /// <summary>
        /// Send MMS Messages
        /// 
        /// <remarks>
        /// <br/>
        /// Send single or multiple MMS messages at the same time. You can pass a single `MmsMessage` object using `SendMmsRequestBody.CreateMmsMessage()` method (for single message) or `List&lt;MmsMessage&gt;` using `SendMmsRequestBody.CreateArrayOfMmsMessage()` method (for multiple messages). Each `SmsMessage` object has several properties, describing message parameters such recipient phone number, content of the message, attachments or scheduled sending date, etc. This method will accept maximum 50 messages in one call.<br/>
        /// <br/>
        /// As a successful result a `SendMmsResponse` object will be returned with `Messages` property of type List&lt;Message&gt; containing `Message` objects, one object per each single message. You should check the `StatusCode` property of each `Message` object to make sure which messages were accepted by gateway (queued) and which were rejected. In case of rejection, `StatusDescription` property will include a reason.<br/>
        /// <br/>
        /// `SendSmsResponse` will also include `Headers` property with `X-Success-Count` (a count of messages which were processed successfully), `X-Error-Count` (count of messages which were rejected) and `X-Sandbox` (if a request was made in Sandbox or Production system) elements.
        /// </remarks>
        /// </summary>
        Task<SendMmsResponse> SendAsync(SendMmsRequestBody request, RetryConfig? retryConfig = null);
    }

    public class Mms: IMms
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "2.1.6";
        private const string _sdkGenVersion = "2.438.15";
        private const string _openapiDocVersion = "1.1.2";
        private const string _userAgent = "speakeasy-sdk/csharp 2.1.6 2.438.15 1.1.2 Gsmservice.Gateway";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Gsmservice.Gateway.Models.Components.Security>? _securitySource;

        public Mms(ISpeakeasyHttpClient client, Func<Gsmservice.Gateway.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<GetMmsPriceResponse> GetPriceAsync(GetMmsPriceRequestBody request, RetryConfig? retryConfig = null)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/messages/mms/price";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            var serializedBody = RequestBodySerializer.Serialize(request, "Request", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("getMmsPrice", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);
            if (retryConfig == null)
            {
                if (this.SDKConfiguration.RetryConfig != null)
                {
                    retryConfig = this.SDKConfiguration.RetryConfig;
                }
                else
                {
                    var backoff = new BackoffStrategy(
                        initialIntervalMs: 500L,
                        maxIntervalMs: 60000L,
                        maxElapsedTimeMs: 3600000L,
                        exponent: 1.5
                    );
                    retryConfig = new RetryConfig(
                        strategy: RetryConfig.RetryStrategy.BACKOFF,
                        backoff: backoff,
                        retryConnectionErrors: true
                    );
                }
            }

            List<string> statusCodes = new List<string>
            {
                "5XX",
            };

            Func<Task<HttpResponseMessage>> retrySend = async () =>
            {
                var _httpRequest = await _client.CloneAsync(httpRequest);
                return await _client.SendAsync(_httpRequest);
            };
            var retries = new Gsmservice.Gateway.Utils.Retries.Retries(retrySend, retryConfig, statusCodes);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await retries.Run();
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode == 400 || _statusCode == 401 || _statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<List<Price>>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new GetMmsPriceResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.Prices = obj;
                    return response;
                }

                throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode == 400 || responseStatusCode == 401 || responseStatusCode >= 400 && responseStatusCode < 500 || responseStatusCode >= 500 && responseStatusCode < 600)
            {
                if(Utilities.IsContentTypeMatch("application/problem+json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<Models.Errors.ErrorResponse>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    throw obj!;
                }

                throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
            }

            throw new Models.Errors.SDKException("Unknown status code received", httpRequest, httpResponse);
        }

        public async Task<SendMmsResponse> SendAsync(SendMmsRequestBody request, RetryConfig? retryConfig = null)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/messages/mms";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            var serializedBody = RequestBodySerializer.Serialize(request, "Request", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("sendMms", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);
            if (retryConfig == null)
            {
                if (this.SDKConfiguration.RetryConfig != null)
                {
                    retryConfig = this.SDKConfiguration.RetryConfig;
                }
                else
                {
                    var backoff = new BackoffStrategy(
                        initialIntervalMs: 500L,
                        maxIntervalMs: 60000L,
                        maxElapsedTimeMs: 3600000L,
                        exponent: 1.5
                    );
                    retryConfig = new RetryConfig(
                        strategy: RetryConfig.RetryStrategy.BACKOFF,
                        backoff: backoff,
                        retryConnectionErrors: true
                    );
                }
            }

            List<string> statusCodes = new List<string>
            {
                "5XX",
            };

            Func<Task<HttpResponseMessage>> retrySend = async () =>
            {
                var _httpRequest = await _client.CloneAsync(httpRequest);
                return await _client.SendAsync(_httpRequest);
            };
            var retries = new Gsmservice.Gateway.Utils.Retries.Retries(retrySend, retryConfig, statusCodes);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await retries.Run();
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode == 400 || _statusCode == 401 || _statusCode == 403 || _statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<List<Message>>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new SendMmsResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.Messages = obj;
                    return response;
                }

                throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode == 400 || responseStatusCode == 401 || responseStatusCode == 403 || responseStatusCode >= 400 && responseStatusCode < 500 || responseStatusCode >= 500 && responseStatusCode < 600)
            {
                if(Utilities.IsContentTypeMatch("application/problem+json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<Models.Errors.ErrorResponse>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    throw obj!;
                }

                throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
            }

            throw new Models.Errors.SDKException("Unknown status code received", httpRequest, httpResponse);
        }
    }
}
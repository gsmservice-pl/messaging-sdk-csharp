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

    public interface ISms
    {

        /// <summary>
        /// Check the price of SMS Messages
        /// 
        /// <remarks>
        /// Check the price of single or multiple SMS messages at the same time before sending them. You have to pass as request body the `Sms` object (for single message) or `array` of `Sms` objects (for multiple messages). Each object has several properties, describing message parameters such recipient phone number, content of the message, type, etc. Please mind that some of them are required.<br/>
        /// The system will accept maximum **100** messages in one call. If you need to check the price of larger volume of messages, please split it to several separate requests.<br/>
        /// <br/>
        /// As a successful result an `array` of `Price` objects will be returned, one object per each single message. You should check the `error` property of each message in a response body to make sure which were priced successfully and which finished with an error. Successfully priced messages will have `null` value of `error` property. Response will also include meta-data headers: `X-Success-Count` (a count of messages which were processed successfully) and `X-Error-Count` (count of messages which were rejected).<br/>
        /// <br/>
        /// If you send duplicated messages in one call, API will process such message only once. This request have to be authenticated using **API Access Token**.<br/>
        /// <br/>
        /// In case of an error, the `ErrorResponse` object will be returned with proper HTTP header status code (our error response complies with <a href="https://www.rfc-editor.org/rfc/rfc7807">RFC 9457</a>).<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<GetSmsPriceResponse> GetPriceAsync(GetSmsPriceRequestBody request, RetryConfig? retryConfig = null);

        /// <summary>
        /// Send SMS Messages
        /// 
        /// <remarks>
        /// Send single or multiple SMS messages at the same time. You have to pass as request body the `Sms` object (for single message) or `array` of `Sms` objects (for multiple messages). Each object has several properties, describing message parameters such recipient phone number, content of the message, type or scheduled sending date, etc. Please mind that some of them are required.<br/>
        /// The system will accept maximum 100 messages in one call. If you need to send larger volume of messages, please split it to several separate requests.<br/>
        /// <br/>
        /// As a successful result an `array` with `Message` objects will be returned, one object per each single message. You should check the `status_code` property of each message in a response body to make sure which were accepted by gateway (queued) and which were rejected. In case of rejection, `status_description` property will include a reason. Response will also include meta-data headers: `X-Success-Count` (a count of messages which were processed successfully), `X-Error-Count` (count of messages which were rejected) and `X-Sandbox` (if a request was made in Sandbox or Production system).<br/>
        /// <br/>
        /// If you send duplicated messages in one call, API will process such message only once. This request have to be authenticated using **API Access Token**.<br/>
        /// <br/>
        /// In case of an error, the `ErrorResponse` object will be returned with proper HTTP header status code (our error response complies with <a href="https://www.rfc-editor.org/rfc/rfc7807">RFC 9457</a>).
        /// </remarks>
        /// </summary>
        Task<SendSmsResponse> SendAsync(SendSmsRequestBody request, RetryConfig? retryConfig = null);
    }

    public class Sms: ISms
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.0.15";
        private const string _sdkGenVersion = "2.438.3";
        private const string _openapiDocVersion = "0.9.2";
        private const string _userAgent = "speakeasy-sdk/csharp 0.0.15 2.438.3 0.9.2 Gsmservice.Gateway";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Gsmservice.Gateway.Models.Components.Security>? _securitySource;

        public Sms(ISpeakeasyHttpClient client, Func<Gsmservice.Gateway.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<GetSmsPriceResponse> GetPriceAsync(GetSmsPriceRequestBody request, RetryConfig? retryConfig = null)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/messages/sms/price";

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

            var hookCtx = new HookContext("getSmsPrice", null, _securitySource);

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
                    var response = new GetSmsPriceResponse()
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

        public async Task<SendSmsResponse> SendAsync(SendSmsRequestBody request, RetryConfig? retryConfig = null)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/messages/sms";

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

            var hookCtx = new HookContext("sendSms", null, _securitySource);

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
                    var response = new SendSmsResponse()
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
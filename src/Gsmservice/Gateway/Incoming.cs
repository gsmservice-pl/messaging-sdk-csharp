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

    public interface IIncoming
    {

        /// <summary>
        /// List the received SMS messages
        /// 
        /// <remarks>
        /// Get the details of all of received messages from your account incoming messages box. This endpoint supports pagination so you have to pass as query parameters a `page` value (number of page with received messages which you want to access) and a `limit` value (max of received messages per page). Messages are fetched from the latest one. The system will accept maximum **50** as `limit` parameter value. If you need to get details of larger volume of messages, please access them with next pages.<br/>
        ///     <br/>
        /// As a successful result an array with `IncomingMessage` objects will be returned, each object per single received message. Response will also include meta-data headers: `X-Total-Results` (a total count of all received messages which are available in incoming box on your account), `X-Total-Pages` (a total number of all pages with results), `X-Current-Page` (A current page number) and `X-Limit` (messages count per single page). This request have to be authenticated using **API Access Token**. <br/>
        /// <br/>
        /// A response contains also a special `Link` header which includes *URIs* to access next, previous, first and last page with received messages (which complies with <a href="https://www.rfc-editor.org/rfc/rfc5988">RFC 5988</a>).<br/>
        /// <br/>
        /// In case of an error, the `ErrorResponse` object will be returned with proper HTTP header status code (our error response complies with <a href="https://www.rfc-editor.org/rfc/rfc7807">RFC 9457</a>).
        /// </remarks>
        /// </summary>
        Task<ListIncomingMessagesResponse> ListAsync(long? page = null, long? limit = null, RetryConfig? retryConfig = null);

        /// <summary>
        /// Get the incoming messages by IDs
        /// 
        /// <remarks>
        /// Get the details of one or more received messages using their `ids`. You have to pass the unique incoming message *IDs* as path parameter, which were given while receiving a messages. If you want to get the details of multiple messages at once, please separate their IDs with a comma. The system will accept maximum 50 identifiers in one call. If you need to get details of larger volume of incoming messages, please split it to several separate requests.<br/>
        ///     <br/>
        /// As a successful result an array with `IncomingMessage` objects will be returned, each object per single found message. Response will also include meta-data headers: `X-Success-Count` (a count of incoming messages which were found and returned correctly) and `X-Error-Count` (count of incoming messages which were not found).<br/>
        /// <br/>
        /// If you pass duplicated IDs, API will return data of this message only once. This request have to be authenticated using **API Access Token**. <br/>
        /// <br/>
        /// In case of an error, the `ErrorResponse` object will be returned with proper HTTP header status code (our error response complies with <a href="https://www.rfc-editor.org/rfc/rfc7807">RFC 9457</a>).
        /// </remarks>
        /// </summary>
        Task<GetIncomingMessagesResponse> GetByIdsAsync(List<long> ids, RetryConfig? retryConfig = null);
    }

    public class Incoming: IIncoming
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.0.13";
        private const string _sdkGenVersion = "2.438.3";
        private const string _openapiDocVersion = "0.9.2";
        private const string _userAgent = "speakeasy-sdk/csharp 0.0.13 2.438.3 0.9.2 Gsmservice.Gateway";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Gsmservice.Gateway.Models.Components.Security>? _securitySource;

        public Incoming(ISpeakeasyHttpClient client, Func<Gsmservice.Gateway.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<ListIncomingMessagesResponse> ListAsync(long? page = null, long? limit = null, RetryConfig? retryConfig = null)
        {
            var request = new ListIncomingMessagesRequest()
            {
                Page = page,
                Limit = limit,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/incoming", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("listIncomingMessages", null, _securitySource);

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

                if (_statusCode == 400 || _statusCode == 401 || _statusCode == 403 || _statusCode == 404 || _statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
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
                    var obj = ResponseBodyDeserializer.Deserialize<List<IncomingMessage>>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Include);
                    var response = new ListIncomingMessagesResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.IncomingMessages = obj;
                    return response;
                }

                throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode == 400 || responseStatusCode == 401 || responseStatusCode == 403 || responseStatusCode == 404 || responseStatusCode >= 400 && responseStatusCode < 500 || responseStatusCode >= 500 && responseStatusCode < 600)
            {
                if(Utilities.IsContentTypeMatch("application/problem+json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<Models.Errors.ErrorResponse>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Include);
                    throw obj!;
                }

                throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
            }

            throw new Models.Errors.SDKException("Unknown status code received", httpRequest, httpResponse);
        }

        public async Task<GetIncomingMessagesResponse> GetByIdsAsync(List<long> ids, RetryConfig? retryConfig = null)
        {
            var request = new GetIncomingMessagesRequest()
            {
                Ids = ids,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/incoming/{ids}", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("getIncomingMessages", null, _securitySource);

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

                if (_statusCode == 400 || _statusCode == 401 || _statusCode == 404 || _statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
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
                    var obj = ResponseBodyDeserializer.Deserialize<List<IncomingMessage>>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new GetIncomingMessagesResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.IncomingMessages = obj;
                    return response;
                }

                throw new Models.Errors.SDKException("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode == 400 || responseStatusCode == 401 || responseStatusCode == 404 || responseStatusCode >= 400 && responseStatusCode < 500 || responseStatusCode >= 500 && responseStatusCode < 600)
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
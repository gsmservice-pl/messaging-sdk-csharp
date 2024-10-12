//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Gsmservice.Gateway.Hooks
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Gsmservice.Gateway.Utils;

    public class HookContext
    {
        public string OperationID { get; set; }
        public List<string>? Oauth2Scopes { get; set; }
        public Func<object>? SecuritySource { get; set; }

        public HookContext(string operationID, List<string>? oauth2Scopes, Func<object>? securitySource)
        {
            OperationID = operationID;
            Oauth2Scopes = oauth2Scopes;
            SecuritySource = securitySource;
        }
    }

    public class BeforeRequestContext : HookContext
    {
        public BeforeRequestContext(HookContext hookCtx)
            : base(hookCtx.OperationID, hookCtx.Oauth2Scopes, hookCtx.SecuritySource) { }
    }

    public class AfterSuccessContext : HookContext
    {
        public AfterSuccessContext(HookContext hookCtx)
            : base(hookCtx.OperationID, hookCtx.Oauth2Scopes, hookCtx.SecuritySource) { }
    }

    public class AfterErrorContext : HookContext
    {
        public AfterErrorContext(HookContext hookCtx)
            : base(hookCtx.OperationID, hookCtx.Oauth2Scopes, hookCtx.SecuritySource) { }
    }

    /// <summary>
    /// SDKInit hook is called when the SDK is initializing.
    /// The hook can modify and return a new baseUrl and HTTP client to be used by the SDK.
    /// </summary>
    public interface ISDKInitHook
    {
        (string, ISpeakeasyHttpClient) SDKInit(string baseUrl, ISpeakeasyHttpClient client);
    }

    /// <summary>
    /// BeforeRequestAsync hook is called before the SDK sends a request.
    /// The hook can modify the request before it is sent or throw an exception to stop the request from being sent.
    /// </summary>
    public interface IBeforeRequestHook
    {
        Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request);
    }

    /// <summary>
    /// AfterSuccessAsync is called after the SDK receives a response.
    /// The hook can modify the response before it is handled or throw an exception to stop the response from being handled.
    /// </summary>
    public interface IAfterSuccessHook
    {
        Task<HttpResponseMessage> AfterSuccessAsync(AfterSuccessContext hookCtx, HttpResponseMessage response);
    }

    /// <summary>
    /// AfterErrorAsync is called after the SDK encounters an error, or a non-successful response.
    /// The hook can modify the response, if available, otherwise modify the error.
    /// All hooks are called sequentially. If an error is returned, it will be passed to the subsequent hook implementing IAfterErrorHook.
    /// If you want to prevent other AfterError hooks from being run, you can throw an FailEarlyException instead.
    /// </summary>
    public interface IAfterErrorHook
    {
        Task<(HttpResponseMessage?, Exception?)> AfterErrorAsync(AfterErrorContext hookCtx, HttpResponseMessage? response, Exception? error);
    }

    public interface IHooks
    {
       void RegisterSDKInitHook(ISDKInitHook hook);

       void RegisterBeforeRequestHook(IBeforeRequestHook hook);

       void RegisterAfterSuccessHook(IAfterSuccessHook hook);

       void RegisterAfterErrorHook(IAfterErrorHook hook);
    }
}

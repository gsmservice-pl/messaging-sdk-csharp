//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Gsmservice.Gateway.Models.Requests
{
    using Gsmservice.Gateway.Models.Components;
    using Gsmservice.Gateway.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    
    public class ListMessagesResponse
    {

        [JsonProperty("-")]
        public HTTPMetadata HttpMeta { get; set; } = default!;

        /// <summary>
        /// The request was processed successfully. Please check messages details in each `&lt;Message&gt;` object.
        /// </summary>
        public List<Message>? Messages { get; set; }

        public Dictionary<string, List<string>> Headers { get; set; } = default!;
    }
}
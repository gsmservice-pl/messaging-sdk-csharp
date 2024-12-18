//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Gsmservice.Gateway.Models.Components
{
    using Gsmservice.Gateway.Models.Components;
    using Gsmservice.Gateway.Utils;
    using Newtonsoft.Json;
    using System;
    
    /// <summary>
    /// An object with a new MMS message properties
    /// </summary>
    public class MmsMessage
    {

        /// <summary>
        /// The recipient number or multiple recipients numbers of single message. To set one recipient, please use `Recipients.CreateStr()` method simply passing to it a `string` with his phone number. To set multiple recipients, please use `Recipients.CreateArrayOfStr()` method passing to it `List&lt;string&gt;`. Optionally you can also set custom id (user identifier) for each message - use `Recipients.CreatePhoneNumberWithCid()` method passing `PhoneNumberWithCid` object (in case of single recipient) or `Recipients.CreateArrayOfPhoneNumberWithCid()` method passing List&lt;PhoneNumberWithCid&gt; (in case of multiple recipients).
        /// </summary>
        [JsonProperty("recipients")]
        public Recipients Recipients { get; set; } = default!;

        /// <summary>
        /// MMS message subject
        /// </summary>
        [JsonProperty("subject")]
        public string? Subject { get; set; } = null;

        /// <summary>
        /// MMS message content
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Include)]
        public string? Message { get; set; }

        /// <summary>
        /// Attachments for the message. You can pass here images, audio and video files bodies. To set one attachment please use `Attachments.CreateStr()` method simply passing to it a `string` with attachment body encoded by `base64`. To set multiple attachments - please use `Attachments.CreateArrayOfStr()` method passing to it `List&lt;string&gt;` with attachment bodies encoded by `base64`. Max 3 attachments per message.
        /// </summary>
        [JsonProperty("attachments")]
        public Attachments? Attachments { get; set; }

        /// <summary>
        /// Scheduled future date and time of sending the message (in ISO 8601 format). If missing or null - message will be sent immediately
        /// </summary>
        [JsonProperty("date")]
        public DateTime? Date { get; set; } = null;
    }
}
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
    using Gsmservice.Gateway.Utils;
    using System.Collections.Generic;
    
    public class GetMessagesRequest
    {

        /// <summary>
        /// Message IDs assigned by the system (separated by comma). The system will accept a maximum of 50 identifiers in one call.
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=true,name=ids")]
        public List<long> Ids { get; set; } = default!;
    }
}
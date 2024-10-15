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
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    using System;
    

    public class GetSmsPriceRequestBodyType
    {
        private GetSmsPriceRequestBodyType(string value) { Value = value; }

        public string Value { get; private set; }
        public static GetSmsPriceRequestBodyType SmsMessage { get { return new GetSmsPriceRequestBodyType("SmsMessage"); } }
        
        public static GetSmsPriceRequestBodyType ArrayOfSmsMessage { get { return new GetSmsPriceRequestBodyType("arrayOfSmsMessage"); } }
        
        public static GetSmsPriceRequestBodyType Null { get { return new GetSmsPriceRequestBodyType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(GetSmsPriceRequestBodyType v) { return v.Value; }
        public static GetSmsPriceRequestBodyType FromString(string v) {
            switch(v) {
                case "SmsMessage": return SmsMessage;
                case "arrayOfSmsMessage": return ArrayOfSmsMessage;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for GetSmsPriceRequestBodyType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((GetSmsPriceRequestBodyType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    /// <summary>
    /// To check the price of a single message or messages with the same content to multiple recipients, pass a single `SmsMessage` object with the properties of this message using `SendSmsRequestBody.CreateSmsMessage()` method. To check the price of multiple messages with different content at the same time, pass a `List&lt;SmsMessage&gt;` with the properties of each message using `SendSmsRequestBody.CreateArrayOfSmsMessage()` method.
    /// </summary>
    [JsonConverter(typeof(GetSmsPriceRequestBody.GetSmsPriceRequestBodyConverter))]
    public class GetSmsPriceRequestBody {
        public GetSmsPriceRequestBody(GetSmsPriceRequestBodyType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public SmsMessage? SmsMessage { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public List<SmsMessage>? ArrayOfSmsMessage { get; set; }

        public GetSmsPriceRequestBodyType Type { get; set; }


        public static GetSmsPriceRequestBody CreateSmsMessage(SmsMessage smsMessage) {
            GetSmsPriceRequestBodyType typ = GetSmsPriceRequestBodyType.SmsMessage;

            GetSmsPriceRequestBody res = new GetSmsPriceRequestBody(typ);
            res.SmsMessage = smsMessage;
            return res;
        }

        public static GetSmsPriceRequestBody CreateArrayOfSmsMessage(List<SmsMessage> arrayOfSmsMessage) {
            GetSmsPriceRequestBodyType typ = GetSmsPriceRequestBodyType.ArrayOfSmsMessage;

            GetSmsPriceRequestBody res = new GetSmsPriceRequestBody(typ);
            res.ArrayOfSmsMessage = arrayOfSmsMessage;
            return res;
        }

        public static GetSmsPriceRequestBody CreateNull() {
            GetSmsPriceRequestBodyType typ = GetSmsPriceRequestBodyType.Null;
            return new GetSmsPriceRequestBody(typ);
        }

        public class GetSmsPriceRequestBodyConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(GetSmsPriceRequestBody);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            {
                var json = JRaw.Create(reader).ToString();
                if (json == "null")
                {
                    return null;
                }

                var fallbackCandidates = new List<(System.Type, object, string)>();

                try
                {
                    return new GetSmsPriceRequestBody(GetSmsPriceRequestBodyType.SmsMessage)
                    {
                        SmsMessage = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<SmsMessage>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(SmsMessage), new GetSmsPriceRequestBody(GetSmsPriceRequestBodyType.SmsMessage), "SmsMessage"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new GetSmsPriceRequestBody(GetSmsPriceRequestBodyType.ArrayOfSmsMessage)
                    {
                        ArrayOfSmsMessage = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<List<SmsMessage>>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(List<SmsMessage>), new GetSmsPriceRequestBody(GetSmsPriceRequestBodyType.ArrayOfSmsMessage), "ArrayOfSmsMessage"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                if (fallbackCandidates.Count > 0)
                {
                    fallbackCandidates.Sort((a, b) => ResponseBodyDeserializer.CompareFallbackCandidates(a.Item1, b.Item1, json));
                    foreach(var (deserializationType, returnObject, propertyName) in fallbackCandidates)
                    {
                        try
                        {
                            return ResponseBodyDeserializer.DeserializeUndiscriminatedUnionFallback(deserializationType, returnObject, propertyName, json);
                        }
                        catch (ResponseBodyDeserializer.DeserializationException)
                        {
                            // try next fallback option
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }

                throw new InvalidOperationException("Could not deserialize into any supported types.");
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value == null) {
                    writer.WriteRawValue("null");
                    return;
                }
                GetSmsPriceRequestBody res = (GetSmsPriceRequestBody)value;
                if (GetSmsPriceRequestBodyType.FromString(res.Type).Equals(GetSmsPriceRequestBodyType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.SmsMessage != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.SmsMessage));
                    return;
                }
                if (res.ArrayOfSmsMessage != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.ArrayOfSmsMessage));
                    return;
                }

            }

        }

    }
}
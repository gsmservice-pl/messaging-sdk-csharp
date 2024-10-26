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
    

    public class GetMmsPriceRequestBodyType
    {
        private GetMmsPriceRequestBodyType(string value) { Value = value; }

        public string Value { get; private set; }
        public static GetMmsPriceRequestBodyType MmsMessage { get { return new GetMmsPriceRequestBodyType("MmsMessage"); } }
        
        public static GetMmsPriceRequestBodyType ArrayOfMmsMessage { get { return new GetMmsPriceRequestBodyType("arrayOfMmsMessage"); } }
        
        public static GetMmsPriceRequestBodyType Null { get { return new GetMmsPriceRequestBodyType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(GetMmsPriceRequestBodyType v) { return v.Value; }
        public static GetMmsPriceRequestBodyType FromString(string v) {
            switch(v) {
                case "MmsMessage": return MmsMessage;
                case "arrayOfMmsMessage": return ArrayOfMmsMessage;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for GetMmsPriceRequestBodyType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((GetMmsPriceRequestBodyType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    /// <summary>
    /// To check the price of a single message or messages with the same content to multiple recipients, pass a single `MmsMessage` object with the properties of this message using `SendMmsRequestBody.CreateMmsMessage()` method. To check the price of multiple messages with different content at the same time, pass a `List&lt;MmsMessage&gt;` with the properties of each message using `SendMmsRequestBody.CreateArrayOfMmsMessage()` method.
    /// </summary>
    [JsonConverter(typeof(GetMmsPriceRequestBody.GetMmsPriceRequestBodyConverter))]
    public class GetMmsPriceRequestBody {
        public GetMmsPriceRequestBody(GetMmsPriceRequestBodyType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public MmsMessage? MmsMessage { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public List<MmsMessage>? ArrayOfMmsMessage { get; set; }

        public GetMmsPriceRequestBodyType Type { get; set; }


        public static GetMmsPriceRequestBody CreateMmsMessage(MmsMessage mmsMessage) {
            GetMmsPriceRequestBodyType typ = GetMmsPriceRequestBodyType.MmsMessage;

            GetMmsPriceRequestBody res = new GetMmsPriceRequestBody(typ);
            res.MmsMessage = mmsMessage;
            return res;
        }

        public static GetMmsPriceRequestBody CreateArrayOfMmsMessage(List<MmsMessage> arrayOfMmsMessage) {
            GetMmsPriceRequestBodyType typ = GetMmsPriceRequestBodyType.ArrayOfMmsMessage;

            GetMmsPriceRequestBody res = new GetMmsPriceRequestBody(typ);
            res.ArrayOfMmsMessage = arrayOfMmsMessage;
            return res;
        }

        public static GetMmsPriceRequestBody CreateNull() {
            GetMmsPriceRequestBodyType typ = GetMmsPriceRequestBodyType.Null;
            return new GetMmsPriceRequestBody(typ);
        }

        public class GetMmsPriceRequestBodyConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(GetMmsPriceRequestBody);

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
                    return new GetMmsPriceRequestBody(GetMmsPriceRequestBodyType.MmsMessage)
                    {
                        MmsMessage = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<MmsMessage>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(MmsMessage), new GetMmsPriceRequestBody(GetMmsPriceRequestBodyType.MmsMessage), "MmsMessage"));
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
                    return new GetMmsPriceRequestBody(GetMmsPriceRequestBodyType.ArrayOfMmsMessage)
                    {
                        ArrayOfMmsMessage = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<List<MmsMessage>>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(List<MmsMessage>), new GetMmsPriceRequestBody(GetMmsPriceRequestBodyType.ArrayOfMmsMessage), "ArrayOfMmsMessage"));
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
                GetMmsPriceRequestBody res = (GetMmsPriceRequestBody)value;
                if (GetMmsPriceRequestBodyType.FromString(res.Type).Equals(GetMmsPriceRequestBodyType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.MmsMessage != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.MmsMessage));
                    return;
                }
                if (res.ArrayOfMmsMessage != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.ArrayOfMmsMessage));
                    return;
                }

            }

        }

    }
}
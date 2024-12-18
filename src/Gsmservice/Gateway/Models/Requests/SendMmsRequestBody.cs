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
    

    public class SendMmsRequestBodyType
    {
        private SendMmsRequestBodyType(string value) { Value = value; }

        public string Value { get; private set; }
        public static SendMmsRequestBodyType MmsMessage { get { return new SendMmsRequestBodyType("MmsMessage"); } }
        
        public static SendMmsRequestBodyType ArrayOfMmsMessage { get { return new SendMmsRequestBodyType("arrayOfMmsMessage"); } }
        
        public static SendMmsRequestBodyType Null { get { return new SendMmsRequestBodyType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(SendMmsRequestBodyType v) { return v.Value; }
        public static SendMmsRequestBodyType FromString(string v) {
            switch(v) {
                case "MmsMessage": return MmsMessage;
                case "arrayOfMmsMessage": return ArrayOfMmsMessage;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for SendMmsRequestBodyType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((SendMmsRequestBodyType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    /// <summary>
    /// To send a single MMS or messages with the same content to multiple recipients, please use `SendMmsRequestBody.CreateMmsMessage()` method with a single `MmsMessage` object with the properties of this message. To send multiple messages with different content at the same time, please use `SendMmsRequestBody.CreateArrayOfMmsMessage()` method passing to it `List&lt;MmsMessage&gt;`  with the properties of each message.
    /// </summary>
    [JsonConverter(typeof(SendMmsRequestBody.SendMmsRequestBodyConverter))]
    public class SendMmsRequestBody {
        public SendMmsRequestBody(SendMmsRequestBodyType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public MmsMessage? MmsMessage { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public List<MmsMessage>? ArrayOfMmsMessage { get; set; }

        public SendMmsRequestBodyType Type { get; set; }


        public static SendMmsRequestBody CreateMmsMessage(MmsMessage mmsMessage) {
            SendMmsRequestBodyType typ = SendMmsRequestBodyType.MmsMessage;

            SendMmsRequestBody res = new SendMmsRequestBody(typ);
            res.MmsMessage = mmsMessage;
            return res;
        }

        public static SendMmsRequestBody CreateArrayOfMmsMessage(List<MmsMessage> arrayOfMmsMessage) {
            SendMmsRequestBodyType typ = SendMmsRequestBodyType.ArrayOfMmsMessage;

            SendMmsRequestBody res = new SendMmsRequestBody(typ);
            res.ArrayOfMmsMessage = arrayOfMmsMessage;
            return res;
        }

        public static SendMmsRequestBody CreateNull() {
            SendMmsRequestBodyType typ = SendMmsRequestBodyType.Null;
            return new SendMmsRequestBody(typ);
        }

        public class SendMmsRequestBodyConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(SendMmsRequestBody);

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
                    return new SendMmsRequestBody(SendMmsRequestBodyType.MmsMessage)
                    {
                        MmsMessage = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<MmsMessage>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(MmsMessage), new SendMmsRequestBody(SendMmsRequestBodyType.MmsMessage), "MmsMessage"));
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
                    return new SendMmsRequestBody(SendMmsRequestBodyType.ArrayOfMmsMessage)
                    {
                        ArrayOfMmsMessage = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<List<MmsMessage>>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(List<MmsMessage>), new SendMmsRequestBody(SendMmsRequestBodyType.ArrayOfMmsMessage), "ArrayOfMmsMessage"));
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
                SendMmsRequestBody res = (SendMmsRequestBody)value;
                if (SendMmsRequestBodyType.FromString(res.Type).Equals(SendMmsRequestBodyType.Null))
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
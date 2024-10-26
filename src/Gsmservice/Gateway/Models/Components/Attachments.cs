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
    using Gsmservice.Gateway.Utils;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    using System;
    

    public class AttachmentsType
    {
        private AttachmentsType(string value) { Value = value; }

        public string Value { get; private set; }
        public static AttachmentsType Str { get { return new AttachmentsType("str"); } }
        
        public static AttachmentsType ArrayOfStr { get { return new AttachmentsType("arrayOfStr"); } }
        
        public static AttachmentsType Null { get { return new AttachmentsType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(AttachmentsType v) { return v.Value; }
        public static AttachmentsType FromString(string v) {
            switch(v) {
                case "str": return Str;
                case "arrayOfStr": return ArrayOfStr;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for AttachmentsType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((AttachmentsType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    /// <summary>
    /// Attachments for the message. You can pass here images, audio and video files bodies. To set one attachment please use `Attachments.CreateStr()` method simply passing to it a `string` with attachment body encoded by `base64`. To set multiple attachments - please use `Attachments.CreateArrayOfStr()` method passing to it `List&lt;string&gt;` with attachment bodies encoded by `base64`. Max 3 attachments per message.
    /// </summary>
    [JsonConverter(typeof(Attachments.AttachmentsConverter))]
    public class Attachments {
        public Attachments(AttachmentsType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public string? Str { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public List<string>? ArrayOfStr { get; set; }

        public AttachmentsType Type { get; set; }


        public static Attachments CreateStr(string str) {
            AttachmentsType typ = AttachmentsType.Str;

            Attachments res = new Attachments(typ);
            res.Str = str;
            return res;
        }

        public static Attachments CreateArrayOfStr(List<string> arrayOfStr) {
            AttachmentsType typ = AttachmentsType.ArrayOfStr;

            Attachments res = new Attachments(typ);
            res.ArrayOfStr = arrayOfStr;
            return res;
        }

        public static Attachments CreateNull() {
            AttachmentsType typ = AttachmentsType.Null;
            return new Attachments(typ);
        }

        public class AttachmentsConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(Attachments);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            {
                var json = JRaw.Create(reader).ToString();
                if (json == "null")
                {
                    return null;
                }

                var fallbackCandidates = new List<(System.Type, object, string)>();

                if (json[0] == '"' && json[^1] == '"'){
                    return new Attachments(AttachmentsType.Str)
                    {
                        Str = json[1..^1]
                    };
                }

                try
                {
                    return new Attachments(AttachmentsType.ArrayOfStr)
                    {
                        ArrayOfStr = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<List<string>>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(List<string>), new Attachments(AttachmentsType.ArrayOfStr), "ArrayOfStr"));
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
                Attachments res = (Attachments)value;
                if (AttachmentsType.FromString(res.Type).Equals(AttachmentsType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.Str != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.Str, "byte"));
                    return;
                }
                if (res.ArrayOfStr != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.ArrayOfStr));
                    return;
                }

            }

        }

    }
}
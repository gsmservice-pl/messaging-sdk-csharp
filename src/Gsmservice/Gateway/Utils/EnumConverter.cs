//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
using System;
using Newtonsoft.Json;

namespace Gsmservice.Gateway.Utils
{
    internal class EnumConverter : JsonConverter
    {
        public override bool CanConvert(System.Type objectType)
        {
            var  nullableType = Nullable.GetUnderlyingType(objectType);
            if (nullableType != null)
            {
                return nullableType.IsEnum;
            }

            return objectType.IsEnum;
        }

        public override object? ReadJson(
            JsonReader reader,
            System.Type objectType,
            object? existingValue,
            JsonSerializer serializer
        )
        {
            if (reader.Value == null)
            {
                return null;
            }

            var extensionType = System.Type.GetType(objectType.FullName + "Extension");

            if (Nullable.GetUnderlyingType(objectType) != null) {
                objectType = Nullable.GetUnderlyingType(objectType)!;
                extensionType = System.Type.GetType(objectType!.FullName + "Extension");
            }

            if (extensionType == null)
            {
                return Enum.ToObject(objectType, reader.Value);
            }

            var method = extensionType.GetMethod("ToEnum");
            if (method == null)
            {
                throw new Exception($"Unable to find ToEnum method on {extensionType.FullName}");
            }

            try {
                return method.Invoke(null, new[] { (string)reader.Value });
            } catch(System.Reflection.TargetInvocationException e) {
                throw new Newtonsoft.Json.JsonSerializationException("Unable to convert value to enum", e);
            }

        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteValue("null");
                return;
            }

            var extensionType = System.Type.GetType(value.GetType().FullName + "Extension");
            if (extensionType == null)
            {
                writer.WriteValue(value);
                return;
            }

            writer.WriteValue(Utilities.ToString(value));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MyLog.Core.Models.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyLog.Core.Converters
{
    internal class CoordinatesJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var coordinatesString = value.ToString();
            writer.WriteValue(coordinatesString);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var coordinatesString = reader.Value?.ToString();

            if (!string.IsNullOrWhiteSpace(coordinatesString))
            {
                return Coordinates.Parse(coordinatesString);
            }
            else
            {
                return null;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Coordinates);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace TextJsonLib
{
    /// <summary>
    /// 各种Converters
    /// </summary>
    public class JsonConverters
    {
        public class JsonDateTimeConverter:System.Text.Json.Serialization.JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (!DateTime.TryParse(reader.GetString(), out var retTime))
                {
                    return new DateTime(1900,1,1);
                }
                return retTime;
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        public class JsonDateTimeNullConverter : System.Text.Json.Serialization.JsonConverter<DateTime?>
        {
            public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (!DateTime.TryParse(reader.GetString(), out var retTime))
                {
                    return null;
                }
                return retTime;
            }

            public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value?.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }



        public class JsonSpecialDateTimeConverter:System.Text.Json.Serialization.JsonConverter<DateTime>
        {
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (!DateTime.TryParseExact(reader.GetString(),"yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var retTime))
                {
                    return new DateTime(1900, 1, 1);
                }
                return retTime;
            }

            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("yyyyMMdd"));
            }
        }
    }
}

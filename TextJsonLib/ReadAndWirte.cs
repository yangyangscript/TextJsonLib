using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace TextJsonLib
{
    /// <summary>
    /// 读写配置文件
    /// </summary>
    public static class ReadAndWirte
    {

        public static void Wirte<T>(string jsonPath,T value) where T:new()
        {
            var tTypt = typeof(T);
            using (System.IO.StreamWriter writer = new StreamWriter(jsonPath))
            {
                var encoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
                var writerOption = new System.Text.Json.JsonWriterOptions()
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(encoderSettings),
                    Indented = true
                };
                using (System.Text.Json.Utf8JsonWriter jsonWriter = new Utf8JsonWriter(writer.BaseStream, writerOption))
                {
                    jsonWriter.WriteStartObject();
                    foreach (var propertyInfo in tTypt.GetProperties())
                    {
                        var propertyValue = propertyInfo.GetValue(value);
                        switch (propertyInfo.PropertyType.Name)
                        {
                            case "Int32":
                                jsonWriter.WriteNumber(propertyInfo.Name,Convert.ToInt32(propertyValue));
                                break;
                            case "Decimal":
                                jsonWriter.WriteNumber(propertyInfo.Name, Convert.ToDecimal(propertyValue));
                                break;
                            case "DateTime":
                                jsonWriter.WriteString(propertyInfo.Name, Convert.ToDateTime(propertyValue).ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case "String":
                                jsonWriter.WriteString(propertyInfo.Name, propertyValue.ToString());
                                break;
                            //后续扩展
                            default:
                                continue;
                        }
                    }
                    jsonWriter.WriteEndObject();
                }
                writer.Close();
            }
        }


        public static T Read<T>(string jsonPath) where T : new()
        {
            var tTypt = typeof(T);
            var properties = tTypt.GetProperties();
            var ret =new T();
            using (System.IO.StreamReader reader = new StreamReader(jsonPath))
            {
                var baseSteam = reader.BaseStream;
                var lenth = (int)baseSteam.Length;
                byte[] buffer = new byte[lenth];
                baseSteam.Read(buffer, 0, lenth);
                ReadOnlySpan<byte> jsonSpan = buffer;
                var readerOption = new System.Text.Json.JsonReaderOptions()
                {
                    AllowTrailingCommas = true,
                    CommentHandling = JsonCommentHandling.Skip
                };
                System.Text.Json.Utf8JsonReader jsonReader = new Utf8JsonReader(jsonSpan,readerOption);
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonTokenType.PropertyName)
                    {
                        var propertyName = jsonReader.GetString();
                        var property = properties.FirstOrDefault(s => s.Name == propertyName);
                        if (property != null)
                        {
                            jsonReader.Read();
                            switch (property.PropertyType.Name)
                            {
                                case "Int32":
                                    property.SetValue(ret, jsonReader.GetInt32());
                                    break;
                                case "Decimal":
                                    property.SetValue(ret, jsonReader.GetDecimal());
                                    break;
                                case "DateTime":
                                    var timeStr = jsonReader.GetString();
                                    property.SetValue(ret, DateTime.Parse(timeStr));
                                    break;
                                case "String":
                                    property.SetValue(ret, jsonReader.GetString());
                                    break;
                                //后续扩展
                                default:
                                    continue;
                            }
                        }
                    }
                }
                reader.Close();
            }
            return ret;
        } 
    }
}

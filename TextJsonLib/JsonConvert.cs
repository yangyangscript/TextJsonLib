using System;
using System.Collections.Generic;
using System.Text;

namespace TextJsonLib
{
    /// <summary>
    /// Newtonsoft.Json一样的JsonConvert
    /// </summary>
    public static class JsonConvert
    {
        public static string SerializeObject(object value, System.Text.Json.JsonSerializerOptions option=null)
        {
            if (option == null) option = Options.DefaultOption;
            return System.Text.Json.JsonSerializer.Serialize(value, option);
        }


        public static T DeserializeObject<T>(string value, System.Text.Json.JsonSerializerOptions option = null)
        {
            if (option == null) option = Options.DefaultOption;
            return System.Text.Json.JsonSerializer.Deserialize<T>(value, option);
        }
    }
}

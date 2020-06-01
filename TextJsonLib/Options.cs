using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Unicode;

namespace TextJsonLib
{
    /// <summary>
    /// Option设置
    /// </summary>
    public static class Options
    {
        #region 一个默认静态的用于复用
        private static System.Text.Json.JsonSerializerOptions _defaultOption;

        public static System.Text.Json.JsonSerializerOptions DefaultOption
        {
            get
            {
                if (_defaultOption == null)
                {
                    _defaultOption = GetDefaultOption();
                }
                return _defaultOption;
            }
        }
        #endregion


        /// <summary>
        /// 创建一个默认的Option，包含中文和日期转化
        /// </summary>
        /// <returns></returns>
        public static System.Text.Json.JsonSerializerOptions GetDefaultOption()
        {
            //编码
            var encoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
            var retOption = new System.Text.Json.JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(encoderSettings),
            };
            //日期转换
            retOption.Converters.Add(new JsonConverters.JsonDateTimeConverter());
            retOption.Converters.Add(new JsonConverters.JsonDateTimeNullConverter());
            return retOption;
        }


        /// <summary>
        /// 忽略大小写和可读输出Option
        /// </summary>
        /// <returns></returns>
        public static System.Text.Json.JsonSerializerOptions GetCaseIndentedOption()
        {
            var dOption = GetDefaultOption();
            dOption.WriteIndented = true;
            dOption.PropertyNameCaseInsensitive =true;
            return dOption;
        }
    }
}

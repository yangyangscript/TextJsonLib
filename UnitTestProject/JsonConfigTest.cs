using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextJsonLib;

namespace UnitTestProject
{
    [TestClass]
    public class JsonConfigTest
    {

        private static string jsonPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "jsonconfig.json");

        [TestMethod("写配置文件")]
        public void TestWrite()
        {
            var newConfig = new Model.ConfigTest()
            {
                Id = 243,
                DelValue = 123.321m,
                Name1 = "asdasdaqwtdfgdf",
                Name2 = "中文中文中文中文中文中文中文中文"
            };
            TextJsonLib.ReadAndWirte.Wirte(jsonPath,newConfig);
        }


        [TestMethod("读配置文件")]
        public void TestRead()
        {
            var ret = TextJsonLib.ReadAndWirte.Read<Model.ConfigTest>(jsonPath);

            Console.WriteLine(TextJsonLib.JsonConvert.SerializeObject(ret));
        }
    }
}

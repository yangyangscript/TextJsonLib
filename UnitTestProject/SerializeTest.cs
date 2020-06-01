using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class SerializeTest
    {
        [TestMethod("–Ú¡–ªØ≤‚ ‘")]
        public void TestMethod1()
        {
            var items = new List<Model.TestClass>();
            for (int i = 1; i <= 100; i++)
            {
                Model.TestClass newI = i;
                items.Add(i);
            }
            var option = TextJsonLib.Options.GetCaseIndentedOption();
            var jsonStr = TextJsonLib.JsonConvert.SerializeObject(items, option);
            var desItems = TextJsonLib.JsonConvert.DeserializeObject<List<Model.TestClass>>(jsonStr);

            Console.WriteLine(desItems.Count);
            Console.WriteLine(jsonStr);
        }
    }
}

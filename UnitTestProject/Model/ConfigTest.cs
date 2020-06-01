using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Model
{
    public class ConfigTest
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }=DateTime.Now;

        public decimal DelValue { get; set; }

        public string Name1 { get; set; }

        public string Name2 { get; set; }
    }
}

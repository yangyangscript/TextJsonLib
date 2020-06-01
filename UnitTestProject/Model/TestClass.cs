using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.Model
{
    public class TestClass
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Time { get; set; }

        public DateTime? NTime { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(TextJsonLib.JsonConverters.JsonSpecialDateTimeConverter))]
        public DateTime SpecialTime { get; set; }


        public static implicit operator TestClass(int r)
        {
            var defaulT = DateTime.Today;
            DateTime? nullTime = null;
            return new TestClass()
            {
                Id = r,
                Name = $"Name{r}",
                Time = defaulT.AddSeconds(r),
                NTime = r % 2 == 0 ? defaulT : nullTime,
                SpecialTime = defaulT
            };
        }
    }
}

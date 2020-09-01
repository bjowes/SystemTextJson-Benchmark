using System;
using System.Collections.Generic;

namespace JsonTest
{
    public class MyObject
    {
        public string MyString { get; set; }
        public int MyInt { get; set; }
        public DateTime MyDateTime { get; set; }
        public double MyDouble { get; set; }

        public MySubObject MySubObject { get; set; }
        public List<MySubObject> MySubObjects { get; set; }
    }
}

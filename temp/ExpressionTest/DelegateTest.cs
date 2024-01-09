using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTest
{
    [TestClass]
    public class DelegateTest
    {
        delegate void DelegMethod(string s);
        static void Method1 (string s)
        {
            Debug.WriteLine ($"Hallo {s}");
        }
        static void Method2(string s)
        {
            Debug.WriteLine($"Bye {s}");
        }
        [TestMethod]
        public void Delegasi() 
        {
            DelegMethod met1, met2, multiAdd, multiDel;
            met1 = Method1; met2 = Method2;
            multiAdd = met1 + met2;
            multiDel = multiAdd - met2;
            met1("A"); met2("B");
            multiAdd("C");
            multiDel("D");
        }
    }
}

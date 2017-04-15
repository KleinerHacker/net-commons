using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace net.commons.test
{
    [TestClass]
    public class ConosleExTest
    {
        [TestMethod]
        public void TestANSI()
        {
            ConsoleEx.Write("Hallo \x1B[31mWelt");
        }
    }
}

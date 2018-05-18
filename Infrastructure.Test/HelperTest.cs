using Infrastructure.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Test
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void NetworkHelperTest()
        {
            var str = NetworkHelper.GetLocalIPAddress();
            Assert.AreEqual(str, "192.168.121.152");
        }
    }
}

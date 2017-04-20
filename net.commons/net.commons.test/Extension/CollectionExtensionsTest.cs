#region

using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.commons.Extension;

#endregion

namespace net.commons.test.Extension
{
    [TestClass]
    public class CollectionExtensionsTest
    {
        [TestMethod]
        public void TestSyncNoEquality()
        {
            var listCounter = 0;

            var list1 = new BindingList<string> {"abc", "xyz", "ghj"};
            list1.ListChanged += (sender, args) => listCounter++;
            IList<string> list2 = new List<string> {"123", "890", "567"};

            list1.SyncWith(list2);

            Assert.AreEqual(6, listCounter);
            Assert.AreEqual(3, list1.Count);
            Assert.AreEqual("123", list1[0]);
            Assert.AreEqual("890", list1[1]);
            Assert.AreEqual("567", list1[2]);
        }

        [TestMethod]
        public void TestSyncAllEquality()
        {
            var listCounter = 0;

            var list1 = new BindingList<string> {"abc", "xyz", "ghj"};
            list1.ListChanged += (sender, args) => listCounter++;
            IList<string> list2 = new List<string> {"abc", "xyz", "ghj"};

            list1.SyncWith(list2);

            Assert.AreEqual(0, listCounter);
            Assert.AreEqual(3, list1.Count);
            Assert.AreEqual("abc", list1[0]);
            Assert.AreEqual("xyz", list1[1]);
            Assert.AreEqual("ghj", list1[2]);
        }

        [TestMethod]
        public void TestSync()
        {
            var listCounter = 0;

            var list1 = new BindingList<string> {"abc", "xyz", "ghj"};
            list1.ListChanged += (sender, args) => listCounter++;
            IList<string> list2 = new List<string> {"123", "xyz", "567"};

            list1.SyncWith(list2);

            Assert.AreEqual(4, listCounter);
            Assert.AreEqual(3, list1.Count);
            Assert.AreEqual("xyz", list1[0]);
            Assert.AreEqual("123", list1[1]);
            Assert.AreEqual("567", list1[2]);
        }
    }
}
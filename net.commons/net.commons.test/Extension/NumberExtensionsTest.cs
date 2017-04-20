#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.commons.Extension;

#endregion

namespace net.commons.test.Extension
{
    [TestClass]
    public class NumberExtensionsTest
    {
        [TestMethod]
        public void TestSByte()
        {
            sbyte value = 0x07;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToSByte());
        }

        [TestMethod]
        public void TestInt16()
        {
            short value = 777;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToInt16());
        }

        [TestMethod]
        public void TestUInt16()
        {
            ushort value = 888;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToUInt16());
        }

        [TestMethod]
        public void TestInt32()
        {
            int value = 777777;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToInt32());
        }

        [TestMethod]
        public void TestUInt32()
        {
            uint value = 888888;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToUInt32());
        }

        [TestMethod]
        public void TestInt64()
        {
            long value = 777777777777;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToInt64());
        }

        [TestMethod]
        public void TestUInt64()
        {
            ulong value = 888888888888;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToUInt64());
        }

        [TestMethod]
        public void TestDouble()
        {
            double value = 7.77d;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToDouble(), 0.001d);
        }

        [TestMethod]
        public void TestSingle()
        {
            float value = 8.88f;

            var bytes = value.ToByteArray();

            Assert.AreEqual(value, bytes.ToSingle(), 0.001f);
        }
    }
}
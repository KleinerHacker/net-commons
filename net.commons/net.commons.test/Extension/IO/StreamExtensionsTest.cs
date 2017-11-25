#region

using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Commons.Extension.IO;

#endregion

namespace Net.Commons.Test.Extension.IO
{
    [TestClass]
    public class StreamExtensionsTest
    {
        [TestMethod]
        public void TestWriteRead()
        {
            byte[] bytes;
            using (var stream = new MemoryStream())
            {
                stream.WriteByte(0x07);
                stream.WriteSByte(0x08);
                stream.WriteInt16(777);
                stream.WriteUInt16(888);
                stream.WriteInt32(777777);
                stream.WriteUInt32(888888);
                stream.WriteInt64(777777777777);
                stream.WriteUInt64(888888888888);
                stream.WriteDouble(7.77d);
                stream.WriteSingle(7.77f);
                stream.WriteBoolean(true);
                stream.WriteCharacter(' ', Encoding.ASCII);
                stream.WriteCharacterArray("Hello".ToCharArray(), Encoding.UTF8);
                stream.WriteString("World", Encoding.Unicode);

                bytes = stream.ToArray();
            }

            using (var stream = new MemoryStream(bytes))
            {
                Assert.AreEqual(0x07, stream.ReadByte());
                Assert.AreEqual((sbyte) 0x08, stream.ReadSByte());
                Assert.AreEqual(777, stream.ReadInt16());
                Assert.AreEqual((ushort) 888, stream.ReadUInt16());
                Assert.AreEqual(777777, stream.ReadInt32());
                Assert.AreEqual((uint) 888888, stream.ReadUInt32());
                Assert.AreEqual(777777777777, stream.ReadInt64());
                Assert.AreEqual((ulong) 888888888888, stream.ReadUInt64());
                Assert.AreEqual(7.77d, stream.ReadDouble(), 0.001d);
                Assert.AreEqual(7.77f, stream.ReadSingle(), 0.001f);
                Assert.IsTrue(stream.ReadBoolean());
                Assert.AreEqual(' ', stream.ReadCharacter(Encoding.ASCII));
                Assert.IsTrue("Hello".ToCharArray().SequenceEqual(stream.ReadCharacterArray(Encoding.UTF8)));
                Assert.AreEqual("World", stream.ReadString(Encoding.Unicode));
            }
        }
    }
}
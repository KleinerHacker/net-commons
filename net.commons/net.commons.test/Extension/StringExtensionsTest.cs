#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Commons.Extension;

#endregion

namespace Net.Commons.Test.Extension
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void TestWildcard()
        {
            Assert.IsTrue("ABC".MatchWildcard("*B*"));
            Assert.IsFalse("ABC".MatchWildcard("*B"));
            Assert.IsFalse("ABC".MatchWildcard("B*"));
            Assert.IsFalse("ABC".MatchWildcard("B"));

            Assert.IsTrue("ABC".MatchWildcard("A*"));
            Assert.IsFalse("ABC".MatchWildcard("*A"));
            Assert.IsTrue("ABC".MatchWildcard("*A*"));
            Assert.IsFalse("ABC".MatchWildcard("A"));

            Assert.IsTrue("ABC".MatchWildcard("*C"));
            Assert.IsFalse("ABC".MatchWildcard("C*"));
            Assert.IsTrue("ABC".MatchWildcard("*C*"));
            Assert.IsFalse("ABC".MatchWildcard("C"));

            Assert.IsTrue("ABC".MatchWildcard("AB*"));
            Assert.IsFalse("ABC".MatchWildcard("*AB"));
            Assert.IsTrue("ABC".MatchWildcard("*AB*"));
            Assert.IsFalse("ABC".MatchWildcard("AB"));

            Assert.IsTrue("ABC".MatchWildcard("A*C"));
            Assert.IsFalse("ABC".MatchWildcard("C*A"));
            Assert.IsTrue("ABC".MatchWildcard("*A*C*"));
            Assert.IsFalse("ABC".MatchWildcard("*AC*"));
        }
    }
}
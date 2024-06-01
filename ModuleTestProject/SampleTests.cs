using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;

namespace ModuleTestProject
{
    [TestFixture]
    public class SampleTests
    {
        [Test]
        public void TestMethod1()
        {
            ClassicAssert.AreEqual(1, 1);
        }
    }
}

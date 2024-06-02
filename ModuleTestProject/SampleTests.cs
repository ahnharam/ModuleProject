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
            // 레거시 Nunit 테스트
            ClassicAssert.AreEqual(1, 1);
        }
    }
}

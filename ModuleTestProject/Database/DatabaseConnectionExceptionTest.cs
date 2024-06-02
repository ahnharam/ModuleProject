using ModuleProject.Database;
using ModuleProject.Utils;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTestProject.Database
{
    [TestFixture]
    public class DatabaseConnectionExceptionTests
    {
        [Test]
        public void Constructor_ShouldSetMessage()
        {
            var exception = new DatabaseConnectionException("Test message");
            Assert.That(exception.Message, Is.EqualTo("Test message"));
        }

        [Test]
        public void Constructor_ShouldSetMessageAndInnerException()
        {
            var innerException = new Exception("Inner exception");
            var exception = new DatabaseConnectionException("Test message", innerException);
            Assert.That(exception.Message, Is.EqualTo("Test message"));
            Assert.That(exception.InnerException, Is.EqualTo(innerException));
        }
    }
}
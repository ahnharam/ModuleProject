using NUnit.Framework;
using ModuleProject.Utils;
using System.Text;
using System.Diagnostics;

namespace ModuleTestProject.Util
{
    [TestFixture]
    public class CrcCodeTest
    {
        [Test]
        public void ComputeCrc_StringInput_ShouldReturnCorrectCrcString()
        {
            // Arrange
            string input = "3B12";
            string expectedOutput = "31 3B";

            // Act
            string result = CrcCode.ComputeCrc(input);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ComputeCrc_ByteArrayInput_ShouldReturnCorrectCrcByteArray()
        {
            // Arrange
            //byte[] data = Encoding.UTF8.GetBytes("test");
            //byte[] expectedOutput = { 0xDC, 0x2E };

            byte[] data = Encoding.UTF8.GetBytes("0102");
            byte[] expectedOutput = { 0x3E, 0xCB };

            // Act
            byte[] result = CrcCode.ComputeCrc(data);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ByteToHex_ShouldConvertByteArrayToHexString()
        {
            // Arrange
            byte[] bytes = { 0x01, 0x02, 0xAB, 0xCD };
            string expectedOutput = "01 02 AB CD";

            // Act
            string result = CrcCode.ByteToHex(bytes);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ConvertHexStringToByte_ShouldConvertHexStringToByteArray()
        {
            // Arrange
            string hexString = "0102ABCD";
            byte[] expectedOutput = { 0x01, 0x02, 0xAB, 0xCD };

            // Act
            byte[] result = CrcCode.ConvertHexStringToByte(hexString);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void ConvertBytesToString_ShouldConvertByteArrayToHexString()
        {
            // Arrange
            byte[] buffer = { 0x01, 0x02, 0xAB, 0xCD };
            int bytesRead = buffer.Length;
            string expectedOutput = "01 02 AB CD";

            // Act
            string result = CrcCode.ConvertBytesToString(buffer, bytesRead);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }


        // 수정사항
        // 제대로 원인 파악이 안됨
        [Test]
        public void StringHexToByteWithCRC_ShouldConvertHexStringToByteArrayWithCrc()
        {
            // Arrange
            string hexString = "0102";
            byte[] expectedOutput = { 0x01, 0x02, 0x3E, 0xCB };

            //byte[] data = CrcCode.ConvertHexStringToByte(hexString);
            //Debug.WriteLine(CrcCode.ByteToHex(data));

            //byte[] crcBytes = CrcCode.ComputeCrc(data);
            //Debug.WriteLine(CrcCode.ByteToHex(crcBytes));

            //Debug.WriteLine(CrcCode.ComputeCrc("0102"));

            //Act
            byte[] result = CrcCode.StringHexToByteWithCRC(hexString);

            Debug.WriteLine(CrcCode.ByteToHex(result));

            //Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}

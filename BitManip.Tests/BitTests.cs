using NUnit.Framework;

namespace BitManip.Tests
{
    [TestFixture]
    public class BitTests
    {
        [TestCase(1, 0, true)]
        [TestCase(1, 1, false)]
        [TestCase(1, 2, false)]
        [TestCase(1, 7, false)]
        [TestCase(2, 0, false)]
        [TestCase(2, 1, true)]
        [TestCase(2, 2, false)]
        [TestCase(2, 7, false)]
        public void BitAtIndex_GivenByteAndIndex_returnsBitValueAtIndex(byte b, int index, bool expectedValue)
        {
            var valueAtIndex = Bit.GetBitAtIndex(b, index);
            Assert.AreEqual(expectedValue, valueAtIndex);
        }

        [TestCase(1, -10, false)]
        [TestCase(1, -1, false)]
        [TestCase(1, 8, false)]
        [TestCase(1, 80, false)]
        public void BitAtIndex_GivenByteAndOutOfRangeIndex_returnsFalse(byte b, int index, bool expectedValue)
        {
            var valueAtIndex = Bit.GetBitAtIndex(b, index);
            Assert.AreEqual(expectedValue, valueAtIndex);
        }
        
        [TestCase(0, 0, 1, 0)]
        [TestCase(0, 0, 7, 0)]
        [TestCase(0, 2, 3, 0)]
        [TestCase(255, 0, 8, 255)]
        [TestCase(255, 0, 1, 1)]
        [TestCase(255, 2, 3, 7)]
        [TestCase(1, 0, 0, 0)]
        [TestCase(1, 0, 1, 1)]
        [TestCase(1, 0, 3, 1)]
        [TestCase(170, 2, 3, 2)]
        public void NumberFromRange_GivenByte_ReturnsNumberFromRangeOfBits(byte b, int startIndex, int lengthFromStart, int expectedValue)
        {
            var valueFromRange = Bit.GetNumberFromBitRange(b, startIndex, lengthFromStart);
            Assert.AreEqual(expectedValue, valueFromRange);
        }
    }
}

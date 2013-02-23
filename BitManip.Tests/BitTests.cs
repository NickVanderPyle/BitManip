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

        /* GetNumberFromBitRange does a left shift and then a right shift.
           The first left shift will shift by 8 - (start + length)
           The second riht shift will shift by 8 - length.
           When it shifts, the byte is converted to an Int32.
           Shifting a 32bit number by a shift count will derive the real shift count from the first 5bits.
           For example:
           40 << 5000  is the same as  40 << 8
            5000 == 1001110001000
            First 5bits...
            01000 == 8
        */
        [TestCase(1, -10, 1, 0)]        // leftshift by 17 then right by 7. Only zero bits remain in first byte.
        [TestCase(127, 10, 3, 0)]       // leftshift by -5 whose 6 LSB are 27 in positive binary. Left shifts the byte by 27bits leaving only 0s.
        [TestCase(255, 4000, 3, 7)]     // leftshift by -3995 whose 6 LSB are 5 in positive binary. Then right shift by 5.
        public void NumberFromRange_AttemptToUseSeeminglyInvalidRange_ReturnsExpectedNumber(byte b, int startIndex, int lengthFromStart, int expectedValue)
        {
            var valueFromRange = Bit.GetNumberFromBitRange(b, startIndex, lengthFromStart);
            Assert.AreEqual(expectedValue, valueFromRange);
        }
    }
}

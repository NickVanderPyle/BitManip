using System.Collections;

namespace BitManip
{
    public static class Bit
    {
        public static bool GetBitAtIndex(byte b, int index)
        {
            return (b & (1 << index)) != 0;
        }

        public static int GetNumberFromBitRange(byte b, int start, int length)
        {
            var leftShiftBy = 8 - (start + length);
            var rightShiftBy = 8 - length;
            return (byte)(b << leftShiftBy) >> rightShiftBy;
        }
    }
}

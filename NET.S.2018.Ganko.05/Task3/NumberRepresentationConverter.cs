using System.Runtime.InteropServices;

namespace Task3
{
    /// <summary>
    /// Class contains the extension method which converts double to binary string
    /// </summary>
    public static class NumberRepresentationConverter
    {
        /// <summary>
        /// Doubles to binary string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Returns string which represents binary representation of double in the format IEEE 754</returns>
        public static string DoubleToBinaryString(this double number)
        {
            const long mask = 1;
            int numberOfBits = 64;
            var binary = string.Empty;

            DoubleToLongStruct numberStruct = new DoubleToLongStruct { Double64Bits = number };

            ulong long64Bits = numberStruct.Long64Bits;

            while (numberOfBits > 0)
            {
                binary = (long64Bits & mask) + binary;
                long64Bits >>= 1;
                numberOfBits--;
            }

            return binary;
        }

        /// <summary>
        /// Struct stores bits of double and ulong values
        /// </summary>
        [StructLayout(LayoutKind.Explicit, Size = 8)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly ulong long64bits;

            [FieldOffset(0)]
            private double double64bits;

            /// <summary>
            /// Gets the long64bits.
            /// </summary>
            /// <value>
            /// The long64bits.
            /// </value>
            public ulong Long64Bits => long64bits;

            /// <summary>
            /// Gets or sets the double64bits.
            /// </summary>
            /// <value>
            /// The double64bits.
            /// </value>
            public double Double64Bits
            {
                get => double64bits;
                set => double64bits = value;
            }
        }
    }
}

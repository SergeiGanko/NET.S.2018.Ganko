using System.Linq;

namespace WorkingWithJaggedArray
{
    public static class ArrayHelper
    {
        public static int GetSum(int[] array) => array.Sum();

        public static int GetMax(int[] array) => array.Max();

        public static int GetMin(int[] array) => array.Min();
    }
}

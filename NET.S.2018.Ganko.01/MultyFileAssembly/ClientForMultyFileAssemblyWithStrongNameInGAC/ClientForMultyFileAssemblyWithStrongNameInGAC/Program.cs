using System;
using Country;

namespace ClientForMultyFileAssemblyWithStrongNameInGAC
{
    /// <summary>
    /// Class Program
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// The Main method
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(Belarus.GetCapital());
            Console.WriteLine(Greenland.GetCapital());
            Console.WriteLine(Greenland.GetPopulation());
            Console.WriteLine(Madagascar.GetCapital());
            Console.ReadLine();
        }
    }
}

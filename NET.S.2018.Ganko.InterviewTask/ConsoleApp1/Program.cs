// <copyright file="Program.cs" company="Sergei Ganko">
//     Copyright (c) Sergei Ganko. All rights reserved.
// </copyright>
// <author>Sergei Ganko</author>
namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using MergeSortAlgorithm;
    using Model;
    using MyQueue;

    /// <summary>
    ///  Class Program.
    ///  The main class of the program
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Performs methods which demostrate a merge sort
        /// </summary>
        private static void Main()
        {
            Console.WriteLine($"******* Mergesort Algorithm Testing *******");
            MergeSortDemostrate();

            Console.WriteLine($"********* Queue Testing *********");
            MyQueueOfStringsDemonstrate();
            MyGenericQueueDemonstrate();
        }

        /// <summary>
        /// Demostrates work of mergesort
        /// </summary>
        private static void MergeSortDemostrate()
        {
            int[] arrayOfInts =
                        {
                5, 2, 4, 1, 3, 45, 0, 31, 89, 123, 42, 73, 99
            };

            Show(arrayOfInts);

            MyMergeSorter.MergeSort(arrayOfInts);

            Show(arrayOfInts);

            string[] arrayOfStrings =
            {
                "efg", "xyz", "abc", "opq", "hij", "d"
            };

            Show(arrayOfStrings);

            MyMergeSorter.MergeSort(arrayOfStrings);

            Show(arrayOfStrings);

            Car[] cars =
            {
                new Car("Toyota", "Land Cruiser", 9.5),
                new Car("Audi", "A7", 5.2),
                new Car("Ford", "Mustang", 5.5),
                new Car("Lada", "Kalina", 13.7)
            };

            Show(cars);

            MyMergeSorter.MergeSort(cars);

            Show(cars);
        }

        /// <summary>
        /// Shows array on the console
        /// </summary>
        /// <typeparam name="T">Generic parameter</typeparam>
        /// <param name="inputArray">Parameter arr represents an array</param>
        private static void Show<T>(T[] inputArray)
        {
            foreach (var a in inputArray)
            {
                Console.Write($"{a}");
            }

            Console.WriteLine($"\n");
        }

        /// <summary>
        /// Demostrates work of generic queue
        /// </summary>
        private static void MyGenericQueueDemonstrate()
        {
            List<Car> cars = new List<Car>
            {
                new Car("Toyota", "Land Cruiser"),
                new Car("Audi", "A7"),
                new Car("Ford", "Mustang", 5.5),
                new Car("Lada", "Kalina"),
            };

            try
            {
                var myGenericQueue = new MyGenericQueue<Car>(cars);

                foreach (var item in myGenericQueue)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"{item.Manufacturer} {item.Model}");
                    }
                }

                Console.WriteLine();

                do
                {
                    var car = myGenericQueue.Dequeue();
                    Console.WriteLine($"{car.Manufacturer} {car.Model}");
                }
                while (!myGenericQueue.IsEmpty);

                Console.WriteLine($"Is queue empty? {myGenericQueue.IsEmpty}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
            }
        }

        /// <summary>
        /// Demostrates queue of strings work
        /// </summary>
        private static void MyQueueOfStringsDemonstrate()
        {
            MyQueueOfStrings queueOfStrings = new MyQueueOfStrings(3);

            try
            {
                queueOfStrings.Enqueue("string1");
                queueOfStrings.Enqueue("string2");
                queueOfStrings.Enqueue("string3");
                queueOfStrings.Enqueue("string4");
                Console.WriteLine($"Queue length: {queueOfStrings.Count}");

                Console.Write("Queue: ");
                foreach (var queueOfString in queueOfStrings)
                {
                    Console.Write($"{queueOfString}  ");
                }

                Console.WriteLine();

                do
                {
                    Console.WriteLine($"Pop: {queueOfStrings.Dequeue()}");
                }
                while (!queueOfStrings.IsEmpty);

                Console.WriteLine($"Is queue empty? {queueOfStrings.IsEmpty}");
                Console.WriteLine();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
            }
        }
    }
}

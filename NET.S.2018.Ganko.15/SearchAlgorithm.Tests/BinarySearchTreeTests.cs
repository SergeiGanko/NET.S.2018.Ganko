using NUnit.Framework;
using SearchAlgorithm.Tests.Comparers;

namespace SearchAlgorithm.Tests
{
    using System;

    using StringComparer = SearchAlgorithm.Tests.Comparers.StringComparer;

    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Tests with System.Int32

        private static readonly int[] testInts = { 53, 30, 14, 39, 9, 23, 72, 61, 84, 79 };

        [Test]
        public void TraverseWithIntDefaultTest()
        {
            var tree = new BinarySearchTree<int>(testInts);
            int[] expectedArrayInOrder = { 9, 14, 23, 30, 39, 53, 61, 72, 79, 84 };
            int[] expectedArrayPreOrder = { 53, 30, 14, 9, 23, 39, 72, 61, 84, 79 };
            int[] expectedArrayPostOrder = { 9, 23, 14, 39, 30, 61, 79, 84, 72, 53 };

            CollectionAssert.AreEqual(expectedArrayInOrder, tree.InOrderTraverse());
            CollectionAssert.AreEqual(expectedArrayPreOrder, tree.PreOrderTraverse());
            CollectionAssert.AreEqual(expectedArrayPostOrder, tree.PostOrderTraverse());
        }

        [Test]
        public void TraverseWithIntComparerTest()
        {
            var tree = new BinarySearchTree<int>(testInts, new IntComparer());
            int[] expectedArrayInOrder = { 84, 79, 72, 61, 53, 39, 30, 23, 14, 9 };
            int[] expectedArrayPreOrder = { 53, 72, 84, 79, 61, 30, 39, 14, 23, 9 };
            int[] expectedArrayPostOrder = { 79, 84, 61, 72, 39, 23, 9, 14, 30, 53 };

            CollectionAssert.AreEqual(expectedArrayInOrder, tree.InOrderTraverse());
            CollectionAssert.AreEqual(expectedArrayPreOrder, tree.PreOrderTraverse());
            CollectionAssert.AreEqual(expectedArrayPostOrder, tree.PostOrderTraverse());
        }

        [TestCase(23)]
        [TestCase(84)]
        [TestCase(61)]
        public void ContainsTest(int number)
        {
            var tree = new BinarySearchTree<int>(testInts);

            Assert.True(tree.Contains(number));
        }

        [TestCase(-2)]
        [TestCase(99)]
        public void ContainsNegativeTest(int number)
        {
            var tree = new BinarySearchTree<int>(testInts);

            Assert.False(tree.Contains(number));
        }

        [TestCase(73)]
        [TestCase(10)]
        public void AddTest(int number)
        {
            var tree = new BinarySearchTree<int>(testInts);
            tree.Add(number);

            Assert.True(tree.Contains(number));
        }

        [Test]
        public void ClearTest()
        {
            var tree = new BinarySearchTree<int>(testInts);
            tree.Clear();

            Assert.AreEqual(0, tree.Count);
        }

        #endregion

        #region Tests with System.String

        private static readonly string[] testStrings = { "F", "D", "A", "B", "S", "K", "T", "Q" };

        [Test]
        public void TraverseWithStringDefaultTest()
        {
            var tree = new BinarySearchTree<string>(testStrings);
            string[] expectedArrayInOrder = { "A", "B", "D", "F", "K", "Q", "S", "T" };
            string[] expectedArrayPreOrder = { "F", "D", "A", "B", "S", "K", "Q", "T" };
            string[] expectedArrayPostOrder = { "B", "A", "D", "Q", "K", "T", "S", "F" };

            CollectionAssert.AreEqual(expectedArrayInOrder, tree.InOrderTraverse());
            CollectionAssert.AreEqual(expectedArrayPreOrder, tree.PreOrderTraverse());
            CollectionAssert.AreEqual(expectedArrayPostOrder, tree.PostOrderTraverse());
        }

        [Test]
        public void TraverseWithStringComparerTest()
        {
            var tree = new BinarySearchTree<string>(testStrings, new StringComparer());
            string[] expectedArrayInOrder = { "T", "S", "Q", "K", "F", "D", "B", "A" };
            string[] expectedArrayPreOrder = { "F", "S", "T", "K", "Q", "D", "A", "B" };
            string[] expectedArrayPostOrder = { "T", "Q", "K", "S", "B", "A", "D", "F" };

            CollectionAssert.AreEqual(expectedArrayInOrder, tree.InOrderTraverse());
            CollectionAssert.AreEqual(expectedArrayPreOrder, tree.PreOrderTraverse());
            CollectionAssert.AreEqual(expectedArrayPostOrder, tree.PostOrderTraverse());
        }

        #endregion

        #region Tests with Book class

        private static readonly Book book1 = new Book(
            "978-0-672-33690-4",
            "Bart De Smet",
            "C# 5.0 Unleashed",
            "SAMS Publishing",
            2013,
            1671,
            51.29m);

        private static readonly Book book2 = new Book(
            "978-0-735-68320-4",
            "Gary McLean Hall",
            "Adaptive Code via C#",
            "Microsoft Press",
            2014,
            403,
            35.01m);

        private static readonly Book book3 = new Book(
            "978-1-617-29134-0",
            "Jon Skeet",
            "C# in Depth, 3rd Edition",
            "Manning",
            2015,
            605,
            39.73m);

        private static readonly Book book4 = new Book(
            "978-1-491-98765-0",
            "Joseph Albahari & Веn Albahari",
            "C# 7.0 in a Nutshell: The Definitive Reference",
            "O'Reilly",
            2018,
            1140,
            60.53m);

        private static Book[] books = { book1, book2, book3, book4 };

        [Test]
        public void TraverseWithBookDefaultTest()
        {
            var tree = new BinarySearchTree<Book>(books);

            CollectionAssert.AreEqual(new Book[] { book2, book1, book4, book3 }, tree.InOrderTraverse());
            CollectionAssert.AreEqual(new Book[] { book1, book2, book3, book4 }, tree.PreOrderTraverse());
            CollectionAssert.AreEqual(new Book[] { book2, book4, book3, book1 }, tree.PostOrderTraverse());
        }

        [Test]
        public void TraverseWithBookComparerTest()
        {
            var tree = new BinarySearchTree<Book>(books, new BookComparer());

            CollectionAssert.AreEqual(new Book[] { book2, book3, book1, book4 }, tree.InOrderTraverse());
            CollectionAssert.AreEqual(new Book[] { book1, book2, book3, book4 }, tree.PreOrderTraverse());
            CollectionAssert.AreEqual(new Book[] { book3, book2, book4, book1 }, tree.PostOrderTraverse());
        }

        #endregion

        #region Tests with Poit struct

        private static Point point1 = new Point(6, 7);
        private static Point point2 = new Point(2, 5);
        private static Point point3 = new Point(4, 2);
        private static Point point4 = new Point(3, 3);
        private static Point[] points = { point2, point1, point4, point3 };

        [Test]
        public void TraverseWithPointComparerTest()
        {
            var tree = new BinarySearchTree<Point>(points, new PointComparer());

            CollectionAssert.AreEqual(new Point[] { point3, point4, point2, point1}, tree.InOrderTraverse());
            CollectionAssert.AreEqual(new Point[] { point2, point4, point3, point1}, tree.PreOrderTraverse());
            CollectionAssert.AreEqual(new Point[] { point3, point4, point1, point2}, tree.PostOrderTraverse());
        }

        #endregion
    }
}

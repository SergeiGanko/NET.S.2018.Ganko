using System;
using System.Collections.Generic;
using System.Collections;

namespace SearchAlgorithm
{
    /// <summary>
    /// BinarySearchTree Class
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public sealed class BinarySearchTree<T> : IEnumerable<T>
    {
        #region Fields

        /// <summary>
        /// The comparer
        /// </summary>
        private readonly IComparer<T> comparer;

        /// <summary>
        /// The root of the tree
        /// </summary>
        private Node<T> root;

        /// <summary>
        /// The count of nodes
        /// </summary>
        private int count;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            this.comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">The comparer ot two objects of the same type</param>
        public BinarySearchTree(IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                this.comparer = Comparer<T>.Default;
            }
            else
            {
                this.comparer = comparer;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparison">The comparison of two objects of the same type</param>
        public BinarySearchTree(Comparison<T> comparison = null)
        {
            if (comparison == null)
            {
                this.comparer = Comparer<T>.Default;
            }
            else
            {
                this.comparer = Comparer<T>.Create(comparison);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public BinarySearchTree(IEnumerable<T> collection) : this()
        {
            CheckInput(collection);

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection of elements</param>
        /// <param name="comparison">The comparison of two objects of the same type</param>
        /// <exception cref="ArgumentNullException">Throws when collection is null</exception>
        public BinarySearchTree(IEnumerable<T> collection, Comparison<T> comparison = null) : this(comparison)
        {
            CheckInput(collection);

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection of element.</param>
        /// <param name="comparer">The comparer  of two objects of the same type.</param>
        /// <exception cref="ArgumentNullException">Throws when collection is null</exception>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer = null) : this(comparer)
        {
            CheckInput(collection);

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the count of tree nodes.
        /// </summary>
        public int Count => this.count;

        #endregion

        #region Public Methods

        /// <summary>
        /// Preorder traverse.
        /// </summary>
        /// <returns>The sequence of values of binary tree nodes</returns>
        public IEnumerable<T> PreOrderTraverse()
        {
            return PreOrder(root);
        }

        /// <summary>
        /// Inorder traverse.
        /// </summary>
        /// <returns>The sequence of values of binary tree nodes</returns>
        public IEnumerable<T> InOrderTraverse()
        {
            return InOrder(root);
        }

        /// <summary>
        /// Postorder traverse.
        /// </summary>
        /// <returns>The sequence of values of binary tree nodes</returns>
        public IEnumerable<T> PostOrderTraverse()
        {
            return PostOrder(root);
        }

        /// <summary>
        /// Adds the specified item as node of the binary tree.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">Throws when item is null</exception>
        public void Add(T item)
        {
            CheckInput(item);

            if (root == null)
            {
                root = new Node<T>(item);
            }
            else
            {
                AddItem(root, item);
            }

            count++;
        }

        /// <summary>
        /// Determines whether binary tree contains the specified node.
        /// </summary>
        /// <param name="item">The node.</param>
        /// <returns>
        ///   <c>true</c> if contains the specified node; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T item)
        {
            CheckInput(item);

            var (current, parent) = Find(item);
            return current != null;
        }

        /// <summary>
        /// Removes the specified node.
        /// </summary>
        /// <param name="item">The node to be deleted.</param>
        /// <returns>True if node successfully deleted</returns>
        public bool Remove(T item)
        {
            CheckInput(item);

            var (current, parent) = Find(item);

            if (current is null)
            {
                return false;
            }

            //  The node to be deleted has no children
            if (current.Left == null && current.Right == null)
            {
                if (current == this.root)
                {
                    this.root = null;
                }
                else if (parent.Left == current)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            // The node to be deleted has one child
            else if (current.Right == null) // if no right child, replace with left subtree
            {
                if (current == this.root)
                {
                    this.root = current.Left;
                }
                else if (parent.Left == current)
                {
                    parent.Left = current.Left;
                }
                else
                {
                    parent.Right = current.Left;
                }
            }
            else if (current.Left == null) // if no left child, replace with right subtree
            {
                if (current == this.root)
                {
                    this.root = current.Right;
                }
                else if (parent.Left == current)
                {
                    parent.Left = current.Right;
                }
                else
                {
                    parent.Right = current.Right;
                }
            }
            // The node to be deleted has two children
            else
            {
                // get successor of node to delete current
                Node<T> successor = GetSuccessor(current);

                // connect parent of current to successor instead
                if (current == this.root)
                {
                    this.root = successor;
                }
                else if (parent.Left == current)
                {
                    parent.Left = successor;
                }
                else
                {
                    parent.Right = successor;
                }

                successor.Left = current.Left;
            }

            count--;

            return true;
        }

        /// <summary>
        /// Clears this binary tree.
        /// </summary>
        public void Clear()
        {
            root = null;
            count = 0;
        }

        #endregion

        #region IEnumerable<T> implementation

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraverse().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Preorder traverse.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns></returns>
        private IEnumerable<T> PreOrder(Node<T> root)
        {
            if (ReferenceEquals(root, null))
            {
                yield break;
            }

            yield return root.Value;

            if (root.Left != null)
            {
                foreach (var item in PreOrder(root.Left))
                {
                    yield return item;
                }
            }

            if (root.Right != null)
            {
                foreach (var item in PreOrder(root.Right))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Inorder traverse.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns></returns>
        private IEnumerable<T> InOrder(Node<T> root)
        {
            if (ReferenceEquals(root, null))
            {
                yield break;
            }

            if (root.Left != null)
            {
                foreach (var item in InOrder(root.Left))
                {
                    yield return item;
                }
            }

            yield return root.Value;

            if (root.Right != null)
            {
                foreach (var item in InOrder(root.Right))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Postorder traverse.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <returns></returns>
        private IEnumerable<T> PostOrder(Node<T> root)
        {
            if (ReferenceEquals(root, null))
            {
                yield break;
            }

            if (root.Left != null)
            {
                foreach (var item in PostOrder(root.Left))
                {
                    yield return item;
                }
            }

            if (root.Right != null)
            {
                foreach (var item in PostOrder(root.Right))
                {
                    yield return item;
                }
            }

            yield return root.Value;
        }

        /// <summary>
        /// Adds the specified item as node of the binary tree.
        /// </summary>
        /// <param name="node">The node of binary tree.</param>
        /// <param name="item">The item.</param>
        private void AddItem(Node<T> node, T item)
        {
            if (comparer.Compare(node.Value, item) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(item);
                }
                else
                {
                    AddItem(node.Left, item);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(item);
                }
                else
                {
                    AddItem(node.Right, item);
                }
            }
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <typeparam name="T">Any Type</typeparam>
        /// <param name="obj">The object.</param>
        /// <exception cref="ArgumentNullException">Throws when obj is null</exception>
        private static void CheckInput<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"Argument {nameof(obj)} is null");
            }
        }

        /// <summary>
        /// Finds the specified node.
        /// </summary>
        /// <param name="item">The node with specified value.</param>
        /// <returns>Returns the tuple of nodes</returns>
        private (Node<T> current, Node<T> parent) Find(T item)
        {
            CheckInput(item);

            Node<T> current = this.root;
            Node<T> parent = null;

            while (current != null)
            {
                if (comparer.Compare(item, current.Value) < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (comparer.Compare(item, current.Value) > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return (current, parent);
        }

        /// <summary>
        /// Gets the successor.
        /// </summary>
        /// <param name="delNode">The delete node.</param>
        /// <returns> returns node with next-highest value after delNode goes to right child, then right child’s left descendants</returns>
        private Node<T> GetSuccessor(Node<T> delNode)
        {
            Node<T> successorParent = delNode;
            Node<T> successor = delNode;
            Node<T> current = delNode.Right;

            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.Left;
            }

            if (successor != delNode.Right)
            {
                successorParent.Left = successor.Right;
                successor.Right = delNode.Right;
            }

            return successor;
        }

        #endregion
    }
}

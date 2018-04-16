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
        /// <param name="collection">The collection of elements</param>
        /// <param name="comparison">The comparison of two objects of the same type</param>
        /// <exception cref="ArgumentNullException">Throws when collection is null</exception>
        public BinarySearchTree(IEnumerable<T> collection, Comparison<T> comparison = null) : this(comparison)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"Argument {nameof(collection)} is null");
            }

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
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"Argument {nameof(collection)} is null");
            }

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
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"Argument {nameof(item)} is null");
            }

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

        public bool Remove(T item)
        {
            // TODO ...
            count--;
        }

        public bool Contains(T item)
        {
            // TODO ...
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
        }

        /// <summary>
        /// Adds the specified item as node of the binary tree.
        /// </summary>
        /// <param name="node">The node of binary tree.</param>
        /// <param name="item">The item.</param>
        private void AddItem(Node<T> node, T item)
        {
            if (comparer.Compare(item, node.Value) < 0)
            {
                if (ReferenceEquals(node.Left, null))
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
                if (ReferenceEquals(node.Right, null))
                {
                    node.Right = new Node<T>(item);
                }
                else
                {
                    AddItem(node.Right, item);
                }
            }
        }

        #endregion
    }
}

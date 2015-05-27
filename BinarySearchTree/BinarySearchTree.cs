using System;

using BinarySearchTree.Data;

namespace BinarySearchTree
{
    public class BinarySearchTree<K,V>
        where K : IComparable<K>
    {
        internal Node<K, V> Root { get; set; }

        public V this[K key]
        {
            get 
            {
                var node = SearchForOneNode(n => (Key)key.CompareTo(n.Key));
                return node != null ? node.Value : default(V);
            }
        }

        public void Insert(K key, V value)
        {
            if (Root == null)
                InsertTreeFirstNode(key, value);
            else
                InsertTreeNextNode(Root, key, value);
        }

        public void Remove(K key)
        {
            if (Root == null)
                return;

            Remove(null, Root, key);
        }

        internal Node<K, V> SearchForOneNode(Func<Node<K, V>, Key> callback, bool noNullValue = false)
        {
            if (Root == null)
                return null;
            if (callback == null)
                throw new ArgumentNullException("callback");

            return SearchForOneNode(Root, callback, noNullValue);
        }

        internal void TraverseAllNodes(Action<Node<K, V>, int> callback)
        {
            if (Root == null)
                return;
            if (callback == null)
                throw new ArgumentNullException("callback");

            TraverseAllNodes(Root, callback, 1);
        }

        void InsertTreeFirstNode(K key, V value)
        {
            Root = new Node<K, V> { Key = key, Value = value };
        }

        void InsertTreeNextNode(Node<K, V> node, K key, V value)
        {
            var result = (Key)key.CompareTo(node.Key);

            if (IsKeySmaller(result))
                TryInsertOnNodeLeftSide(node, key, value);
            else if (IsKeyBigger(result))
                TryInsertOnNodeRightSide(node, key, value);
        }

        void TryInsertOnNodeLeftSide(Node<K, V> node, K key, V value)
        {
            if (node.Left == null)
                node.Left = new Node<K, V> { Key = key, Value = value };
            else
                InsertTreeNextNode(node.Left, key, value);
        }

        void TryInsertOnNodeRightSide(Node<K, V> node, K key, V value)
        {
            if (node.Right == null)
                node.Right = new Node<K, V> { Key = key, Value = value };
            else
                InsertTreeNextNode(node.Right, key, value);
        }

        void Remove(Node<K, V> parent, Node<K, V> node, K key)
        {
            var result = (Key)key.CompareTo(node.Key);

            if (IsKeyEqual(result))
                RemoveNode(parent, node);
            else if (IsLeftNodeNotNull(node) && IsKeySmaller(result))
                Remove(node, node.Left, key);
            else if (IsRightNodeNotNull(node) && IsKeyBigger(result))
                Remove(node, node.Right, key);
        }

        void RemoveNode(Node<K, V> parent, Node<K, V> node)
        {
            if (IsLeftNodeNotNull(node) && IsRightNodeNotNull(node))
                ReplaceNodeInParentWithSmallestChild(parent, node);

            else if (IsLeftNodeNotNull(node))
                ReplaceNodeInParentWithChild(parent, node, node.Left);

            else if (IsRightNodeNotNull(node))
                ReplaceNodeInParentWithChild(parent, node, node.Right);

            else
                ReplaceNodeInParentWithChild(parent, node, null);
        }

        void ReplaceNodeInParentWithSmallestChild(Node<K, V> parent, Node<K, V> node)
        {
            Node<K, V> child = null;
            for (var current = node.Right; current != null; current = current.Left)
            {
                child = current.Left ?? node.Right;
                if (child.Left == null)
                {
                    current.Left = null;
                    break;
                }
            }

            ReplaceNodeInParentWithChild(parent, node, child);
        }

        void ReplaceNodeInParentWithChild(Node<K, V> parent, Node<K, V> node, Node<K, V> child)
        {
            if (parent == null)
            {
                if (Root.Right != child)
                    child.Right = Root.Right;
                if (Root.Left != child)
                    child.Left = Root.Left;

                Root = child;
            }
            else if (parent.Left == node)
                parent.Left = child;
            else if (parent.Right == node)
                parent.Right = child;
        }

        Node<K, V> SearchForOneNode(Node<K, V> node, Func<Node<K, V>, Key> callback, bool noNullValue)
        {
            var result = callback(node);

            if (IsKeyEqual(result))
                return node;

            if (IsKeySmaller(result) && IsLeftNodeNotNull(node))
                return SearchForOneNode(node.Left, callback, noNullValue);

            if (IsKeyBigger(result) && IsRightNodeNotNull(node))
                return SearchForOneNode(node.Right, callback, noNullValue);

            return noNullValue ? node : null;
        }

        void TraverseAllNodes(Node<K, V> node, Action<Node<K, V>, int> callback, int level)
        {
            if (IsLeftNodeNotNull(node))
                TraverseAllNodes(node.Left, callback, level + 1);

            callback(node, level);

            if (IsRightNodeNotNull(node))
                TraverseAllNodes(node.Right, callback, level + 1);
        }

        bool IsLeftNodeNotNull(Node<K, V> node)
        {
            return node.Left != null;
        }

        bool IsRightNodeNotNull(Node<K, V> node)
        {
            return node.Right != null;
        }

        bool IsKeySmaller(Key result)
        {
            return result <= Key.IsSmaller;
        }

        bool IsKeyEqual(Key result)
        {
            return result == Key.IsEqual;
        }

        bool IsKeyBigger(Key result)
        {
            return result >= Key.IsBigger;
        }
    }
}
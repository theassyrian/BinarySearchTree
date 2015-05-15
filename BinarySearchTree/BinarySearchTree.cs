using System;

using BinarySearchTree.Data;

namespace BinarySearchTree
{
    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        internal Node<T> Root { get; set; }

        public void Insert(T value)
        {
            if (Root == null)
                InsertTreeFirstValue(value);
            else
                InsertTreeNextValue(Root, value);
        }

        public void Remove(T value)
        {
            if (Root == null)
                return;

            Remove(null, Root, value);
        }

        internal Node<T> SearchForOneNode(Func<Node<T>, Value> callback, bool noNullValue = false)
        {
            if (Root == null)
                return null;
            if (callback == null)
                throw new ArgumentNullException("callback");

            return SearchForOneNode(Root, callback, noNullValue);
        }

        internal void TraverseAllNodes(Action<Node<T>, int> callback)
        {
            if (Root == null)
                return;
            if (callback == null)
                throw new ArgumentNullException("callback");

            TraverseAllNodes(Root, callback, 1);
        }

        void InsertTreeFirstValue(T value)
        {
            Root = new Node<T> { Value = value };
        }

        void InsertTreeNextValue(Node<T> node, T value)
        {
            var result = (Value)value.CompareTo(node.Value);

            if (IsValueSmaller(result))
                TryInsertOnNodeLeftSide(node, value);
            else if (IsValueBigger(result))
                TryInsertOnNodeRightSide(node, value);
        }

        void TryInsertOnNodeLeftSide(Node<T> node, T value)
        {
            if (node.Left == null)
                node.Left = new Node<T> { Value = value };
            else
                InsertTreeNextValue(node.Left, value);
        }

        void TryInsertOnNodeRightSide(Node<T> node, T value)
        {
            if (node.Right == null)
                node.Right = new Node<T> { Value = value };
            else
                InsertTreeNextValue(node.Right, value);
        }

        void Remove(Node<T> parent, Node<T> node, T value)
        {
            var result = (Value)value.CompareTo(node.Value);

            if (IsValueEqual(result))
                RemoveNode(parent, node);
            else if (IsValueSmaller(result))
                Remove(node, node.Left, value);
            else if (IsValueBigger(result))
                Remove(node, node.Right, value);
        }

        void RemoveNode(Node<T> parent, Node<T> node)
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

        void ReplaceNodeInParentWithSmallestChild(Node<T> parent, Node<T> node)
        {
            Node<T> child = null;
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

        void ReplaceNodeInParentWithChild(Node<T> parent, Node<T> node, Node<T> child)
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

        Node<T> SearchForOneNode(Node<T> node, Func<Node<T>, Value> callback, bool noNullValue)
        {
            var result = callback(node);

            if (IsValueEqual(result))
                return node;

            if (IsValueSmaller(result) && IsLeftNodeNotNull(node))
                return SearchForOneNode(node.Left, callback, noNullValue);

            if (IsValueBigger(result) && IsRightNodeNotNull(node))
                return SearchForOneNode(node.Right, callback, noNullValue);

            return noNullValue ? node : null;
        }

        void TraverseAllNodes(Node<T> node, Action<Node<T>, int> callback, int level)
        {
            if (IsLeftNodeNotNull(node))
                TraverseAllNodes(node.Left, callback, level + 1);

            callback(node, level);

            if (IsRightNodeNotNull(node))
                TraverseAllNodes(node.Right, callback, level + 1);
        }

        bool IsLeftNodeNotNull(Node<T> node)
        {
            return node.Left != null;
        }

        bool IsRightNodeNotNull(Node<T> node)
        {
            return node.Right != null;
        }

        bool IsValueSmaller(Value result)
        {
            return result <= Value.IsSmaller;
        }

        bool IsValueEqual(Value result)
        {
            return result == Value.IsEqual;
        }

        bool IsValueBigger(Value result)
        {
            return result >= Value.IsBigger;
        }
    }
}
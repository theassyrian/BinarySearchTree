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

        internal T SearchForOneNode(Func<T, Value> callback, bool noEmptyValue = false)
        {
            return SearchForOneNode(Root, callback, noEmptyValue);
        }

        internal void TraverseAllNodes(Action<T, int> callback)
        {
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

        T SearchForOneNode(Node<T> node, Func<T, Value> callback, bool noEmptyValue)
        {
            var result = callback(node.Value);

            if (IsValueEqual(result))
                return node.Value;

            if (IsValueSmaller(result) && IsLeftNodeNotNull(node))
                return SearchForOneNode(node.Left, callback, noEmptyValue);

            if (IsValueBigger(result) && IsRightNodeNotNull(node))
                return SearchForOneNode(node.Right, callback, noEmptyValue);

            return noEmptyValue == true ? node.Value : default(T);
        }

        void TraverseAllNodes(Node<T> node, Action<T, int> callback, int level)
        {
            if (IsLeftNodeNotNull(node))
                TraverseAllNodes(node.Left, callback, level + 1);

            callback(node.Value, level);

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
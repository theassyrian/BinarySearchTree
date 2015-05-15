using System;

namespace BinarySearchTree
{
    public static class BinarySearchTreeExtensions
    {
        public static T Max<T>(this BinarySearchTree<T> _this)
            where T : IComparable<T>
        {
            var node = _this.SearchForOneNode(v => Value.IsBigger, true);

            return node.Value;
        }

        public static T Min<T>(this BinarySearchTree<T> _this)
            where T : IComparable<T>
        {
            var node = _this.SearchForOneNode(v => Value.IsSmaller, true);

            return node.Value;
        }

        public static bool Exists<T>(this BinarySearchTree<T> _this, T value)
            where T : IComparable<T>
        {
            bool exists = false;

            _this.SearchForOneNode(n =>
            {
                var result = (Value)value.CompareTo(n.Value);
                exists = result == Value.IsEqual;
                return result;
            });

            return exists;
        }

        public static int Size<T>(this BinarySearchTree<T> _this)
            where T : IComparable<T>
        {
            int count = 0;
            _this.TraverseAllNodes((v, l) => count++);
            return count;
        }
    }
}

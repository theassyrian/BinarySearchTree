using System;

namespace BinarySearchTree
{
    public static class BinarySearchTreeExtensions
    {
        public static T Max<T>(this BinarySearchTree<T> _this)
            where T : IComparable<T>
        {
            return _this.SearchForOneNode(v => Value.IsBigger, true);
        }

        public static T Min<T>(this BinarySearchTree<T> _this)
            where T : IComparable<T>
        {
            return _this.SearchForOneNode(v => Value.IsSmaller, true);
        }

        public static bool Exists<T>(this BinarySearchTree<T> _this, T value)
            where T : IComparable<T>
        {
            bool exists = false;

            _this.SearchForOneNode(v =>
            {
                var result = (Value)value.CompareTo(v);
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

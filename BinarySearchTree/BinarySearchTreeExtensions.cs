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

        public static int Size<T>(this BinarySearchTree<T> _this)
            where T : IComparable<T>
        {
            int count = 0;
            _this.TraverseAllNodes((v, l) => count++);
            return count;
        }
    }
}

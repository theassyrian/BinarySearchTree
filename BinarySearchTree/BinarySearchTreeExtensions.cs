using System;

namespace BinarySearchTree
{
    public static class BinarySearchTreeExtensions
    {
        public static V Max<K, V>(this BinarySearchTree<K, V> _this)
            where K : IComparable<K>
        {
            var node = _this.SearchForOneNode(v => Key.IsBigger, true);

            return node.Value;
        }

        public static V Min<K, V>(this BinarySearchTree<K, V> _this)
            where K : IComparable<K>
        {
            var node = _this.SearchForOneNode(v => Key.IsSmaller, true);

            return node.Value;
        }

        public static bool Exists<K, V>(this BinarySearchTree<K, V> _this, K key)
            where K : IComparable<K>
        {
            bool exists = false;

            _this.SearchForOneNode(n =>
            {
                var result = (Key)key.CompareTo(n.Key);
                exists = result == Key.IsEqual;
                return result;
            });

            return exists;
        }

        public static int Size<K, V>(this BinarySearchTree<K, V> _this)
            where K : IComparable<K>
        {
            int count = 0;
            _this.TraverseAllNodes((n, l) => count++);
            return count;
        }
    }
}

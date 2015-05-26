using System;

using Xunit;

using BinarySearchTree.Data;

namespace BinarySearchTree.UnitTests.Helpers
{
    public static class NodeAssert
    {
        public static void NotNullAndEqual<K, V>(Node<K, V> node, K expectedKey, V expectedValue)
            where K : IComparable<K>
        {
            Assert.NotNull(node);
            Assert.Equal(expectedKey, node.Key);
            Assert.Equal(expectedValue, node.Value);
        }

        public static void NotNullAndEqual<K, V>(Node<K, V> node, Node<K, V> expectedNode)
            where K : IComparable<K>
        {
            Assert.NotNull(node);
            Assert.NotNull(expectedNode);
            Assert.Equal(expectedNode.Key, node.Key);
            Assert.Equal(expectedNode.Value, node.Value);
        }

        public static void BothChildrenAreNull<K, V>(Node<K, V> node)
            where K : IComparable<K>
        {
            Assert.NotNull(node);
            Assert.Null(node.Left);
            Assert.Null(node.Right);
        }

        public static void BothChildrenAreNotNull<K, V>(Node<K, V> node)
            where K : IComparable<K>
        {
            Assert.NotNull(node);
            Assert.NotNull(node.Left);
            Assert.NotNull(node.Right);
        }

        public static void LeftChildIsNull<K, V>(Node<K, V> node)
            where K : IComparable<K>
        {
            Assert.NotNull(node);
            Assert.Null(node.Left);
            Assert.NotNull(node.Right);
        }

        public static void RightChildIsNull<K, V>(Node<K, V> node)
            where K : IComparable<K>
        {
            Assert.NotNull(node);
            Assert.NotNull(node.Left);
            Assert.Null(node.Right);
        }
    }
}

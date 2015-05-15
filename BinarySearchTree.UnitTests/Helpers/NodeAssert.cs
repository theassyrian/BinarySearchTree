using System;

using Xunit;

using BinarySearchTree.Data;

namespace BinarySearchTree.UnitTests.Helpers
{
    public static class NodeAssert
    {
        public static void NotNullAndValueEqual<T>(Node<T> node, T expectedValue)
            where T : IComparable<T>
        {
            Assert.NotNull(node);
            Assert.Equal(expectedValue, node.Value);
        }

        public static void BothChildrenAreNull<T>(Node<T> node)
            where T : IComparable<T>
        {
            Assert.NotNull(node);
            Assert.Null(node.Left);
            Assert.Null(node.Right);
        }

        public static void BothChildrenAreNotNull<T>(Node<T> node)
            where T : IComparable<T>
        {
            Assert.NotNull(node);
            Assert.NotNull(node.Left);
            Assert.NotNull(node.Right);
        }

        public static void LeftChildIsNull<T>(Node<T> node)
            where T : IComparable<T>
        {
            Assert.NotNull(node);
            Assert.Null(node.Left);
            Assert.NotNull(node.Right);
        }

        public static void RightChildIsNull<T>(Node<T> node)
            where T : IComparable<T>
        {
            Assert.NotNull(node);
            Assert.NotNull(node.Left);
            Assert.Null(node.Right);
        }
    }
}

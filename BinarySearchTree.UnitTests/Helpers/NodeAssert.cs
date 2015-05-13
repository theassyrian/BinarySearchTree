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
    }
}

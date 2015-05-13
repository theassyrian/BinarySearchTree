using Xunit;

using BinarySearchTree.UnitTests.Repositories;

namespace BinarySearchTree.UnitTests
{
    public class BinarySearchTreeExtensionsTests
    {
        [Fact]
        public void Max_FindBiggestElement_BiggestElement()
        {
            var bst = Repository.CreateTree();
            var element = bst.Max();

            Assert.Equal(Repository.BiggestElement, element);
        }

        [Fact]
        public void Min_FindSmallestElement_SmallestElement()
        {
            var bst = Repository.CreateTree();
            var element = bst.Max();

            Assert.Equal(Repository.BiggestElement, element);
        }

        [Fact]
        public void Size_MeasureSizeOfTree_Size()
        {
            var bst = Repository.CreateTree();
            var size = bst.Size();

            Assert.Equal(Repository.Size, size);
        }
    }
}

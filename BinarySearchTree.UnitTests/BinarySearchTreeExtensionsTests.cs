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
        public void Exists_CheckIfElementExists_ItExists()
        {
            var bst = Repository.CreateTree();

            var exists = bst.Exists(Repository.BiggestElement);

            Assert.True(exists);
        }

        [Fact]
        public void Exists_CheckIfElementExists_ItDoesntExist()
        {
            var bst = Repository.CreateTree();

            var exists = bst.Exists(Repository.NotAnElement);

            Assert.False(exists);
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

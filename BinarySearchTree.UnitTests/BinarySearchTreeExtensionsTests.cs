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
            var value = bst.Max();

            Assert.Equal(Repository.BiggestElement.Value, value);
        }

        [Fact]
        public void Min_FindSmallestElement_SmallestElement()
        {
            var bst = Repository.CreateTree();
            var value = bst.Max();

            Assert.Equal(Repository.BiggestElement.Value, value);
        }

        [Fact]
        public void Exists_CheckIfElementExists_ItExists()
        {
            var bst = Repository.CreateTree();

            var exists = bst.Exists(Repository.BiggestElement.Key);

            Assert.True(exists);
        }

        [Fact]
        public void Exists_CheckIfElementExists_ItDoesntExist()
        {
            var bst = Repository.CreateTree();

            var exists = bst.Exists(Repository.NotAnElement.Key);

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

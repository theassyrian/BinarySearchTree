using Xunit;

using BinarySearchTree.UnitTests.Repositories;

namespace BinarySearchTree.UnitTests
{
    public class BinarySearchTreeExtensionsTests
    {
        [Fact]
        public void Max_FindBiggestElement_BiggestElement()
        {
            var bst = SimpleTree.CreateTree();
            var value = bst.Max();

            Assert.Equal(SimpleTree.BiggestElement.Value, value);
        }

        [Fact]
        public void Min_FindSmallestElement_SmallestElement()
        {
            var bst = SimpleTree.CreateTree();
            var value = bst.Max();

            Assert.Equal(SimpleTree.BiggestElement.Value, value);
        }

        [Fact]
        public void Exists_CheckIfElementExists_ItExists()
        {
            var bst = SimpleTree.CreateTree();

            var exists = bst.Exists(SimpleTree.BiggestElement.Key);

            Assert.True(exists);
        }

        [Fact]
        public void Exists_CheckIfElementExists_ItDoesntExist()
        {
            var bst = SimpleTree.CreateTree();

            var exists = bst.Exists(SimpleTree.NotAnElement.Key);

            Assert.False(exists);
        }

        [Fact]
        public void Size_MeasureSizeOfTree_Size()
        {
            var bst = SimpleTree.CreateTree();
            var size = bst.Size();

            Assert.Equal(SimpleTree.Size, size);
        }

        Repository SimpleTree
        {
            get { return Repository.SimpleTree; }
        }
    }
}

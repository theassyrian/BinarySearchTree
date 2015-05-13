using System.Collections.Generic;

using Xunit;

using BinarySearchTree.UnitTests.Helpers;
using BinarySearchTree.UnitTests.Repositories;

namespace BinarySearchTree.UnitTests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void Insert_InsertFirstItem_TreeContainsOneItem()
        {
            var firstValue = 1;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
        }

        [Fact]
        public void Insert_InsertSecondSamllerItem_TreeContainsTwoItems()
        {
            var firstValue = 2;
            var secondValue = 1;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Left, secondValue);
        }

        [Fact]
        public void Insert_InsertSecondBiggerItem_TreeContainsTwoItems()
        {
            var firstValue = 2;
            var secondValue = 3;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Right, secondValue);
        }

        [Fact]
        public void Insert_InsertTwoSamllerItems_TreeContainsTwoItems()
        {
            var firstValue = 3;
            var secondValue = 2;
            var thirdValue = 1;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);
            bst.Insert(thirdValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Left, secondValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Left.Left, thirdValue);
        }

        [Fact]
        public void Insert_InsertTwoBiggerItems_TreeContainsTwoItems()
        {
            var firstValue = 1;
            var secondValue = 2;
            var thirdValue = 3;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);
            bst.Insert(thirdValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Right, secondValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Right.Right, thirdValue);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheLeftPath_DefaultElement()
        {
            var bst = Repository.CreateTree();

            var value = bst.SearchForOneNode(v => Value.IsSmaller);

            Assert.Equal(Repository.DefaultElement, value);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheRightPath_DefaultElement()
        {
            var bst = Repository.CreateTree();

            var value = bst.SearchForOneNode(v => Value.IsBigger);

            Assert.Equal(Repository.DefaultElement, value);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheLeftPathNoEmptyValue_SmallestElement()
        {
            var bst = Repository.CreateTree();

            var value = bst.SearchForOneNode(v => Value.IsSmaller, true);

            Assert.Equal(Repository.SmallestElement, value);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheRightPathNoEmptyValue_BiggestElement()
        {
            var bst = Repository.CreateTree();

            var value = bst.SearchForOneNode(v => Value.IsBigger, true);

            Assert.Equal(Repository.BiggestElement, value);
        }

        [Fact]
        public void SearchForOneNode_AcceptRootElement_RootElement()
        {
            var bst = Repository.CreateTree();

            var value = bst.SearchForOneNode(v => Value.IsEqual);

            Assert.Equal(Repository.RootElement, value);
        }

        [Fact]
        public void TraverseAllNodes_WalksTroughAllElements()
        {
            var bst = Repository.CreateTree();

            List<int> elements = new List<int>();
            bst.TraverseAllNodes((v, l) => elements.Add(v));

            Assert.Equal(Repository.Size, elements.Count);
            Assert.All(elements, elem => Repository.TreeContains(elem));
        }
    }
}

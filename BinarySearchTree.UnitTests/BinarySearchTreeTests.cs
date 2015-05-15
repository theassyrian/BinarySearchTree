using System;
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
        public void Remove_RemoveFromAnEmptyTree_NoExceptions()
        {
            var emptyTree = new BinarySearchTree<int>();

            emptyTree.Remove(Repository.NotAnElement);
        }

        [Fact]
        public void Remove_TheRootElement_EmptyTree()
        {
            var rootElement = Repository.RootElement;
            var bst = new BinarySearchTree<int>();
            bst.Insert(rootElement);

            bst.Remove(rootElement);

            Assert.Null(bst.Root);
        }

        [Fact]
        public void Remove_TheRootElementWithLeftChild_NewRootIsTheLeftChild()
        {
            var firstValue = 2;
            var secondValue = 1;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);

            bst.Remove(firstValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, secondValue);
            NodeAssert.BothChildrenAreNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRootElementWithRightChild_NewRootIsTheRightChild()
        {
            var firstValue = 2;
            var secondValue = 3;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);

            bst.Remove(firstValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, secondValue);
            NodeAssert.BothChildrenAreNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRootElementWithBothChild_NewRootIsTheRightChild()
        {
            var firstValue = 2;
            var secondValue = 1;
            var thirdValue = 3;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);
            bst.Insert(thirdValue);

            bst.Remove(firstValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, thirdValue);
            NodeAssert.RightChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheLeftChildWithNoChildren_TheRootWithNoChildren()
        {
            var firstValue = 2;
            var secondValue = 1;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);

            bst.Remove(secondValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.BothChildrenAreNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRightChildWithNoChildren_TheRootWithNoChildren()
        {
            var firstValue = 2;
            var secondValue = 3;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);

            bst.Remove(secondValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.BothChildrenAreNull(bst.Root);
        }

        [Fact]
        public void Remove_TheLeftChildWithLeftChild_TheRootWithWithLeftChild()
        {
            var firstValue = 3;
            var secondValue = 2;
            var thirdValue = 1;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);
            bst.Insert(thirdValue);

            bst.Remove(secondValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Left, thirdValue);
            NodeAssert.RightChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheLeftChildWithRightChild_TheRootWithWithLeftChild()
        {
            var firstValue = 4;
            var secondValue = 2;
            var thirdValue = 3;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);
            bst.Insert(thirdValue);

            bst.Remove(secondValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Left, thirdValue);
            NodeAssert.RightChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRightChildWithRightChild_TheRootWithWithRightChild()
        {
            var firstValue = 1;
            var secondValue = 2;
            var thirdValue = 3;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);
            bst.Insert(thirdValue);

            bst.Remove(secondValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Right, thirdValue);
            NodeAssert.LeftChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRightChildWithLeftChild_TheRootWithWithRightChild()
        {
            var firstValue = 1;
            var secondValue = 3;
            var thirdValue = 2;

            var bst = new BinarySearchTree<int>();
            bst.Insert(firstValue);
            bst.Insert(secondValue);
            bst.Insert(thirdValue);

            bst.Remove(secondValue);

            NodeAssert.NotNullAndValueEqual(bst.Root, firstValue);
            NodeAssert.NotNullAndValueEqual(bst.Root.Right, thirdValue);
            NodeAssert.LeftChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRootFromAComplexTree_TheCorrectTree()
        {
            var bst = Repository.CreateTree();

            bst.Remove(Repository.RootElement);

            NodeAssert.NotNullAndValueEqual(bst.Root, 5);
            NodeAssert.BothChildrenAreNotNull(bst.Root);

            NodeAssert.NotNullAndValueEqual(bst.Root.Right, Repository.SecondBiggestElement);
            NodeAssert.LeftChildIsNull(bst.Root.Right);

            NodeAssert.NotNullAndValueEqual(bst.Root.Left, Repository.SecondSmallestElement);
            NodeAssert.BothChildrenAreNotNull(bst.Root.Left);
        }

        [Fact]
        public void SearchForOneNode_InEmptyTree_NoSuchNode()
        {
            var emptyTree = new BinarySearchTree<int>();

            var node = emptyTree.SearchForOneNode(v => Value.IsEqual);

            Assert.Null(node);
        }

        [Fact]
        public void SearchForOneNode_ThrowsOnNullCallback_Exception()
        {
            var emptyTree = Repository.CreateTree();

            Assert.Throws<ArgumentNullException>(() => emptyTree.SearchForOneNode(null));
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheLeftPath_NoSuchNode()
        {
            var bst = Repository.CreateTree();

            var node = bst.SearchForOneNode(v => Value.IsSmaller);

            Assert.Null(node);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheRightPath_NoSuchNode()
        {
            var bst = Repository.CreateTree();

            var node = bst.SearchForOneNode(v => Value.IsBigger);

            Assert.Null(node);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheLeftPathNoEmptyValue_SmallestElement()
        {
            var bst = Repository.CreateTree();

            var node = bst.SearchForOneNode(v => Value.IsSmaller, true);

            Assert.Equal(Repository.SmallestElement, node.Value);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheRightPathNoEmptyValue_BiggestElement()
        {
            var bst = Repository.CreateTree();

            var node = bst.SearchForOneNode(v => Value.IsBigger, true);

            Assert.Equal(Repository.BiggestElement, node.Value);
        }

        [Fact]
        public void SearchForOneNode_AcceptRootElement_RootElement()
        {
            var bst = Repository.CreateTree();

            var node = bst.SearchForOneNode(v => Value.IsEqual);

            Assert.Equal(Repository.RootElement, node.Value);
        }

        [Fact]
        public void TraverseAllNodes_InEmptyTree_NoExceptions()
        {
            var emptyTree = new BinarySearchTree<int>();

            emptyTree.TraverseAllNodes((v, l) => { });
        }

        [Fact]
        public void TraverseAllNodes_ThrowsOnNullCallback_Exception()
        {
            var emptyTree = Repository.CreateTree();

            Assert.Throws<ArgumentNullException>(() => emptyTree.TraverseAllNodes(null));
        }

        [Fact]
        public void TraverseAllNodes_WalksTroughAllElements()
        {
            var bst = Repository.CreateTree();

            List<int> elements = new List<int>();
            bst.TraverseAllNodes((n, l) => elements.Add(n.Value));

            Assert.Equal(Repository.Size, elements.Count);
            Assert.All(elements, elem => Repository.TreeContains(elem));
        }
    }
}

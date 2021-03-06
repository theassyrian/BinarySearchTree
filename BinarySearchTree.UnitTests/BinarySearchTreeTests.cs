﻿using System;
using System.Collections.Generic;

using Xunit;

using BinarySearchTree.UnitTests.Helpers;
using BinarySearchTree.UnitTests.Repositories;

using BinarySearchTree.Data;
using Bst = BinarySearchTree;

namespace BinarySearchTree.UnitTests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void Insert_InsertFirstItem_TreeContainsOneItem()
        {
            var firstNode = 1;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
        }

        [Fact]
        public void Insert_InsertSecondSamllerItem_TreeContainsTwoItems()
        {
            var firstNode = 2;
            var secondNode = 1;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.NotNullAndEqual(bst.Root.Left, Node(secondNode));
        }

        [Fact]
        public void Insert_InsertSecondBiggerItem_TreeContainsTwoItems()
        {
            var firstNode = 2;
            var secondNode = 3;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.NotNullAndEqual(bst.Root.Right, Node(secondNode));
        }

        [Fact]
        public void Insert_InsertTwoSamllerItems_TreeContainsTwoItems()
        {
            var firstNode = 3;
            var secondNode = 2;
            var thirdNode = 1;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));
            bst.Insert(Key(thirdNode), Value(thirdNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.NotNullAndEqual(bst.Root.Left, Node(secondNode));
            NodeAssert.NotNullAndEqual(bst.Root.Left.Left, Node(thirdNode));
        }

        [Fact]
        public void Insert_InsertTwoBiggerItems_TreeContainsTwoItems()
        {
            var firstNode = 1;
            var secondNode = 2;
            var thirdNode = 3;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));
            bst.Insert(Key(thirdNode), Value(thirdNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.NotNullAndEqual(bst.Root.Right, Node(secondNode));
            NodeAssert.NotNullAndEqual(bst.Root.Right.Right, Node(thirdNode));
        }

        [Fact]
        public void IndexedProperty_Get_TheRootElement()
        {
            var bst = SimpleTree.Create();

            var value = bst[SimpleTree.RootElement.Key];

            Assert.Equal(SimpleTree.RootElement.Value, value);
        }

        [Fact]
        public void IndexedProperty_Get_TheLeftElement()
        {
            var bst = SimpleTree.Create();

            var value = bst[SimpleTree.SmallestElement.Key];

            Assert.Equal(SimpleTree.SmallestElement.Value, value);
        }

        [Fact]
        public void IndexedProperty_Get_TheRightElement()
        {
            var bst = SimpleTree.Create();

            var value = bst[SimpleTree.BiggestElement.Key];

            Assert.Equal(SimpleTree.BiggestElement.Value, value);
        }

        [Fact]
        public void IndexedProperty_TryGetANotAnElement_DefaultValue()
        {
            var bst = SimpleTree.Create();

            var value = bst[SimpleTree.NotExistingElement.Key];

            Assert.Equal(default(int), value);
        }

        [Fact]
        public void Remove_RemoveFromAnEmptyTree_NoExceptions()
        {
            var notAnElement = SimpleTree.NotExistingElement;
            var emptyTree = new BinarySearchTree<int, int>();

            emptyTree.Remove(notAnElement.Key);
        }

        [Fact]
        public void Remove_TheRootElement_EmptyTree()
        {
            var firstNode = 1;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));

            bst.Remove(Key(firstNode));

            Assert.Null(bst.Root);
        }

        [Fact]
        public void Remove_TheRootElementWithLeftChild_NewRootIsTheLeftChild()
        {
            var firstNode = 2;
            var secondNode = 1;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));

            bst.Remove(Key(firstNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(secondNode));
            NodeAssert.BothChildrenAreNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRootElementWithRightChild_NewRootIsTheRightChild()
        {
            var firstNode = 2;
            var secondNode = 3;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));

            bst.Remove(Key(firstNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(secondNode));
            NodeAssert.BothChildrenAreNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRootElementWithBothChild_NewRootIsTheRightChild()
        {
            var firstNode = 2;
            var secondNode = 1;
            var thirdNode = 3;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));
            bst.Insert(Key(thirdNode), Value(thirdNode));

            bst.Remove(Key(firstNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(thirdNode));
            NodeAssert.RightChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheLeftChildWithNoChildren_TheRootWithNoChildren()
        {
            var firstNode = 2;
            var secondNode = 1;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));

            bst.Remove(Key(secondNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.BothChildrenAreNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRightChildWithNoChildren_TheRootWithNoChildren()
        {
            var firstNode = 2;
            var secondNode = 3;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));

            bst.Remove(Key(secondNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.BothChildrenAreNull(bst.Root);
        }

        [Fact]
        public void Remove_TheLeftChildWithLeftChild_TheRootWithWithLeftChild()
        {
            var firstNode = 3;
            var secondNode = 2;
            var thirdNode = 1;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));
            bst.Insert(Key(thirdNode), Value(thirdNode));

            bst.Remove(Key(secondNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.NotNullAndEqual(bst.Root.Left, Node(thirdNode));
            NodeAssert.RightChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheLeftChildWithRightChild_TheRootWithWithLeftChild()
        {
            var firstNode = 4;
            var secondNode = 2;
            var thirdNode = 3;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));
            bst.Insert(Key(thirdNode), Value(thirdNode));

            bst.Remove(Key(secondNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.NotNullAndEqual(bst.Root.Left, Node(thirdNode));
            NodeAssert.RightChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRightChildWithRightChild_TheRootWithWithRightChild()
        {
            var firstNode = 1;
            var secondNode = 2;
            var thirdNode = 3;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));
            bst.Insert(Key(thirdNode), Value(thirdNode));

            bst.Remove(Key(secondNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.NotNullAndEqual(bst.Root.Right, Node(thirdNode));
            NodeAssert.LeftChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRightChildWithLeftChild_TheRootWithWithRightChild()
        {
            var firstNode = 1;
            var secondNode = 3;
            var thirdNode = 2;

            var bst = new BinarySearchTree<int, int>();
            bst.Insert(Key(firstNode), Value(firstNode));
            bst.Insert(Key(secondNode), Value(secondNode));
            bst.Insert(Key(thirdNode), Value(thirdNode));

            bst.Remove(Key(secondNode));

            NodeAssert.NotNullAndEqual(bst.Root, Node(firstNode));
            NodeAssert.NotNullAndEqual(bst.Root.Right, Node(thirdNode));
            NodeAssert.LeftChildIsNull(bst.Root);
        }

        [Fact]
        public void Remove_TheRootFromATwoLevelTree_TheCorrectTree()
        {
            var rootNode = SimpleTree.RootElement;
            var bst = SimpleTree.Create();

            bst.Remove(rootNode.Key);

            NodeAssert.NotNullAndEqual(bst.Root, Node(5));
            NodeAssert.BothChildrenAreNotNull(bst.Root);

            NodeAssert.NotNullAndEqual(bst.Root.Right, SimpleTree.SecondBiggestElement);
            NodeAssert.LeftChildIsNull(bst.Root.Right);

            NodeAssert.NotNullAndEqual(bst.Root.Left, SimpleTree.SecondSmallestElement);
            NodeAssert.BothChildrenAreNotNull(bst.Root.Left);
        }

        [Fact]
        public void Remove_ANotExistingElementFromATwoLevelTree_TheCorrectTree()
        {
            var notExistingNode = SimpleTree.NotExistingElement;
            var bst = SimpleTree.Create();

            bst.Remove(notExistingNode.Key);

            NodeAssert.NotNullAndEqual(bst.Root, SimpleTree.RootElement);
            NodeAssert.BothChildrenAreNotNull(bst.Root);

            NodeAssert.NotNullAndEqual(bst.Root.Right, SimpleTree.SecondBiggestElement);
            NodeAssert.BothChildrenAreNotNull(bst.Root.Right);

            NodeAssert.NotNullAndEqual(bst.Root.Left, SimpleTree.SecondSmallestElement);
            NodeAssert.BothChildrenAreNotNull(bst.Root.Left);
        }

        [Fact]
        public void Remove_TheRootFromAThreeLevelTree_TheCorrectTree()
        {
            var firstNode = Node(9);
            var rootNode = ComplexTree.RootElement;
            var bst = ComplexTree.Create();

            bst.Remove(firstNode.Key);
            bst.Remove(rootNode.Key);

            NodeAssert.NotNullAndEqual(bst.Root, Node(10));
            NodeAssert.BothChildrenAreNotNull(bst.Root);

            NodeAssert.NotNullAndEqual(bst.Root.Right, Node(12));
            NodeAssert.BothChildrenAreNotNull(bst.Root.Right);
            NodeAssert.BothChildrenAreNull(bst.Root.Right.Left);
            NodeAssert.BothChildrenAreNotNull(bst.Root.Right.Right);

            NodeAssert.NotNullAndEqual(bst.Root.Left, Node(4));
            NodeAssert.BothChildrenAreNotNull(bst.Root.Left);
            NodeAssert.BothChildrenAreNotNull(bst.Root.Left.Left);
            NodeAssert.BothChildrenAreNotNull(bst.Root.Left.Right);
        }

        [Fact]
        public void SearchForOneNode_InEmptyTree_NoSuchNode()
        {
            var emptyTree = new BinarySearchTree<int, int>();

            var node = emptyTree.SearchForOneNode(v => Bst.Key.IsEqual);

            Assert.Null(node);
        }

        [Fact]
        public void SearchForOneNode_ThrowsOnNullCallback_Exception()
        {
            var emptyTree = SimpleTree.Create();

            Assert.Throws<ArgumentNullException>(() => emptyTree.SearchForOneNode(null));
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheLeftPath_NoSuchNode()
        {
            var bst = SimpleTree.Create();

            var node = bst.SearchForOneNode(v => Bst.Key.IsSmaller);

            Assert.Null(node);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheRightPath_NoSuchNode()
        {
            var bst = SimpleTree.Create();

            var node = bst.SearchForOneNode(v => Bst.Key.IsBigger);

            Assert.Null(node);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheLeftPathNoEmptyValue_SmallestElement()
        {
            var bst = SimpleTree.Create();

            var node = bst.SearchForOneNode(v => Bst.Key.IsSmaller, true);

            NodeAssert.NotNullAndEqual(SimpleTree.SmallestElement, node);
        }

        [Fact]
        public void SearchForOneNode_WalkThroughTheRightPathNoEmptyValue_BiggestElement()
        {
            var bst = SimpleTree.Create();

            var node = bst.SearchForOneNode(v => Bst.Key.IsBigger, true);

            NodeAssert.NotNullAndEqual(SimpleTree.BiggestElement, node);
        }

        [Fact]
        public void SearchForOneNode_AcceptRootElement_RootElement()
        {
            var bst = SimpleTree.Create();

            var node = bst.SearchForOneNode(v => Bst.Key.IsEqual);

            NodeAssert.NotNullAndEqual(SimpleTree.RootElement, node);
        }

        [Fact]
        public void TraverseAllNodes_InEmptyTree_NoExceptions()
        {
            var emptyTree = new BinarySearchTree<int, int>();

            emptyTree.TraverseAllNodes((v, l) => { });
        }

        [Fact]
        public void TraverseAllNodes_ThrowsOnNullCallback_Exception()
        {
            var emptyTree = SimpleTree.Create();

            Assert.Throws<ArgumentNullException>(() => emptyTree.TraverseAllNodes(null));
        }

        [Fact]
        public void TraverseAllNodes_WalksTroughAllElements()
        {
            var bst = SimpleTree.Create();

            List<int> elements = new List<int>();
            bst.TraverseAllNodes((n, l) => elements.Add(n.Value));

            Assert.Equal(SimpleTree.Size, elements.Count);
            Assert.All(elements, elem => SimpleTree.TreeContains(elem));
        }

        Node<int, int> Node(int number)
        {
            return NodeHelper.Create(number);
        }

        int Key(int number)
        {
            return NodeHelper.Key(number);
        }

        int Value(int number)
        {
            return NodeHelper.Value(number);
        }

        Repository SimpleTree
        {
            get { return Repository.SimpleTree; }
        }

        Repository ComplexTree
        {
            get { return Repository.ComplexTree; }
        }
    }
}

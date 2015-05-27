using System.Linq;

using BinarySearchTree.UnitTests.Helpers;

using BinarySearchTree.Data;

namespace BinarySearchTree.UnitTests.Repositories
{
    public class Repository
    {
        public static readonly Repository ComplexTree = new Repository { Elements = new[] { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 } };
        public static readonly Repository SimpleTree = new Repository { Elements = new[] { 4, 2, 6, 1, 3, 5, 7 } };

        int[] Elements;

        public int Size
        {
            get { return Elements.Count(); }
        }

        public Node<int, int> SmallestElement
        {
            get { return NodeHelper.Create(Elements.Min()); }
        }

        public Node<int, int> SecondSmallestElement
        {
            get { return NodeHelper.Create(Elements.Where(e => SmallestElement.Key != NodeHelper.Key(e)).Min()); }
        }

        public Node<int, int> RootElement
        {
            get { return NodeHelper.Create(Elements.First()); }
        }

        public Node<int, int> BiggestElement
        {
            get { return NodeHelper.Create(Elements.Max()); }
        }

        public Node<int, int> SecondBiggestElement
        {
            get { return NodeHelper.Create(Elements.Where(e => BiggestElement.Key != NodeHelper.Key(e)).Max()); }
        }

        public Node<int, int> NotAnElement
        {
            get { return NodeHelper.Create(0); }
        }

        public bool TreeContains(int element)
        {
            return Elements.Contains(element);
        }

        public BinarySearchTree<int, int> Create()
        {
            var bst = new BinarySearchTree<int, int>();
            foreach (var elem in Elements)
            {
                bst.Insert(NodeHelper.Key(elem), NodeHelper.Value(elem));
            }

            return bst;
        }
    }
}

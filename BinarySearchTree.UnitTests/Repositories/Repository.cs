using System.Linq;

using BinarySearchTree.UnitTests.Helpers;

using BinarySearchTree.Data;

namespace BinarySearchTree.UnitTests.Repositories
{
    public class Repository
    {
        static readonly int[] Elements = { 4, 2, 6, 1, 3, 5, 7 };

        public static int Size
        {
            get { return Elements.Count(); }
        }

        public static Node<int, int> SmallestElement
        {
            get { return NodeHelper.Create(Elements.Min()); }
        }

        public static Node<int, int> SecondSmallestElement
        {
            get { return NodeHelper.Create(Elements.Where(e => SmallestElement.Key != NodeHelper.Key(e)).Min()); }
        }

        public static Node<int, int> RootElement
        {
            get { return NodeHelper.Create(Elements.First()); }
        }

        public static Node<int, int> BiggestElement
        {
            get { return NodeHelper.Create(Elements.Max()); }
        }

        public static Node<int, int> SecondBiggestElement
        {
            get { return NodeHelper.Create(Elements.Where(e => BiggestElement.Key != NodeHelper.Key(e)).Max()); }
        }

        public static Node<int, int> NotAnElement
        {
            get { return NodeHelper.Create(0); }
        }

        public static bool TreeContains(int element)
        {
            return Elements.Contains(element);
        }

        public static BinarySearchTree<int, int> CreateTree()
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

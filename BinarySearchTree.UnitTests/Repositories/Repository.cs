using System.Linq;

namespace BinarySearchTree.UnitTests.Repositories
{
    public class Repository
    {
        static readonly int[] Elements = { 4, 2, 6, 1, 3, 5, 7 };

        public static int Size
        {
            get { return Elements.Count(); }
        }

        public static int SmallestElement
        {
            get { return Elements.Min(); }
        }

        public static int SecondSmallestElement
        {
            get { return Elements.Where(e => e.CompareTo(SmallestElement) != 0).Min(); }
        }

        public static int RootElement
        {
            get { return Elements.First(); }
        }

        public static int BiggestElement
        {
            get { return Elements.Max(); }
        }

        public static int SecondBiggestElement
        {
            get { return Elements.Where(e => e.CompareTo(BiggestElement) != 0).Max(); }
        }

        public static int NotAnElement
        {
            get { return 0; }
        }

        public static bool TreeContains(int element)
        {
            return Elements.Contains(element);
        }

        public static BinarySearchTree<int> CreateTree()
        {
            var bst = new BinarySearchTree<int>();
            foreach (var elem in Elements)
            {
                bst.Insert(elem);
            }

            return bst;
        }
    }
}

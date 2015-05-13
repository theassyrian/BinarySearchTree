using System.Linq;

namespace BinarySearchTree.UnitTests.Repositories
{
    public class Repository
    {
        static readonly int[] Elements = { 4, 3, 6, 1, 2, 5, 7 };

        public static int Size
        {
            get { return Elements.Count(); }
        }

        public static int DefaultElement
        {
            get { return default(int); }
        }

        public static int SmallestElement
        {
            get { return Elements.Min(); }
        }

        public static int RootElement
        {
            get { return Elements.First(); }
        }

        public static int BiggestElement
        {
            get { return Elements.Max(); }
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

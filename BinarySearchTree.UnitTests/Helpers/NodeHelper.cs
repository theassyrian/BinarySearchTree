using BinarySearchTree.Data;

namespace BinarySearchTree.UnitTests.Helpers
{
    public static class NodeHelper
    {
        public static Node<int, int> Create(int number)
        {
            return new Node<int, int> { Key = Key(number), Value = Value(number) };
        }

        public static int Key(int number)
        {
            return number * 10;
        }

        public static int Value(int number)
        {
            return number * 100;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BinarySearchTree;

namespace BinarySearchTree.Examples
{
    class Example01
    {
        static void Main(string[] args)
        {
            new Example01().Execute();
        }

        void Execute()
        {
            var bst = new BinarySearchTree<int, string>();
            bst.Insert(1, "Ben");
            bst.Insert(2, "Adam");
            bst.Insert(3, "Tom");

            Console.WriteLine("{0}", bst[1]);
            Console.WriteLine("{0}", bst[2]);
            Console.WriteLine("{0}", bst[3]);
        }
    }
}

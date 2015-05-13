using System;
using System.IO;
using System.Xml.Serialization;

using BinarySearchTree.Data;

namespace BinarySearchTree
{
    public class BinarySearchTreeSerializer<T>
        where T : IComparable<T>
    {
        public BinarySearchTree<T> LoadFrom(string filePath)
        {
            var serializer = new XmlSerializer(typeof(Node<T>));

            using (var fileStream = new FileStream(filePath, FileMode.Open))
                return new BinarySearchTree<T> { Root = (Node<T>)serializer.Deserialize(fileStream) };
        }

        public void SaveTo(string filePath, BinarySearchTree<T> tree)
        {
            var serializer = new XmlSerializer(typeof(Node<T>));

            using (var fileStream = new FileStream(filePath, FileMode.Create))
                serializer.Serialize(fileStream, tree.Root);
        }
    }
}

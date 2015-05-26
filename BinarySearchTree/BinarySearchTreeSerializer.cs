using System;
using System.IO;
using System.Xml.Serialization;

using BinarySearchTree.Data;

namespace BinarySearchTree
{
    public class BinarySearchTreeSerializer<K, V>
        where K : IComparable<K>
    {
        public BinarySearchTree<K, V> LoadFrom(string filePath)
        {
            var serializer = new XmlSerializer(typeof(Node<K, V>));

            using (var fileStream = new FileStream(filePath, FileMode.Open))
                return new BinarySearchTree<K, V> { Root = (Node<K, V>)serializer.Deserialize(fileStream) };
        }

        public void SaveTo(string filePath, BinarySearchTree<K, V> tree)
        {
            var serializer = new XmlSerializer(typeof(Node<K, V>));

            using (var fileStream = new FileStream(filePath, FileMode.Create))
                serializer.Serialize(fileStream, tree.Root);
        }
    }
}

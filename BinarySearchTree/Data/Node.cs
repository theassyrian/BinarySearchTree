using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinarySearchTree.Data
{
    [Serializable]
    public class Node<K, V>
    {
        [XmlElement]
        public Node<K, V> Left { get; set; }
        [XmlElement]
        public Node<K, V> Right { get; set; }
        [XmlElement]
        public K Key { get; set; }
        [XmlElement]
        public V Value { get; set; }
    }
}

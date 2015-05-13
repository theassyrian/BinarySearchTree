using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinarySearchTree.Data
{
    [Serializable]
    public class Node<T>
    {
        [XmlElement]
        public Node<T> Left { get; set; }
        [XmlElement]
        public Node<T> Right { get; set; }
        [XmlElement]
        public T Value { get; set; }
    }
}

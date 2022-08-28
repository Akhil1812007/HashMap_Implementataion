using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap_Implementataion
{
    public class MapNode<K, V>//FUNDAMENTAL UNIT OF HASHMAP
    {
        public K key;
        public V value;
        public MapNode<K,V> next;

        public MapNode(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }   
}

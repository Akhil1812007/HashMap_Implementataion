using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap_Implementataion
{
    //MAP IMPLEMENTED BY USING SEPARATE CHAINING
    public class Map<K,V>
    {
        List<MapNode<K,V>> buckets;
        int count;
        int numBuckets;
        public Map()
        {
            buckets = new List<MapNode<K,V>>();
            numBuckets = 5;
            for (int i = 0; i < numBuckets; i++)
            {
                buckets.Add(null);
            }
        }
        public double loadFactor()
        {
            return (1.0 * count) / numBuckets;
        }
        private int getBucketIndex(K Key)//GETTING THE HASHCODE TO DECIDE THE INDEX OF THE ELEMENT
        {
            int hc = Key.GetHashCode();
            int index = hc%numBuckets;
            if (index < 0)
            {
                index = -1 * index;
            }
            //--------------------Debbuging--------------
            //Console.WriteLine("get Bucket Index for  " + Key + " is " + index);
            //Console.WriteLine();

            return index;
        }
        public void insert(K Key, V Value)
        {
            int bucketIndex = getBucketIndex(Key);
            MapNode<K,V> head = buckets.ElementAt(bucketIndex);
            //element is  there  just update its value
            while (head!= null)
            {
                if (head.key.Equals(Key))
                {
                    head.value = Value;
                    return;
                }
                head = head.next;
            }
            // element is not there.insert at 0th position of linked list
            head = buckets.ElementAt(bucketIndex);
            MapNode<K,V> newNode = new MapNode<K,V>(Key,Value);
            count++;
            newNode.next = head;
            buckets.Insert(bucketIndex,newNode);
            //-------------------------------DEBUGGING----------------------
            //Console.WriteLine("insert "+newNode.key +" value "+newNode.value+ "Bucket Index is "+bucketIndex);//DEBUGGING
            //Console.WriteLine();    

            //Console.WriteLine("key "+newNode.key +"value "+newNode.value);//DEBUGGING

            double LoadingFactor = (1.0*count)/numBuckets;
            if (LoadingFactor > 0.75)
            {
                reHash();
            }
        }
        public int size()
        {
            return count;
        }
        public V getValue(K Key)// TO GET THE VALUE BASED ON A PARTICULAR KEY
        {
            int bucketIndex = getBucketIndex(Key);
            //-----------------DEBUGGING
            //Console.WriteLine("BucketIndex for "+Key+" is "+bucketIndex);
            //Console.WriteLine();
            MapNode<K, V> head = buckets.ElementAt(bucketIndex);
            //element is not there ? just update its value
            while (head != null)
            {
                if (head.key.Equals(Key))
                {
                    return head.value;
                    //---------------DEBUGGING----------
                    //Console.WriteLine("Element "+ head.key + " " + head.value);
                    //Console.WriteLine( " Key " + head.key + " value " + head.value+ "  BucketIndex at get value" + bucketIndex );//DEBUGGING
                    //Console.WriteLine();
                }
                head = head.next;
            }
            
            return default;

        }
        public V Remove(K Key)
        {
            int bucketIndex = getBucketIndex(Key);
            MapNode<K, V> head = buckets.ElementAt(bucketIndex);

            MapNode<K, V> prev = null;
            while (head != null)
            {
                if (head.key.Equals(Key))
                {
                    if(prev == null)
                    {
                        buckets.Insert(bucketIndex,head.next);

                    }
                    else
                    {
                        prev.next = head.next;
                    }
                    count--;
                    return head.value;

                }
                prev = head;
                head = head.next;
            }

            return default;
        }
        //REHASHING FOR MAINTAINING THE LOADING FACTOR  < 0.75
        private void reHash()
        {
            List<MapNode<K,V>> temp = buckets;
            //Console.WriteLine("count = "+temp.Count );---debugging
            
            buckets = new List<MapNode<K,V>>();
            for (int i = 0; i < 2*numBuckets; i++)
            {
                buckets.Add(null);
            }
            count = 0;
            numBuckets = numBuckets * 2;
            for (int i = 0; i <temp.Count; i++)
            {
                MapNode<K, V> head = temp.ElementAt(i);
                
                while (head != null)
                {
                   // Console.WriteLine("Element " + i + " " + head.key + " " + head.value);
                    K Key = head.key;
                    V value = head.value;
                    insert(Key,value);
                    head = head.next;
                }
            }
        }

    }


}
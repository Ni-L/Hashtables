using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{/// <summary>
/// Created Hashtable with key value
/// </summary>
/// <typeparam name="K"></typeparam>
/// <typeparam name="V"></typeparam>
    public class MyMapNode<K, V>
    {
        //Defines size of hastables
        //Adding member elements
        private readonly int size;
        //Creating an array named items whose datatype is linkedlist
        // Readonly struct declaration. 

        private readonly LinkedList<keyValue<K, V>>[] items;

        //Adding Method For size
        public MyMapNode(int size)
        {
            this.size = size;
            //array of linkedlist size is defined
            this.items = new LinkedList<keyValue<K, V>>[size];
        }

        //GetArrayPosition is method and passing key as parameter
        protected int GetArrayPosition(K key)
        {
            //hashcode is generated where the key value stores in Linked List
            //GetHashCode identifey the hashcode of this particular key
            int position = key.GetHashCode() % size;
            //Math.abs function To identify integer value and At what index this purticular keyvalue is present.
            return Math.Abs(position);
        }


        //  This method is used to retreive value from the hashtable, when key is passed.
        public V Get(K key)
        {

            int position = GetArrayPosition(key);
            //creating linked list with name linkedlist
            //identifying the position calling the getLinkedlist()
            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            //linkedlist contains all the key value pairs for which same hashcode was generated 
            //each key value pair in linkedlist is of data type keyValue (struct) defined at end of class
            foreach (keyValue<K, V> item in linkedList)
            {
                //if key element matches with the key in linkedlist, value is retuned

                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        //method and GetLinkedList having return type is Linkedlist keyvalue pair which is define line no13
        protected LinkedList<keyValue<K, V>> GetLinkedList(int position)
        {

            //position helps to findout the linkedlist in which key value pair will be inserted
            //calling the dictionary from which element is to be removed.
            LinkedList<keyValue<K, V>> linkedList = items[position];

            if (linkedList == null)
            {
                linkedList = new LinkedList<keyValue<K, V>>();
                //adding a linkedlist in the given array position
                items[position] = linkedList;
            }
            //returning linked list.
            return linkedList;
        }



        public void Add(K key, V value)//used add method and passes 2 parameter pushing the data into hashtable using linkedlist opraton
        {

            int position = GetArrayPosition(key);

            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            // adding Value to linked list
            keyValue<K, V> item = new keyValue<K, V>() { Key = key, Value = value };
            //keyvalue is added in the linkedlist.
            linkedList.AddFirst(item);
        }



        public void Remove(K key)//removing particular entry  from hashtable
        {
            //getting the  position of linkedlist in which key value pair is stored and is to be removed
            int position = GetArrayPosition(key);
            //calling the dictionary from which element is to be removed.
            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            keyValue<K, V> foundItem = default(keyValue<K, V>);
            //iterating loop in linkedlist to find out the key
            foreach (keyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            //if item is found then it is removed
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        //Adding Method for finding Frequency in paragraph
        public  void ParaCheck(string input)
        {
            int count = 0;
            //String Paragraph
            string check = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            //Split is a inbuild function use to split string using seprator
            string[] arr = check.Split(' ');
            foreach (var element in arr)
            {
                if(element.Equals(input))
                {
                    count = count + 1;
                }
                
            }
            Console.WriteLine("Number of Occurance: " + count);
        }
       
        //Adding Display Method
        public int Display(string hash2)
        {
            int count = 0;
            //For items in Linked List
            foreach (var linkedList in items)
            {
               
                // If hashcode Never generated
                if (linkedList != null)
                    foreach (keyValue<K, V> keyvalue in linkedList)
                    {
                        //checking number of occurance
                        if (keyvalue.Value.Equals(hash2))
                        {
                            count = count + 1;
                        }
                        //for printing each key and value in list
                        Console.WriteLine(keyvalue.Key + "\t" + keyvalue.Value);
                        
                    }
            }
            return count;
        }
    }
    /// Defining a struct data type to store key and value
    public struct keyValue<k, v>
    {

        public k Key { get; set; }
        public v Value { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{/// <summary>
/// 
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("++++++++Welcome to Hash Table++++++++");
            //Declaring MyMapNode object with data type
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            // //Adding values in hashtable of keys and value
            //// hash.Add("0", "To");
            // //hash.Add("1", "be");
            // hash.Add("2", "or");
            // hash.Add("3", "not");
            // hash.Add("4", "To");
            // hash.Add("5", "be");
            //To check the frequency of value
            //getting value with the help of key
            Console.WriteLine("Enter the string for checking frequency");
            string userinput = Console.ReadLine();
            hash.ParaCheck(userinput);
            //string valueofcheck= hash.Get(check);
            //Console.WriteLine(" Index value:" + check);
            
            //Displaying all the elements from the linkedlist
           // Console.WriteLine("Displaying all the key value pairs in hash table");
           // int counter=hash.Display(valueofcheck);
            //Console.WriteLine("Total amount of occurance: " + );
            Console.ReadLine();
        }
    }
}

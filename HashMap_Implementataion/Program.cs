using System;

namespace HashMap_Implementataion
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Map<String, int> map = new Map<String,int>();
            for (int i = 0; i < 10; i++)
            {
                map.insert("KEY"+i,i+1);
               
                
            }
           
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("KEY " + i + ":" + map.getValue("KEY"+i));
            }
            Console.WriteLine(map.size());
        }
    }
}

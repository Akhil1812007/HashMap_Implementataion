using System;

namespace HashMap_Implementataion
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Map<String, int> map = new Map<String,int>();
            for (int i = 0; i < 20; i++)
            {
                map.insert("abc" + i, i + 1);
                
            }
           
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("abc" + i + ":" + map.getValue("abc" + i));
            }
        }
    }
}

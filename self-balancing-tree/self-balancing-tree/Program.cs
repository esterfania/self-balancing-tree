using System;

namespace self_balancing_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution tree = new Solution();
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            tree.PrintValues();
            Console.Read();
        }
    }
}

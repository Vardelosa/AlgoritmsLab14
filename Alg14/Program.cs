using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg14
{
    class Program
    {
        static void Main(string[] args)
        {
            Treap treap = new Treap(5);
            treap.Add(7);
            treap.Add(8);
            treap.Add(10);
            treap.Add(11);
            treap.Add(9);
            Console.WriteLine(treap);
            treap.Remove(10);
            Console.WriteLine("\n\n");
            Console.WriteLine(treap);
            Console.ReadKey();
        }
    }
}

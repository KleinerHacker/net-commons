using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.commons.run
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleEx.Write("Hallo \x1B[31;42;1m\x1B[3B\x1B[10CWelt");

            Console.ReadLine();
        }
    }
}

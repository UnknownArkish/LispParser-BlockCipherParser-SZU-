using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser_New
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, LispParser!");

            LispParser parser = new LispParser();
            parser.ParserList("(define one (+ 0 1))");
            parser.ParserList("(define add +)");
            Console.WriteLine(parser.ParserList("(add (+ 1 2) 3)"));


            Console.WriteLine("WellDone!");
            Console.ReadKey();
        }
    }
}

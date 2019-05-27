using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    class Program
    {
        static void Main(string[] args)
        {
            LispParser parser = new LispParser();
            parser.ParseList("(define add (lambda (x y) (+ x y)))");
            Console.WriteLine(parser.ParseList("(add (add 2 5) 3)"));
            //parser.ParseList("(Define add +)");
            //parser.ParseList("(Define ten (* (/ 4 2) 5))");
            //Console.WriteLine(parser.ParseList("(add ten ten)"));

            Console.ReadKey();
        }
    }
}

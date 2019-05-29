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
            parser.ParseList("(define add (lambda (x y z) (+ (+ x y) z)))");
            Console.WriteLine(parser.ParseList("(add 2 3 5)"));
            //parser.ParseList("(Define add +)");
            //parser.ParseList("(Define ten (* (/ 4 2) 5))");
            //Console.WriteLine(parser.ParseList("(add ten ten)"));

            Console.ReadKey();
        }
    }
}

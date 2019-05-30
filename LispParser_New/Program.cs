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
            // 最普通的输出
            Console.WriteLine(parser.ParseAndGetResult("(+ 2 3)"));

            // lambda输出结果
            Console.WriteLine(parser.ParseAndGetResult("((lambda (x y z) (+ (+ x y) z)) 2 3 5)"));
            // define分别lambda和lambda的输出结果
            Console.WriteLine(parser.ParseAndGetResult("(define add3 (lambda (x y z) (+ (+ x y) z)))"));
            Console.WriteLine(parser.ParseAndGetResult("(define add4 (lambda (a b c d) (+ (add3 a b c) d)))"));
            Console.WriteLine(parser.ParseAndGetResult("((lambda () (+ ((lambda () (+ 2 3))) 3)))"));
            // 普通lambda
            Console.WriteLine(parser.ParseAndGetResult("((lambda (+ -) (+ + -)) 2 3)"));
            // lambda嵌套堆栈变量
            Console.WriteLine(parser.ParseAndGetResult("((lambda (x y) (+ x ((lambda () (+ y 0))))) 2 3)"));

            Console.WriteLine(parser.ParseAndGetResult("(add3 2 3 5)"));
            Console.WriteLine(parser.ParseAndGetResult("(add4 1 2 3 5)"));

            //parser.ParseAndGetResult("(define one (+ 0 1))");
            //parser.ParseAndGetResult("(define add +)");
            //Console.WriteLine(parser.ParseAndGetResult("(add (+ 1 (+ 2 3)) (add 4 5))"));


            Console.WriteLine("WellDone!");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser_New
{
    class Program
    {
        static LispParser Parser = new LispParser();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, LispParser!");

            //Sample1();
            //Sample2();
            //Sample3();
            Sample4();

            //Test();

            Console.WriteLine("WellDone!");
            Console.ReadKey();
        }

        static void Sample1()
        {
            Console.WriteLine(Parser.ParseAndGetResult("(define y 10)"));
            Console.WriteLine(Parser.ParseAndGetResult("(define f (lambda (x y) (+ x ((lambda (x) (* x y)) y))))"));
            Console.WriteLine(Parser.ParseAndGetResult("(f 1 2)"));
            Console.WriteLine(Parser.ParseAndGetResult("y"));
        }
        static void Sample2()
        {
            Console.WriteLine(Parser.ParseAndGetResult("(define y 10)"));
            Console.WriteLine(Parser.ParseAndGetResult("(define sqr+y (lambda (x) (+ y (* x x))))"));
            Console.WriteLine(Parser.ParseAndGetResult("(define f (lambda (x y) (sqr+y x)))"));
            Console.WriteLine(Parser.ParseAndGetResult("(sqr+y 5)"));
            Console.WriteLine(Parser.ParseAndGetResult("(f 5 1)"));
        }
        static void Sample3()
        {
            Console.WriteLine(Parser.ParseAndGetResult("(define fact " +
                "(lambda (n) (" +
                    "cond " +
                        "((eq? n 1) 1) " +
                        "(True (* n (fact (- n 1))))" +
                ")))"));
            Console.WriteLine(Parser.ParseAndGetResult("(fact 1)"));
            Console.WriteLine(Parser.ParseAndGetResult("(fact 5)"));
            Console.WriteLine(Parser.ParseAndGetResult("(fact 10)"));
            Console.WriteLine(Parser.ParseAndGetResult("(define sum " +
                "(lambda (n) (" +
                    "cond " +
                        "((eq? n 1) 1) " +
                        "(True (+ n (sum (- n 1))))" +
                ")))"));
            Console.WriteLine(Parser.ParseAndGetResult("(sum 50)"));
        }
        static void Sample4()
        {
            Console.WriteLine(Parser.ParseAndGetResult("(define fun1 (lambda (x) (cond ((eq? x 0) 1) (True (fun2 (- x 1))))))"));
            Console.WriteLine(Parser.ParseAndGetResult("(define fun2 (lambda (x) (cond ((eq? x 0) 2) (True (fun1 (/ x 2))))))"));
            Console.WriteLine(Parser.ParseAndGetResult("(fun1 2)"));
            Console.WriteLine(Parser.ParseAndGetResult("(fun2 2)"));
            Console.WriteLine(Parser.ParseAndGetResult("(fun1 5)"));
            Console.WriteLine(Parser.ParseAndGetResult("(fun2 5)"));
        }



        static void Test()
        {
            /*
            *  下面是报告过程中的测试
            */
            // 测试define和整形原子
            Console.WriteLine("输出1的结果:: " + Parser.ParseAndGetResult("1"));
            Console.WriteLine(Parser.ParseAndGetResult("(define one 1)"));
            Console.WriteLine("输出one的结果:: " + Parser.ParseAndGetResult("one"));

            Console.WriteLine(Parser.ParseAndGetResult("( ( lambda ( x y ) ( + ( ( lambda ( y ) ( + x y ) ) 3 ) y ) ) 1 2 )"));

            Console.WriteLine("输出True的结果:: " + Parser.ParseAndGetResult("True"));
            Console.WriteLine("eq?判断True和Fasel是否相等:: " + Parser.ParseAndGetResult("( eq? True False )"));
            Console.WriteLine("eq?判断1和(+ 0 1)是否相等:: " + Parser.ParseAndGetResult("( eq? 1 ( + 0 1 ) )"));

            Console.WriteLine("define 5赋给x:: " + Parser.ParseAndGetResult("( define x 5 )"));
            Console.WriteLine("cond测试::" + Parser.ParseAndGetResult(
                "( cond ( " +
                    "(eq? x 4) (* x 3) ) " +                    // 如果x==4，则返回x*3的结果
                    "( (eq? x 5) ( * x x ) ) " +                // 如果x==5，则返回x*x的结果
                    "(True ( * x 2 )) )"                        // 或者，返回x*2的结果
                )
            );

            /*
             *  下面是原来的测试
             */
            // 最普通的输出
            Console.WriteLine(Parser.ParseAndGetResult("(+ (+ 2 3) 3)"));

            // lambda输出结果
            Console.WriteLine(Parser.ParseAndGetResult("((lambda (x y z) (+ (+ x y) z)) 2 3 5)"));
            // define分别lambda和lambda的输出结果
            Console.WriteLine(Parser.ParseAndGetResult("(define one ( + 1 0 ))"));
            Console.WriteLine(Parser.ParseAndGetResult("(define add3 (lambda (x y z) (+ (+ x y) z)))"));
            Console.WriteLine(Parser.ParseAndGetResult("(define add4 (lambda (a b c d) (+ (add3 a b c) d)))"));
            Console.WriteLine(Parser.ParseAndGetResult("((lambda () (+ ((lambda () (+ 2 3))) 3)))"));
            // 普通lambda
            Console.WriteLine(Parser.ParseAndGetResult("((lambda (+ -) (+ + -)) 2 3)"));
            // lambda嵌套堆栈变量
            Console.WriteLine(Parser.ParseAndGetResult("((lambda (x y) (+ x ((lambda () (+ y 0))))) 2 3)"));

            Console.WriteLine(Parser.ParseAndGetResult("(add3 2 3 5)"));
            Console.WriteLine(Parser.ParseAndGetResult("(add4 1 2 3 5)"));

            // eq?函数
            Console.WriteLine(Parser.ParseAndGetResult("(eq? one 1)"));
            Console.WriteLine(Parser.ParseAndGetResult("(eq? 4 (+ 1 2))"));
            Console.WriteLine(Parser.ParseAndGetResult("(eq? (eq? 1 2) False)"));

            // cond函数
            Console.WriteLine(Parser.ParseAndGetResult("(" +
                "(lambda (x) " +
                    "(+ x " +
                        "(cond ((eq? x 1) 1) (True 0))" +
                    ")" +
                ") " +
                "2)"));
            Console.WriteLine(Parser.ParseAndGetResult("(define a 3)"));
            Console.WriteLine(Parser.ParseAndGetResult("(cond ((eq? a 2) 0) ((eq? a 3) 1) (True 2))"));

            // fact
            Parser.ParseAndGetResult("(define fact " +
                "(lambda (x) " +
                    "(* x " +
                        "(cond ((eq? x 1) 1) (True (fact (- x 1))))" +
                    ")" +
                ")" +
            ")");
            Console.WriteLine(Parser.ParseAndGetResult("(fact 10)"));


            //Parser.ParseAndGetResult("(define one (+ 0 1))");
            //Parser.ParseAndGetResult("(define add +)");
            //Console.WriteLine(Parser.ParseAndGetResult("(add (+ 1 (+ 2 3)) (add 4 5))"));
        }
    }
}

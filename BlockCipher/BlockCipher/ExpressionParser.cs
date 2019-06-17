using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace BlockCipher
{
    /// <summary>
    /// 表达式解析器
    /// </summary>
    public class ExpressionParser
    {

        private static readonly Dictionary<char,int> OperationDict = new Dictionary<char, int>
        {
            ['='] = 0,
            ['+'] = 1
        };
        /// <summary>
        ///   = +
        /// = 0 -1
        /// + 1 0
        /// </summary>
        private static readonly int[][] OperationPriority =
        {
            new int[]{0, -1 },
            new int[]{1,  0 },
        };

        public BlockCipherParser Parser { get;private set; }

        public ExpressionParser(BlockCipherParser parser)
        {
            Parser = parser;
        }


        public BitArray ParseExpression( string expression )
        {
            expression = expression.Trim();
            BitArray result = null;
            ExpressionHandler handler = null;
            // 优先级 = < + < PS
            if( expression.Contains('='))
            {
                handler = new AssignmentHandler(this);
            }
            else if( expression.Contains('+'))
            {
                handler = new XORHandler(this);
            }
            else if( expression[0] == 'P' || expression[0] == 'S')
            {
                if( expression[0] == 'P')
                {
                    handler = new PermuteHandler(this);
                }
                else
                {
                    handler = new SBoxHandler(this);
                }
            }
            else
            {
                // 判断是否为常量
                Match constMatch = Regex.Match(expression, "(\"\\d+\")");
                // 如果成功则为常量
                if (constMatch.Success)
                {
                    handler = new ConstHandler(this);
                }
                else
                {
                    handler = new VariableHandler(this);
                }
            }
            result = handler.Handle(expression);
            return result;
        }

        
        //public BitArray ParseExpression_( string expression)
        //{
        //    Stack<string> variable = new Stack<string>();
        //    Stack<char> operation = new Stack<char>();

        //    for( int i = 0; i < expression.Length; i++)
        //    {
        //        if( !OperationDict.ContainsKey(expression[i]))
        //        {
        //            int j = i;
        //            StringBuilder sb = new StringBuilder();
        //            while( !OperationDict.ContainsKey(expression[j]))
        //            {
        //                if( expression[j] != ' ' )
        //                    sb.Append(expression[j]);
        //                j++;
        //            }
        //            i = j - 1;
        //            variable.Push(sb.ToString());
        //        }
        //        else
        //        {
        //            operation.Push(expression[i]);
        //        }
        //    }

        //    return null;
        //}


    }
}

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
    }
}

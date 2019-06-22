using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    /// <summary>
    /// 处理异或的Handler
    /// </summary>
    public class XORHandler : ExpressionHandler
    {
        public XORHandler(ExpressionParser expressionParser) : base(expressionParser)
        {
        }

        public override BitArray Handle(string expression)
        {
            expression = expression.Trim();

            // 左结合，因此先从最右开始
            string op1 = expression.Substring(0, expression.LastIndexOf('+')).Trim();
            string op2 = expression.Substring(expression.LastIndexOf('+') + 1).Trim();
            // 将左边的表达式和右边的表达式交给解释器处理
            BitArray result1 = ExpressionParser.ParseExpression(op1);
            BitArray result2 = ExpressionParser.ParseExpression(op2);
            
            return result1.Xor(result2);
        }
    }
}

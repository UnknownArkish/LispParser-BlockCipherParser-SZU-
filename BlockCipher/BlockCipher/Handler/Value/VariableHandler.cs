using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    /// <summary>
    /// 处理纯变量的Handler
    /// </summary>
    public class VariableHandler : ExpressionHandler
    {
        public VariableHandler(ExpressionParser expressionParser) : base(expressionParser)
        {
        }

        public override BitArray Handle(string expression)
        {
            expression = BindingVariable(expression);
            return ExpressionParser.Parser.VariableStorage[expression];
        }
    }
}

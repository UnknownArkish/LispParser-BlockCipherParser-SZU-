using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    public class AssignmentHandler:ExpressionHandler
    {
        public AssignmentHandler(ExpressionParser expressionParser) : base(expressionParser)
        {
        }

        public override BitArray Handle(string expression)
        {
            expression = expression.Trim();

            // 进行变量的绑定，因为变量可能是数组形式
            string variableKey = expression.Substring(0, expression.IndexOf('=')).Trim();
            variableKey = BindingVariable(variableKey);

            // 进行赋值运算符右边表达式的计算
            string variableValue = expression.Substring(expression.IndexOf('=') + 1).Trim();
            BitArray result = ExpressionParser.ParseExpression(variableValue);

            // 更新并返回变量的数值
            Parser.VariableStorage.AddVariable(variableKey, result);
            return result;
        }
    }
}

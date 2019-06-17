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
    /// 表达式的Handler
    /// </summary>
    public abstract class ExpressionHandler
    {
        protected ExpressionParser ExpressionParser { get; private set; }
        public ExpressionHandler(ExpressionParser expressionParser)
        {
            ExpressionParser = expressionParser;
        }

        public abstract BitArray Handle(string expression);

        /// <summary>
        /// 绑定一个变量的名字，将会绑定其中任何[]修饰的数值
        /// </summary>
        protected string BindingVariable(string variableKey)
        {
            Regex reg = new Regex(@"(\[\w+\])");
            Match match = reg.Match(variableKey);
            
            while( match.Success)
            {
                string temp = BindMatchValue(match.Value);
                variableKey = variableKey.Replace(match.Value, temp);

                match = match.NextMatch();
            }

            return variableKey;
        }

        private string BindMatchValue(string matchValue)
        {
            Match match = Regex.Match(matchValue, @"\w+");
            string toReplace = ExpressionParser.Parser.LoopVariableStorage[match.Value].ToString();
            return matchValue.Replace(match.Value, toReplace);
        }
    }
}

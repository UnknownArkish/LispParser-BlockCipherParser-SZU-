using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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


            return variableKey;
        }
    }
}

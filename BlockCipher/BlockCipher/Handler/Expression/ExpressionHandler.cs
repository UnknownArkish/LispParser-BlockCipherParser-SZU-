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
    public abstract class ExpressionHandler : BaseHandler
    {
        protected ExpressionParser ExpressionParser { get; private set; }
        public ExpressionHandler(ExpressionParser expressionParser) : base(expressionParser.Parser)
        {
            ExpressionParser = expressionParser;
        }

        public abstract BitArray Handle(string expression);
    }
}

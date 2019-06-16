using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    /// <summary>
    /// 处理置换的Handler
    /// </summary>
    public class PermuteHandler : ExpressionHandler
    {
        public PermuteHandler(ExpressionParser expressionParser) : base(expressionParser)
        {
        }

        public override BitArray Handle(string expression)
        {
            throw new NotImplementedException();
        }
    }
}

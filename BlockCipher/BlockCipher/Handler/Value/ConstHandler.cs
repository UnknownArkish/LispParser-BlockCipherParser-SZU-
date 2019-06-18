using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    /// <summary>
    /// 常量Handler
    /// </summary>
    public class ConstHandler : ExpressionHandler
    {
        public ConstHandler(ExpressionParser expressionParser) : base(expressionParser)
        {
        }

        public override BitArray Handle(string expression)
        {
            return BlockCipherUtil.ConstToBitArray(expression);
        }
    }
}

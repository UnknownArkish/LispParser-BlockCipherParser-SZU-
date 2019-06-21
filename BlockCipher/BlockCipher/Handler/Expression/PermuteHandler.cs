using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlockCipher
{
    /// <summary>
    /// 处理置换的Handler
    /// </summary>
    public class PermuteHandler : PSDataHandler
    {
        public PermuteHandler(ExpressionParser expressionParser) : base(expressionParser)
        {
        }
        
        protected override BitArray Calculate(int dataIndex, BitArray op)
        {
            PSData permute = Parser.PermuteSBoxStorage.Permute[dataIndex];
            BitArray result = new BitArray(permute.OutputLength);
            for (int i = 0; i < permute.Data.Length; i++)
            {
                result[i] = op[permute.Data[i]];
            }
            return result;
        }
    }
}

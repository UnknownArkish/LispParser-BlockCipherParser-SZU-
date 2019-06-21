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
    /// 处理S盒的Handler
    /// </summary>
    public class SBoxHandler : PSDataHandler
    {
        public SBoxHandler(ExpressionParser expressionParser) : base(expressionParser)
        {
        }

        protected override BitArray Calculate(int dataIndex, BitArray op)
        {
            PSData sBox = Parser.PermuteSBoxStorage.SBox[dataIndex];
            // 将op转为十进制
            int opInt = Convert.ToInt32(BlockCipherUtil.BitArrayToString(op), 2);
            int resultInt = sBox.Data[opInt];
            // 将temp转为二进制字符串
            StringBuilder resultStr = new StringBuilder(Convert.ToString(resultInt, 2));
            for (int i = resultStr.Length; i < sBox.OutputLength; i++)
            {
                resultStr.Insert(0, "0");
            }

            BitArray result = BlockCipherUtil.StringToBitArray(resultStr.ToString());
            return result;
        }
    }
}

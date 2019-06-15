using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BlockCipher
{
    public static class BlockCipherUtil
    {
        /// <summary>
        /// 转化BitArray数组为01字符串
        /// </summary>
        public static string BitArrayToString(BitArray bits)
        {
            StringBuilder sb = new StringBuilder();
            foreach (bool bit in bits)
            {
                sb.Append(bit ? "1" : "0");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 找到contexts数组中，找到最后一个context的下标
        /// </summary>
        public static int FindLastOf(string[] contexts,  string context, bool trim = true)
        {
            int result = -1;
            for (int i = contexts.Length - 1; i >= 0; i--)
            {
                string temp = contexts[i];
                if (trim) temp = temp.Trim();
                if (temp.Equals(context))
                {
                    result = i;
                }
            }
            return result;
        }

    }
}

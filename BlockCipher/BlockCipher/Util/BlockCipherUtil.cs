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
        public static BitArray StringToBitArray(string bits)
        {
            BitArray result = new BitArray(bits.Length);
            for (int i = 0; i < bits.Length; i++)
            {
                result.Set(i, bits[i] == '1' ? true : false);
            }
            return result;
        }
        public static BitArray ConstToBitArray(string constStr)
        {
            constStr = constStr.Substring(1);
            constStr = constStr.Substring(0, constStr.Length - 1);
            return StringToBitArray(constStr);
        }

        /// <summary>
        /// 找到contexts数组中，第一个context的下标
        /// </summary>
        public static int FindFirstOf(string[] contexts, string context, bool trim = true)
        {
            int result = -1;
            for( int i = 0; i < contexts.Length; i++)
            {
                string temp = contexts[i];
                if (trim) temp = temp.Trim();
                if( temp.Equals(context))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// 找到contexts数组中，第一个包含context的下标
        /// </summary>
        public static int FindFirstContain(string[] contexts, string context, bool trim = true)
        {
            int result = -1;
            for (int i = 0; i < contexts.Length; i++)
            {
                string temp = contexts[i];
                if (trim) temp = temp.Trim();
                if (temp.Contains(context))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 找到contexts数组中，找到最后一个context的下标
        /// </summary>
        public static int FindLastOf(string[] contexts, string context, bool trim = true)
        {
            int result = -1;
            for (int i = contexts.Length - 1; i >= 0; i--)
            {
                string temp = contexts[i];
                if (trim) temp = temp.Trim();
                if (temp.Equals(context))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// 找到contexts数组中，找到最后一个包含context的下标
        /// </summary>
        public static int FindLastContain(string[] contexts, string context, bool trim = true)
        {
            int result = -1;
            for (int i = contexts.Length - 1; i >= 0; i--)
            {
                string temp = contexts[i];
                if (trim) temp = temp.Trim();
                if (temp.Contains(context))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 找到最近的一个Loop的代码上下文
        /// </summary>
        public static string[] GetLoopCodeContext(string[] codeContext)
        {
            List<string> result = new List<string>();
            int loopIndex = FindFirstContain(codeContext, "LOOP");
            int loopEnd = FindLastOf(codeContext, "ENDLOOP");
            for (int i = loopIndex + 1; i < loopEnd; i++)
            {
                result.Add(codeContext[i]);
            }
            return result.ToArray();
        }

        public static string[] GetSplitCodeContext(string[] codeContext)
        {
            List<string> result = new List<string>();
            int loopIndex = FindFirstContain(codeContext, "SPLIT");
            int loopEnd = FindLastContain(codeContext, "MERGE");
            for (int i = loopIndex + 1; i < loopEnd; i++)
            {
                result.Add(codeContext[i]);
            }
            return result.ToArray();
        }

        

    }
}

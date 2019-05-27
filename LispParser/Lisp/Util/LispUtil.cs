using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    public static class LispUtil
    {
        /// <summary>
        /// 提取一个列表的参数
        /// </summary>
        public static string[] SplitArgs(string list)
        {
            string[] result = new string[3];
            list = RemoveBracket(list);

            result[0] = SplitArg(list);
            list = list.Substring(list.IndexOf(' ') + 1);
            result[1] = SplitArg(list);
            list = list.Substring(list.IndexOf(' ') + 1);
            result[2] = list;

            return result;
        }

        /// <summary>
        /// 移除一个列表两边的括号
        /// </summary>
        public static string RemoveBracket(string list)
        {
            string result = list.Trim();
            if (!IsAtom(list))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(result.Substring(1));
                sb.Remove(sb.Length - 1, 1);
                result = sb.ToString().Trim();
            }
            return result;
        }

        /// <summary>
        /// 将list通过split得到一个参数
        /// </summary>
        public static string SplitArg(string list)
        {
            string result = null;
            result = list.Substring(0, GetNextArgsLength(list));
            return result;
        }
        /// <summary>
        /// 将list通过split得到num个参数
        /// </summary>
        public static string[] SplitArgs(string list, int num)
        {
            string[] result = new string[num];
            list = list.Trim();
            for (int i = 0; i < num - 1; i++)
            {
                result[i] = SplitArg(list);
                list = list.Substring(GetNextArgsLength(list) + 1);
            }
            result[num - 1] = list;
            return result;
        }

        /// <summary>
        /// 检查list是否为一个原子项
        /// </summary>
        public static bool IsAtom(string list)
        {
            list = list.Trim();
            if (list[0] == '(' && list[list.Length - 1] == ')')
            {
                return false;
            }
            return true;
        }


        private static int GetNextArgsLength(string list)
        {
            list = list.Trim();
            list += ' ';
            int result = list.IndexOf(' ');
            if (list[0] == '(')
            {
                int numBracket = 1;
                for (int i = 1; i < list.Length; i++)
                {
                    if (list[i] == '(') numBracket++;
                    else if (list[i] == ')') numBracket--;
                    if (numBracket == 0)
                    {
                        result = i + 1;
                        break;
                    }
                }
            }
            return result;
        }

    }
}

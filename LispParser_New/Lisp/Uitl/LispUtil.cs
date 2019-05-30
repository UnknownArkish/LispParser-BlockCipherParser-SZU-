using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LispUtil
{
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

    /// <summary>
    /// 以一个原子为单位进行切割
    /// </summary>
    public static string SplitInAtom(string list)
    {
        if (string.IsNullOrEmpty(list)) return null;

        string result = list;
        int length = GetNextAtomLength(list);
        if( length != -1)
        {
            result = list.Substring(0, length);
        }
        return result;
    }
    /// <summary>
    /// 以一个原子为单位进行切割，切割num个原子
    /// </summary>
    public static string[] SplitInAtom(string list, int num)
    {
        string[] result = new string[num];
        list = list.Trim();
        for (int i = 0; i < num; i++)
        {
            result[i] = SplitInAtom(list);
            if (i < num - 1)
                list = list.Substring(GetNextAtomLength(list) + 1);
        }
        return result;
    }
    /// <summary>
    /// 以原子为单位进行切割，切割所有原子
    /// </summary>
    public static string[] SplitInAtomAll(string list)
    {
        List<string> results = new List<string>();

        int length = GetNextAtomLength(list);
        while( length != -1)
        {
            string result = list.Substring(0, length);
            results.Add(result);

            list = list.Substring(length + 1);
            length = GetNextAtomLength(list);
        }
        results.Add(list);

        return results.ToArray();
    }


    public static int GetNextAtomLength(string list)
    {
        list = list.Trim();
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
            if (result == list.Length) result = -1;
        }
        return result;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_HW_2.LispParser
{
    public class LispParser
    {
        private Dictionary<string, LispAtom> m_AtomDict;
        public LispParser()
        {
            m_AtomDict = new Dictionary<string, LispAtom>();

        }
        private void InitOriginalAtom()
        {
            m_AtomDict["+"] = new AddAtom();
        }

        /// <summary>
        /// 解析一行Lisp指令
        /// </summary>
        public string ParseLine(string line)
        {
            string result = null;
            return result;
        }


        /// <summary>
        /// 解析一个列表
        /// </summary>
        /// <param name="list"></param>
        public object ParseList(string list)
        {
            if (!list.Contains('(') && !list.Contains(")"))
            {
                if (!m_AtomDict.ContainsKey(list))
                {
                    m_AtomDict[list] = new IntAtom()
                    {
                        Data = int.Parse(list)
                    };
                }
                return m_AtomDict[list].Run();
            }

            list = Extract(list);
            string[] args = list.Split(' ');
            string func = args[0];
            LispAtom funcAtom = m_AtomDict[func];
            return funcAtom.Run(ParseList(args[1]), ParseList(args[2]));
        }


        private string Extract(string list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(list.Substring(1));
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

    }
}

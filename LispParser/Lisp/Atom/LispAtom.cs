using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    public abstract class LispAtom
    {
        protected LispParser Parser { get; private set; }
        public LispAtom(LispParser parser)
        {
            Parser = parser;
        }

        protected abstract int ArgNum { get; }

        public abstract object Run(string list);

        /// <summary>
        /// 根据ArgNum获取参数
        /// </summary>
        protected string[] GetArgs(string list)
        {
            string[] args = LispUtil.SplitArgs(list, ArgNum + 1);
            string[] result = new string[ArgNum];
            for (int i = 0; i < ArgNum; i++)
            {
                result[i] = args[i + 1];
            }
            return result;
        }
        /// <summary>
        /// 调用Parser解析List的函数
        /// </summary>
        protected object ParseList(string list)
        {
            return Parser.ParseList(list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    public class LispParser
    {
        private AtomStorage m_AtomStorage;
        public AtomStorage AtomStorage { get { return m_AtomStorage; } }
        public LispParser()
        {
            m_AtomStorage = new AtomStorage(this);
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
            string key = list;
            if (!LispUtil.IsAtom(list))
            {
                list = LispUtil.RemoveBracket(list);
                key = LispUtil.SplitArg(list);
            }
            LispAtom func = null;
            if (key.Contains("lambda"))
            {
                func = new LambdaAtomFactory(this).Run(list) as LambdaAtom;
                return func;
            }
            else
            {
                func = AtomStorage[key];
            }
            if (func == null) return key;
            return func.Run(list);
        }
    }
}

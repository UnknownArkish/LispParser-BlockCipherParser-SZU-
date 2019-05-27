using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispParser
{
    /// <summary>
    /// 原子库，用以保存/注册绑定后的原子
    /// </summary>
    public class AtomStorage
    {
        private LispParser Parser { get; set; }

        private Dictionary<string, LispAtom> m_AtomDicts;
        public AtomStorage(LispParser parser)
        {
            Parser = parser;

            m_AtomDicts = new Dictionary<string, LispAtom>();
            InitOriginalAtom();
        }

        /// <summary>
        /// 获取一个原子（如果key为整型，一定可以得到对应的IntAtom）
        /// </summary>
        public LispAtom this[string key]
        {
            get
            {
                LispAtom result = null;
                if (!ContainKey(key))
                {
                    // 判断key是否为纯数字，如果是则先注册一个intAtom
                    try
                    {
                        int value = int.Parse(key);
                        RegisterAtom(key, new IntAtom(Parser, key));
                    }
                    catch (Exception) { }
                }
                if (ContainKey(key))
                {
                    result = m_AtomDicts[key];
                }
                return result;
            }
        }
        /// <summary>
        /// 以key值定义一个Atom，以defineFrom为依据
        /// </summary>
        public bool Define(string key, string defineFrom)
        {
            LispAtom atom = this[defineFrom];
            return RegisterAtom(key, atom);
        }
        /// <summary>
        /// 以key为键值，注册一个Atom。若key存在，不会进行覆盖
        /// </summary>
        public bool RegisterAtom(string key, LispAtom atom)
        {
            if (ContainKey(key)) return false;
            m_AtomDicts[key] = atom;
            return true;
        }
        /// <summary>
        /// 判断是否含有以某个key为键值的原子
        /// </summary>
        public bool ContainKey(string key)
        {
            return m_AtomDicts.ContainsKey(key);
        }

        /// <summary>
        /// 初始化原始绑定的原子
        /// </summary>
        private void InitOriginalAtom()
        {
            m_AtomDicts["+"] = new AddAtom(Parser);
            m_AtomDicts["-"] = new ReduceAtom(Parser);
            m_AtomDicts["*"] = new MultiplyAtom(Parser);
            m_AtomDicts["/"] = new DivideAtom(Parser);

            m_AtomDicts["define"] = new DefineAtom(Parser);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    /// <summary>
    /// 动态运行时变量栈
    /// 默认每个变量的值都是字符串类型
    /// </summary>
    public class RuntimeVariableStack
    {
        private Dictionary<string, Stack<int>> m_RuntimeVariableDict;

        public RuntimeVariableStack()
        {
            m_RuntimeVariableDict = new Dictionary<string, Stack<int>>();
        }

        /// <summary>
        /// 向变量栈中添加一个变量
        /// value希望值是一个
        /// </summary>
        public void Push(string key, int value)
        {
            if( m_RuntimeVariableDict.ContainsKey(key))
            {
                RegisterVariableStack(key);
            }
            m_RuntimeVariableDict[key].Push(value);
        }
        /// <summary>
        /// 从变量中Pop出一个变量的数值
        /// </summary>
        public int Pop(string key)
        {
            int result = -1;
            if (m_RuntimeVariableDict.ContainsKey(key))
            {
                if (m_RuntimeVariableDict[key].Count > 0)
                {
                    result = m_RuntimeVariableDict[key].Pop();
                }
            }
            return result;
        }

        /// <summary>
        /// 获取一个动态变量的数值，不会对变量进行退栈
        /// 注意可能为空，说明运行时变量栈没有此变量
        /// </summary>
        public int this[string key]
        {
            get
            {
                int result = -1;
                if (m_RuntimeVariableDict.ContainsKey(key))
                {
                    if (m_RuntimeVariableDict[key].Count > 0)
                    {
                        result = m_RuntimeVariableDict[key].Peek();
                    }
                }
                return result;
            }
        }

        private void RegisterVariableStack(string key)
        {
            m_RuntimeVariableDict[key] = new Stack<int>();
        }

    }
}

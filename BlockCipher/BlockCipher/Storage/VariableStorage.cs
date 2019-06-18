using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BlockCipher
{
    /// <summary>
    /// 静态变量库存
    /// 默认每个静态变量的数值类型都是BitArray
    /// </summary>
    public class VariableStorage
    {
        private Dictionary<string, BitArray> m_VariableDict;

        public VariableStorage()
        {
            m_VariableDict = new Dictionary<string, BitArray>();
        }

        public bool ContainVariable(string key)
        {
            return m_VariableDict.ContainsKey(key);
        }

        /// <summary>
        /// 获取一个变量的数值
        /// </summary>
        public BitArray this[string key]
        {
            get
            {
                if( !ContainVariable(key))
                {
                    throw new Exception(string.Format("变量名 {0} 没有被声明!", key));
                }
                return m_VariableDict[key];
            }
        }


        /// <summary>
        /// 添加一个变量，默认覆盖
        /// </summary>
        public void AddVariable(string key, BitArray value, bool overlay = true)
        {
            if (m_VariableDict.ContainsKey(key) && !overlay) return;
            m_VariableDict[key] = value;
        }
        /// <summary>
        /// 添加一个变量，需要指定长度
        /// 初始数值可选，默认覆盖
        /// </summary>
        public void AddVariable(string key, int length, bool[] originValues = null, bool overlay = true)
        {
            BitArray variable = null;
            if (originValues != null) variable = new BitArray(originValues);
            else variable = new BitArray(length);
            AddVariable(key, variable, overlay);
        }
        /// <summary>
        /// 添加一个变量，以字符串作为初始变量
        /// 默认覆盖
        /// </summary>
        public void AddVariable(string key, string value, bool overlay = true)
        {
            BitArray temp = BlockCipherUtil.StringToBitArray(value);
            AddVariable(key, temp, overlay);
        }

        /// <summary>
        /// 移除一个变量并返回是否成功移除的结果，如果变量不存在，返回false
        /// </summary>
        public bool RemoveVariable(string key)
        {
            if (!ContainVariable(key)) return false;
            m_VariableDict[key] = null;
            return true;
        }
    }
}

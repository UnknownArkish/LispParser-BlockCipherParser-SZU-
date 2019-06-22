using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockCipher
{
    /// <summary>
    /// 抽象库存类，每个库存是一个 一维整型数组
    /// </summary>
    public class BaseStorage
    {
        private PSData[] m_Storages;
        public BaseStorage(PSData[] storages)
        {
            m_Storages = storages;
        }
        /// <summary>
        /// 个数
        /// </summary>
        public int Count => m_Storages.Length;
        /// <summary>
        /// 获取一个库存
        /// </summary>
        public PSData this[int index]
        {
            get
            {
                PSData result = null;
                if( index >= 0 && index < Count)
                {
                    result = m_Storages[index];
                }
                return result;
            }
        }
    }
}

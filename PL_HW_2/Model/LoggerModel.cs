using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_HW_2.Model
{
    public class LoggerModel : Framework.Model
    {
        public override string Name => Consts.MVCConsts.M_DebugModel;

        /// <summary>
        /// 用以存放Log消息的列表
        /// </summary>
        private List<string> m_LogList;
        /// <summary>
        /// 初始化Model函数
        /// </summary>
        public override void Init()
        {
            base.Init();
            m_LogList = new List<string>();
        }

        /// <summary>
        /// 是否开启Debug
        /// </summary>
        public bool IsLog { get; set; } = true;
        /// <summary>
        /// 获取所有的log信息
        /// </summary>
        public string[] Logs { get { return m_LogList.ToArray(); } }
        /// <summary>
        /// 当新log插入时发生
        /// </summary>
        public event Action<string> NewLogEvent;

        /// <summary>
        /// 记录一条log信息，如果没有开启IsLog，则不作操作
        /// </summary>
        public void Log(string msg)
        {
            if (!IsLog) return;
            m_LogList.Add(msg);
            NewLogEvent?.Invoke(msg);
        }
        /// <summary>
        /// 清空所有log信息
        /// </summary>
        public void Clear()
        {
            m_LogList.Clear();
        }


    }
}

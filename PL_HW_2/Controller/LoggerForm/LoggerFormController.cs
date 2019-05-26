using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_HW_2.Controller
{
    public class LoggerFormController : Framework.Controller<LoggerForm>
    {
        protected Model.LoggerModel LoggerModel { get { return GetModel<Model.LoggerModel>(); } }

        public LoggerFormController(LoggerForm context) : base(context)
        {
            // @TODO: 注册LoggerModel中，info发生改变时的事件
            LoggerModel.NewLogEvent += OnNewLog;
        }

        /// <summary>
        /// 当LoggerModel的log信息发生变化时调用
        /// </summary>
        private void OnNewLog(string msg)
        {
            TextBox textBox = Context.GetTextBox_Logger();
            textBox.AppendText(msg);
            textBox.AppendText(Environment.NewLine);
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_HW_2.Framework
{
    /// <summary>
    /// Controller基类
    /// </summary>
    public class Controller<TForm> where TForm : Form
    {
        public Controller( TForm context )
        {
            Context = context;
        }

        /// <summary>
        /// 指示所控制的Form窗体
        /// </summary>
        protected TForm Context { get; private set; }

        /// <summary>
        /// 获取一个Model
        /// </summary>
        protected TModel GetModel<TModel>() where TModel : Model
        {
            return MVC.GetModel<TModel>();
        }

    }
}

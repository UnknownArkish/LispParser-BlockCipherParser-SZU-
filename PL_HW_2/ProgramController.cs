using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_HW_2
{
    public class ProgramController
    {
        public static ProgramController Instance { get; set; } = new ProgramController();

        /// <summary>
        /// 进行对程序的初始化
        /// </summary>
        public void Init()
        {
            InitMVC();
        }
    
        /// <summary>
        /// 初始化MVC框架
        /// </summary>
        private void InitMVC()
        {
            Model.LoggerModel loggerModel = new Model.LoggerModel();

            Framework.MVC.RegisterModel(loggerModel);
        }
    }
}

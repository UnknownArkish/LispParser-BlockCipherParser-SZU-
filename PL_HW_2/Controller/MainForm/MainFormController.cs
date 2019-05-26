using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_HW_2.Controller
{
    public class MainFormController : Framework.Controller<MainForm>
    {
        public MainFormController(MainForm context) : base(context)
        {
        }
        
        public void ShowLoggerForm()
        {
            LoggerForm.Instance.Show();
        }
        public void HideLoggerForm()
        {
            LoggerForm.Instance.Hide();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_HW_2
{
    public partial class MainForm : Form
    {
        private Controller.MainFormController MainFormController { get; set; }

        public MainForm()
        {
            InitializeComponent();

            MainFormController = new Controller.MainFormController(this);
            MainFormController.ShowLoggerForm();
            MainFormController.HideLoggerForm();
        }

        private void FlowLayout_Console_Click(object sender, EventArgs e)
        {
            MainFormController.ShowLoggerForm();
        }
        private void Label_ConsoleTip_Click(object sender, EventArgs e)
        {
            MainFormController.ShowLoggerForm();
        }

        private void ShowLoggerForm()
        {
            LoggerForm.Instance.Show();
        }
        private void HideLoggerForm()
        {
            LoggerForm.Instance.Hide();
        }
    }
}

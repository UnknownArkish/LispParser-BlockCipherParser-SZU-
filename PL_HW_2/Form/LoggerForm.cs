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
    public partial class LoggerForm : Form
    {
        private static LoggerForm m_Instance = new LoggerForm();
        public static LoggerForm Instance { get => m_Instance; }

        private Controller.LoggerFormController LoggerFormController { get; set; }

        private LoggerForm()
        {
            InitializeComponent();

            LoggerFormController = new Controller.LoggerFormController(this);
        }


        public TextBox GetTextBox_Logger() { return TextBox_Logger; }


        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}

namespace PL_HW_2
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TextBox_Output = new System.Windows.Forms.TextBox();
            this.FlowLayout_Console = new System.Windows.Forms.FlowLayoutPanel();
            this.Label_ConsoleTip = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Run = new System.Windows.Forms.Button();
            this.TextBox_Input = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.FlowLayout_Console.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TextBox_Output, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FlowLayout_Console, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBox_Input, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 546);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TextBox_Output
            // 
            this.TextBox_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Output.Enabled = false;
            this.TextBox_Output.Location = new System.Drawing.Point(531, 5);
            this.TextBox_Output.Margin = new System.Windows.Forms.Padding(5);
            this.TextBox_Output.Multiline = true;
            this.TextBox_Output.Name = "TextBox_Output";
            this.TextBox_Output.ReadOnly = true;
            this.TextBox_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Output.Size = new System.Drawing.Size(442, 509);
            this.TextBox_Output.TabIndex = 3;
            // 
            // FlowLayout_Console
            // 
            this.FlowLayout_Console.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.tableLayoutPanel1.SetColumnSpan(this.FlowLayout_Console, 3);
            this.FlowLayout_Console.Controls.Add(this.Label_ConsoleTip);
            this.FlowLayout_Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayout_Console.Location = new System.Drawing.Point(0, 519);
            this.FlowLayout_Console.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayout_Console.Name = "FlowLayout_Console";
            this.FlowLayout_Console.Size = new System.Drawing.Size(978, 27);
            this.FlowLayout_Console.TabIndex = 0;
            this.FlowLayout_Console.Click += new System.EventHandler(this.FlowLayout_Console_Click);
            // 
            // Label_ConsoleTip
            // 
            this.Label_ConsoleTip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label_ConsoleTip.AutoSize = true;
            this.Label_ConsoleTip.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_ConsoleTip.ForeColor = System.Drawing.Color.White;
            this.Label_ConsoleTip.Location = new System.Drawing.Point(3, 4);
            this.Label_ConsoleTip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.Label_ConsoleTip.Name = "Label_ConsoleTip";
            this.Label_ConsoleTip.Size = new System.Drawing.Size(28, 17);
            this.Label_ConsoleTip.TabIndex = 0;
            this.Label_ConsoleTip.Text = "..";
            this.Label_ConsoleTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_ConsoleTip.Click += new System.EventHandler(this.Label_ConsoleTip_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.Button_Run, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(451, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(75, 519);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // Button_Run
            // 
            this.Button_Run.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Button_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Run.ForeColor = System.Drawing.Color.White;
            this.Button_Run.Location = new System.Drawing.Point(0, 238);
            this.Button_Run.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Run.Name = "Button_Run";
            this.Button_Run.Size = new System.Drawing.Size(75, 43);
            this.Button_Run.TabIndex = 0;
            this.Button_Run.Text = "Go!";
            this.Button_Run.UseVisualStyleBackColor = false;
            // 
            // TextBox_Input
            // 
            this.TextBox_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox_Input.Location = new System.Drawing.Point(5, 5);
            this.TextBox_Input.Margin = new System.Windows.Forms.Padding(5);
            this.TextBox_Input.Multiline = true;
            this.TextBox_Input.Name = "TextBox_Input";
            this.TextBox_Input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_Input.Size = new System.Drawing.Size(441, 509);
            this.TextBox_Input.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 546);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "LispParser";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.FlowLayout_Console.ResumeLayout(false);
            this.FlowLayout_Console.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel FlowLayout_Console;
        private System.Windows.Forms.Label Label_ConsoleTip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Button_Run;
        private System.Windows.Forms.TextBox TextBox_Input;
        private System.Windows.Forms.TextBox TextBox_Output;
    }
}


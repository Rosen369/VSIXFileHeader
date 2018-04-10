using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frank.FileHeaderCommand
{
    public class EditHeaderTemplateControl : UserControl
    {
        internal TemplateOptionPage OptionsPage;

        private IContainer components = null;

        private TextBox textBox1;

        public EditHeaderTemplateControl()
        {
            this.InitializeComponent();
        }

        public void Initialize()
        {
            this.textBox1.Text = this.OptionsPage.FileHeaderTemplate;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.OptionsPage.FileHeaderTemplate = this.textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.OptionsPage.FileHeaderTemplate = this.textBox1.Text;
        }

        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBox1 = new TextBox();
            base.SuspendLayout();
            this.textBox1.Location = new Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(403, 303);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.textBox1);
            base.Name = "TemplateControl";
            base.Size = new Size(478, 358);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

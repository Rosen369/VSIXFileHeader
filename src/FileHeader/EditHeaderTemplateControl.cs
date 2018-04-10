using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rosen.FileHeader
{
    public class EditHeaderTemplateControl : UserControl
    {
        internal TemplateOptionPage OptionsPage;

        private IContainer components = null;

        private TextBox _tbTemplate;

        public EditHeaderTemplateControl()
        {
            this.InitializeComponent();
        }

        public void Initialize()
        {
            this._tbTemplate.Text = this.OptionsPage.FileHeaderTemplate;
        }

        private void _tbTemplate_Leave(object sender, EventArgs e)
        {
            this.OptionsPage.FileHeaderTemplate = this._tbTemplate.Text;
        }

        private void _tbTemplate_TextChanged(object sender, EventArgs e)
        {
            this.OptionsPage.FileHeaderTemplate = this._tbTemplate.Text;
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
            this._tbTemplate = new TextBox();
            base.SuspendLayout();
            this._tbTemplate.Location = new Point(3, 3);
            this._tbTemplate.Multiline = true;
            this._tbTemplate.Name = "textBox1";
            this._tbTemplate.Size = new Size(403, 303);
            this._tbTemplate.TabIndex = 0;
            this._tbTemplate.TextChanged += new EventHandler(this._tbTemplate_TextChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this._tbTemplate);
            base.Name = "TemplateControl";
            base.Size = new Size(478, 358);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

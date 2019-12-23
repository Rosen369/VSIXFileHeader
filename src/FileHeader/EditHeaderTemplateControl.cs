namespace Rosen.FileHeader
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// EditHeaderTemplateControl.
    /// </summary>
    public class EditHeaderTemplateControl : UserControl
    {
        private IContainer components = null;

        private TextBox tbTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditHeaderTemplateControl"/> class.
        /// </summary>
        public EditHeaderTemplateControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets OptionsPage.
        /// </summary>
        internal TemplateOptionPage OptionsPage { get; set; }

        /// <summary>
        /// Initialize.
        /// </summary>
        public void Initialize()
        {
            this.tbTemplate.Text = this.OptionsPage.FileHeaderTemplate;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void TbTemplate_Leave(object sender, EventArgs e)
        {
            this.OptionsPage.FileHeaderTemplate = this.tbTemplate.Text;
        }

        private void TbTemplate_TextChanged(object sender, EventArgs e)
        {
            this.OptionsPage.FileHeaderTemplate = this.tbTemplate.Text;
        }

        private void InitializeComponent()
        {
            this.tbTemplate = new TextBox();
            this.SuspendLayout();
            this.tbTemplate.Location = new Point(3, 3);
            this.tbTemplate.Multiline = true;
            this.tbTemplate.Name = "textBox1";
            this.tbTemplate.Size = new Size(403, 303);
            this.tbTemplate.TabIndex = 0;
            this.tbTemplate.TextChanged += new EventHandler(this.TbTemplate_TextChanged);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.tbTemplate);
            this.Name = "TemplateControl";
            this.Size = new Size(478, 358);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

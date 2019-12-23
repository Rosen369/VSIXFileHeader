namespace Rosen.FileHeader
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// TemplateOptionPage.
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class TemplateOptionPage : DialogPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateOptionPage"/> class.
        /// </summary>
        public TemplateOptionPage()
        {
            this.SetDefaultTemplate();
        }

        /// <summary>
        /// Gets or sets FileHeaderTemplate.
        /// </summary>
        [Category("FileHeader")]
        [Description("File Header Template")]
        [DisplayName("Template")]
        public string FileHeaderTemplate
        {
            get;
            set;
        }

        /// <inheritdoc/>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            get
            {
                EditHeaderTemplateControl editHeaderTemplateControl = new EditHeaderTemplateControl();
                editHeaderTemplateControl.OptionsPage = this;
                editHeaderTemplateControl.Initialize();
                return editHeaderTemplateControl;
            }
        }

        /// <summary>
        /// SetDefaultTemplate.
        /// </summary>
        public void SetDefaultTemplate()
        {
            this.FileHeaderTemplate = @"/*******************************************************
*
*
* FileName:$FileName$
* Author：Rosen
* CreateDate：$CreateTime$
* Description：This file contains only one class, for more details see type comments.$end$
* Runtime：.NET 4.7
* Version：1.0.0
*
* History
* CreateFile Frank $CreateTime$
*
*******************************************************/

";
        }
    }
}

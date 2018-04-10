using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rosen.FileHeader
{
    [ClassInterface(ClassInterfaceType.AutoDual), ComVisible(true)]
    public class TemplateOptionPage : DialogPage
    {
        [Category("FileHeader"), Description("File Header Template"), DisplayName("Template")]
        public string FileHeaderTemplate
        {
            get;
            set;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        public TemplateOptionPage()
        {
            this.FileHeaderTemplate = "/*******************************************************\r\n * \r\n * \r\n * FileName:$FileName$ \r\n * Author：Frank\r\n * CreateDate：$Today$\r\n * Description：此文件只包含一个类，具体内容见类型注释。$end$\r\n * Runtime：.NET 4.0\r\n * Version：1.0.0\r\n * \r\n * History：\r\n * CreateFile Frank $Now$\r\n * \r\n*******************************************************/\r\n\r\n";
        }
    }
}

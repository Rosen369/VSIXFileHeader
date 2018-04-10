using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frank.FileHeaderCommand
{
    [ClassInterface(ClassInterfaceType.AutoDual), ComVisible(true)]
    public class TemplateOptionPage : DialogPage
    {
        [Category("Frank"), Description("文件头模板"), DisplayName("文件头模板")]
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
            this.FileHeaderTemplate = "/*******************************************************\r\n * \r\n * \r\n * 文件名:$FileName$ \r\n * 作者：Frank\r\n * 创建日期：$Today$\r\n * 说明：此文件只包含一个类，具体内容见类型注释。$end$\r\n * 运行环境：.NET 4.0\r\n * 版本号：1.0.0\r\n * \r\n * 历史记录：\r\n * 创建文件 Frank $Now$\r\n * \r\n*******************************************************/\r\n\r\n";
        }
    }
}

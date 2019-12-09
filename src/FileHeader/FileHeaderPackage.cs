using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using System.IO;

namespace Rosen.FileHeader
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidFileHeaderPkgString)]
    [ProvideOptionPage(typeof(TemplateOptionPage), "FileHeader", "Template", 0, 0, true)]
    public sealed class FileHeaderPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public FileHeaderPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.guidFileHeaderCmdSet, (int)PkgCmdIDList.cmdidMyCommand);
                MenuCommand menuItem = new MenuCommand(MenuItemCallback, menuCommandID);
                mcs.AddCommand(menuItem);
            }
        }
        #endregion

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            var dTE = base.GetService(typeof(DTE)) as DTE;
            var activeDocument = dTE.ActiveDocument;
            if (activeDocument == null)
            {
                return;
            }

            var textSelection = activeDocument.Selection as TextSelection;
            if (textSelection == null)
            {
                return;
            }

            int absoluteCharOffset = textSelection.ActivePoint.AbsoluteCharOffset;
            textSelection.SelectAll();
            string text = textSelection.Text;
            textSelection.MoveToAbsoluteOffset(absoluteCharOffset, false);

            var template = this.ReplaceTemplate(activeDocument);

            textSelection.StartOfDocument(false);
            textSelection.Insert(template, 1);
            textSelection.StartOfDocument(false);
            textSelection.FindText("$end$", 0);
            textSelection.Delete(1);


        }

        private string ReplaceTemplate(Document document)
        {
            var templateOptionPage = GetDialogPage(typeof(TemplateOptionPage)) as TemplateOptionPage;
            var template = templateOptionPage.FileHeaderTemplate;
            var nowStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            var todayStr = DateTime.Now.ToString("yyyy/MM/dd");
            var fileCreateTime = this.GetCreateDateByPath(document.FullName);

            var fileName = document.Name;
            template = template
                .Replace("$Now$", nowStr)
                .Replace("$Today$", todayStr)
                .Replace("$FileName$", fileName)
                .Replace("$CreateTime$", fileCreateTime);

            return template;
        }

        private string GetCreateDateByPath(string path)
        {
            if (!File.Exists(path))
            {
                return string.Empty;
            }
            return File.GetCreationTime(path).ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}

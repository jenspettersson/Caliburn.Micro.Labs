using System.ComponentModel.Composition;
using Caliburn.Micro;
using ShellWithMenu.Desktop.Content.Pages;

namespace ShellWithMenu.Desktop.Content.Shell
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>, IShell
    {
        [Import(typeof(IStatusBarViewModel), AllowDefault = true)]
        public IStatusBarViewModel StatusBar { get; set; }

        [Import(typeof(IPageOneViewModel), AllowDefault = true)]
        public IPageOneViewModel PageOne { get; set; }

        [Import(typeof(IPageTwoViewModel), AllowDefault = true)]
        public IPageTwoViewModel PageTwo { get; set; }

        [Import(typeof(IPageThreeViewModel), AllowDefault = true)]
        public IPageThreeViewModel PageThree { get; set; }

        public void ShowPageOne()
        {
            ActivateItem(PageOne);
        }

        public void ShowPageTwo()
        {
            ActivateItem(PageTwo);
        }

        public void ShowPageThree()
        {
            ActivateItem(PageThree);
        }
    }
}
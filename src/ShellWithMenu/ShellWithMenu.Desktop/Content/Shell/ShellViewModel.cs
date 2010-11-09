using System.ComponentModel.Composition;
using Caliburn.Micro;
using ShellWithMenu.Desktop.Content.Pages;

namespace ShellWithMenu.Desktop.Content.Shell
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IScreen>, IShell
    {
        public void ShowPageOne()
        {
            ActivateItem(new PageOneViewModel());
        }

        public void ShowPageTwo()
        {
            ActivateItem(new PageTwoViewModel());
        }

        public void ShowPageThree()
        {
            ActivateItem(new PageThreeViewModel());
        }
    }
}
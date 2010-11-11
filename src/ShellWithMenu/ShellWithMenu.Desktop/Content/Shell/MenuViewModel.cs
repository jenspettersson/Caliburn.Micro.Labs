using System.ComponentModel.Composition;
using Caliburn.Micro;
using ShellWithMenu.Desktop.Content.Pages;

namespace ShellWithMenu.Desktop.Content.Shell
{
    [Export(typeof(IMenuViewModel))]
    public class MenuViewModel : Conductor<IScreen>, IMenuViewModel
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

    public interface IMenuViewModel
    {
    }
}
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using Caliburn.Micro;
using GameLibrary.WPF.Framework;
using GameLibrary.WPF.Framework.Results;
using GameLibrary.WPF.Model;

namespace GameLibrary.WPF.ViewModels
{
    [Export(typeof (AddGameViewModel)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddGameViewModel : Screen
    {
        private string _notes;
        private double _rating;
        private string _title;
        private bool _wasSaved;

        [Required]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
                NotifyOfPropertyChange(() => CanAddGame);
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                NotifyOfPropertyChange(() => Notes);
            }
        }

        public bool CanAddGame
        {
            get { return !string.IsNullOrEmpty(Title); }
        }

        public IEnumerable<IResult> AddGame()
        {
            CommandResult add = new AddGameToLibrary
            {
                Title = Title,
                Notes = Notes
            }.AsResult();

            _wasSaved = true;

            yield return add;
            yield return Show.Child<SearchViewModel>().In<IShell>();
        }

        public override void CanClose(System.Action<bool> callback)
        {
            base.CanClose(result =>
                              {
                                  if (!result) callback(false);

                                  //Note: It is not a good practice to call MessageBox.Show from a non-View class.
                                  //Note: Consider implementing a MessageBoxService.
                                  result = _wasSaved || MessageBox.Show(
                                      "Are you sure you want to cancel?  Changes will be lost.",
                                      "Unsaved Changes",
                                      MessageBoxButton.OKCancel
                                                            ) == MessageBoxResult.OK;

                                  callback(result);
                              });
        }
    }
}
using MyNotepad.DataLayer;
using System;
using System.Linq;

namespace MyNotepad.Logic
{
    /// <summary>
    /// Provides communication between Model and View for entering and validating new file`s name.
    /// </summary>
    public class NewFileNamePresenter : IPresenter
    {
        private readonly INewFileNameView _view;
        private readonly IRepository<File> _repository;
        /// <summary>
        /// Property for keeping entered new file`s name. If null name was not entered.
        /// </summary>
        public string NewFileName { get; private set; }

        public NewFileNamePresenter(INewFileNameView view, IRepository<File> repository)
        {
            _view = view;
            _repository = repository;

            _view.SetNewFileName += SetNewFileName;
        }

        /// <summary>
        /// Shows view, for entering new file`s name, as a dialog.
        /// </summary>
        public void Run()
        {
            _view.Show();
        }
        
        private void SetNewFileName(string fileName)
        {
            if (ValidateFileName(fileName))
            {
                NewFileName = fileName;
                _view.Close();
                _repository.Dispose();
            }
            else
            {
                _view.ShowError("Wrong input!");
            }
        }

        private bool ValidateFileName(string text)
        {
            return !String.IsNullOrEmpty(text) & !_repository.GetFileNamesList().Any(t => t.Equals(text));
        }

    }
}
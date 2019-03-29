using System.Collections.Generic;
using MyNotepad.DataLayer;

namespace MyNotepad.Logic
{
    /// <summary>
    /// Provides communication between Model and Main Views
    /// for selecting and opening file from database.
    /// </summary>
    public class OpenFilePresenter : IPresenter
    {
        private readonly IOpenFileView _view;
        private readonly IRepository<File> _repository;
        /// <summary>
        /// Property for keeping chosen file`s name. If null name was not chosen.
        /// </summary>
        public string ChosenFile { get; private set; }

        public OpenFilePresenter(IOpenFileView view, IRepository<File> repository)
        {
            _view = view;
            _repository = repository;

            _view.FormLoad += () => { return (List<string>) _repository.GetFileNamesList(); };
            _view.ChoseFile += ChoseFile;
        }

        /// <summary>
        /// Shows view, for selecting and opening file from database.
        /// </summary>
        public void Run()
        {
            _view.Show();
        }

        private void ChoseFile(string fileName)
        {
            ChosenFile = fileName;
            _view.Close();
            _repository.Dispose();
        }

    }
}
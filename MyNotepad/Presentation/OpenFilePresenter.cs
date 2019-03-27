using System.Collections.Generic;
using MyNotepad.DataLayer;

namespace MyNotepad.Logic
{
    public class OpenFilePresenter : IPresenter
    {
        private readonly IOpenFileView _view;
        private readonly IRepository<File> _repository;
        public string ChosenFile { get; private set; }

        public OpenFilePresenter(IOpenFileView view, IRepository<File> repository)
        {
            _view = view;
            _repository = repository;

            _view.FormLoad += () => { return (List<string>) _repository.GetFileNamesList(); };
            _view.ChoseFile += ChoseFile;
        }

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
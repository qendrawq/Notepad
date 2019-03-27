using MyNotepad.DataLayer;
using System;
using System.Linq;

namespace MyNotepad.Logic
{
    public class NewFileNamePresenter : IPresenter
    {
        private readonly INewFileNameView _view;
        private readonly IRepository<File> _repository;
        public string NewFileName { get; private set; }

        public NewFileNamePresenter(INewFileNameView view, IRepository<File> repository)
        {
            _view = view;
            _repository = repository;

            _view.SetNewFileName += SetNewFileName;
        }

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
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using MyNotepad.DataLayer;
using MyNotepad.Forms;
using File = MyNotepad.DataLayer.File;


namespace MyNotepad.Logic
{
    public class NotepadPresenter : IPresenter
    {
        private readonly INotepadView _view;
        private readonly IRepository<File> _repository;
        private File CurrentFile { get; set; }
        private bool HasChanged { get; set; }

        public NotepadPresenter(INotepadView view, IRepository<File> repository)
        {
            _view = view;
            _repository = repository;
            HasChanged = false;

            _view.SaveFile += SaveFile;
            _view.OpenFile += OpenFile;
            _view.NewFile += () => NewFile();
            _view.ApplicationStop += () => _repository.Dispose();
            _view.FormatChanged += (t) => CurrentFile.Format = t;
            _view.TextBoxDataChanged += ApplyHighlights;
        }

        private void ApplyHighlights(FastColoredTextBox textBox)
        {

        }

        public void Run()
        {
            _view.Show();
        }

        private async void SaveFile(string data)
        {
            if (CurrentFile == null)
            {
                var newFileNamePresenter= new NewFileNamePresenter(new EnterFileNameForm(), new FileRepository());
                newFileNamePresenter.Run();

                if (!String.IsNullOrEmpty(newFileNamePresenter.NewFileName))
                {
                    CurrentFile = new File()
                    {
                        Name = newFileNamePresenter.NewFileName,
                        Data = Compression.CompressToByteArray(data, newFileNamePresenter.NewFileName)
                    };
                    await _repository.CreateAsync(CurrentFile);
                }
            }
            else
            {
                CurrentFile.Data = Compression.CompressToByteArray(data, CurrentFile.Name);
                _repository.Update(CurrentFile);
            }
            _repository.Save();
        }

        private async Task<string> OpenFile()
        {
            string result = null;
            var openFilePresenter = new OpenFilePresenter(new OpenFileForm(), new FileRepository());
            openFilePresenter.Run();

            if (!String.IsNullOrEmpty(openFilePresenter.ChosenFile))
            {
                CurrentFile = await _repository.GetFileByNameAsync(openFilePresenter.ChosenFile);
                result = Compression.ExtractToString(CurrentFile.Data);
            }
            return result;
        }

        private void NewFile()
        {
            if (CurrentFile != null)
            {
                var result = MessageBox.Show(
                    "All unsaved data will be lost! Do you want to continue?",
                    "Create new file",
                    MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    return;
            }

            CurrentFile = null;
            HasChanged = false;
        }
    }
}
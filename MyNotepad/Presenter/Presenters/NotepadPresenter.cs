using System;
using System.Threading.Tasks;
using MyNotepad.DataLayer;
using MyNotepad.Forms;
using ScintillaNET;
using File = MyNotepad.DataLayer.File;

namespace MyNotepad.Logic
{
    /// <summary>
    /// Provides communication between Model and Main Views for work with files.
    /// </summary>
    public class NotepadPresenter : IPresenter, IDisposable
    {
        private readonly INotepadView _view;
        private readonly IRepository<File> _repository;
        private File CurrentFile { get; set; }

        public NotepadPresenter(INotepadView view, IRepository<File> repository)
        {
            _view = view;
            _repository = repository;
            CurrentFile = new File();

            _view.SaveFile += SaveFile;
            _view.OpenFile += OpenFile;
            _view.NewFile += NewFile;
            _view.ApplicationStop += Dispose;
            _view.FormatChanged += ApplyHighlights;
        }

        private void ApplyHighlights(Scintilla textBox, Format format)
        {
            if (format != Format.Default)
            {
                CurrentFile.Format = format;
            }

            switch (CurrentFile.Format)
            {
                case Format.Xml:
                    Highlighter.HighlightXml(textBox);
                    break;
                case Format.Json:
                    Highlighter.HighlightJson(textBox);
                    break;
                case Format.Txt:
                    Highlighter.HighlightTxt(textBox);
                    break;
            }
        }

        /// <summary>
        /// Shows view, for work with files.
        /// </summary>
        public void Run()
        {
            _view.Show();
        }

        private async void SaveFile(string data)
        {
            if (String.IsNullOrEmpty(CurrentFile.Name))
            {
                var newFileNamePresenter= new NewFileNamePresenter(new EnterFileNameForm(), new FileRepository());
                newFileNamePresenter.Run();

                if (!String.IsNullOrEmpty(newFileNamePresenter.NewFileName))
                {
                    CurrentFile.Name = newFileNamePresenter.NewFileName;
                    CurrentFile.Data = Compression.CompressToByteArray(data, newFileNamePresenter.NewFileName);

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
            CurrentFile = new File();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
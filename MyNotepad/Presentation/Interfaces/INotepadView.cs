using System;
using System.Threading.Tasks;
using ScintillaNET;

namespace MyNotepad.Logic
{
    public interface INotepadView : IView
    {
        event Action<string> SaveFile;
        event Func<Task<string>> OpenFile;
        event Action NewFile;
        event Action ApplicationStop;
        event Action<Scintilla,Format> FormatChanged;

        void ShowError(string errorMessage);
    }
}
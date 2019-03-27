using FastColoredTextBoxNS;
using MyNotepad.DataLayer;
using System;
using System.Threading.Tasks;

namespace MyNotepad.Logic
{
    public interface INotepadView : IView
    {
        event Action<string> SaveFile;
        event Func<Task<string>> OpenFile;
        event Action NewFile;
        event Action ApplicationStop;
        event Action<Format> FormatChanged;
        event Action<TextChangedEventArgs> TextBoxDataChanged;


        void ShowError(string errorMessage);
    }
}
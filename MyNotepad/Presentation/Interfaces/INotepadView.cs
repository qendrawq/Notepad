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
        event Action<string> FormatChanged;
        event Action<FastColoredTextBox> TextBoxDataChanged;


        void ShowError(string errorMessage);
    }
}
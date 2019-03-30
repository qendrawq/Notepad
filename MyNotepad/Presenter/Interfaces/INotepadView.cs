using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotepad.Logic
{
    public interface INotepadView : IView
    {
        event Action<string> SaveFile;
        event Func<Task<string>> OpenFile;
        event Action NewFile;
        event Action ApplicationStop;
        event Action<Control,Format> FormatChanged;

        void ShowError(string errorMessage);
    }
}
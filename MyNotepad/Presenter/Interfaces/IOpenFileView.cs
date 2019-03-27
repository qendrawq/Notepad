using System;
using System.Collections.Generic;

namespace MyNotepad.Logic
{
    public interface IOpenFileView : IView
    {
        event Action<string> ChoseFile;
        event Func<List<string>> FormLoad;

        void ShowError(string errorMessage);
    }
}
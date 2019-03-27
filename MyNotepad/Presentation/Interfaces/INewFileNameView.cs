using System;

namespace MyNotepad.Logic
{
    public interface INewFileNameView : IView
    {
        event Action<string> SetNewFileName;

        void ShowError(string errorMessage);
    }
}
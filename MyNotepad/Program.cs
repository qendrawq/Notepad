using System;
using System.Windows.Forms;
using MyNotepad.DataLayer;
using MyNotepad.Logic;

namespace MyNotepad
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var presenter = new NotepadPresenter(new NotepadForm(), new FileRepository());
            presenter.Run();
        }
    }
}

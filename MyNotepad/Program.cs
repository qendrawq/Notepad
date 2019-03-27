using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var presenter = new NotepadPresenter(new NotepadForm(), new FileRepository()); // Dependency Injection
            presenter.Run();
            //Application.Run(new Form1());
        }
    }
}

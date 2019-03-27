using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyNotepad.Logic;

namespace MyNotepad.Forms
{
    public partial class OpenFileForm : Form, IOpenFileView, IView
    {
        public event Action<string> ChoseFile;
        public event Func<List<string>> FormLoad;

        public OpenFileForm()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            listBox1.DataSource = FormLoad();
        }

        private void FileClick(object sender, MouseEventArgs e)
        {
            ChoseFile(listBox1.SelectedItem.ToString());
        }

        public new void Show()
        {
            ShowDialog();
        }

        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }
    }
}

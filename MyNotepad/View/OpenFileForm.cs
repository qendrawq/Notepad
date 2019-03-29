using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyNotepad.Logic;

namespace MyNotepad.Forms
{
    /// <summary>
    /// Form for opening file from Database
    /// </summary>
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

        private void OkButtonClick(object sender, EventArgs e)
        {
            ChoseFile(listBox1.SelectedItem.ToString());
        }

        /// <summary>
        /// Opens form as a dialog
        /// </summary>
        public new void Show()
        {
            ShowDialog();
        }

        /// <summary>
        /// Show error message in messagebox
        /// </summary>
        /// <param name="errorMessage">Message to dispaly </param>
        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

    }
}

using System;
using System.Windows.Forms;
using MyNotepad.Logic;

namespace MyNotepad.Forms
{
    /// <summary>
    /// Form for entering and validating new file name
    /// </summary>
    public partial class EnterFileNameForm : Form, INewFileNameView
    {
        public event Action<string> SetNewFileName;

        public EnterFileNameForm()
        {
            InitializeComponent();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            SetNewFileName(fileNameTextBox.Text);           
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
        /// <param name="errorMessage"> Message to dispaly </param>
        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }
    }
}

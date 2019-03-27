using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotepad.DataLayer;
using MyNotepad.Logic;

namespace MyNotepad.Forms
{
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

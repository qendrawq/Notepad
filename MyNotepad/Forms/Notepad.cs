using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyNotepad.Logic;
using ScintillaNET;

namespace MyNotepad
{
    public partial class NotepadForm : Form, INotepadView
    {
        private bool HasChanged { get; set; }

        public event Action<string> SaveFile;
        public event Func<Task<string>> OpenFile;
        public event Action NewFile;
        public event Action ApplicationStop;
        public event Action<Scintilla, Format> FormatChanged;
        public event Action<Scintilla> TextBoxDataChanged;

        public NotepadForm()
        {
            InitializeComponent();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasChanged)
            {
                var window = MessageBox.Show(
                    "Do you want save file?",
                    "Notepad Closing",
                    MessageBoxButtons.YesNoCancel);

                switch (window)
                {
                    case DialogResult.Yes:
                        SaveFile(dataTextBox.Text);
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            ApplicationStop();
        }

        private void NewMenuItemClick(object sender, EventArgs e)
        {
            if (HasChanged)
            {
                var result = MessageBox.Show(
                    "All unsaved data will be lost! Do you want to continue?",
                    "Create new file",
                    MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                    return;

            }

            NewFile();
            dataTextBox.Text = "";
            HasChanged = false;
        }
        private void OpenMenuItemClick(object sender, EventArgs e)
        {
            dataTextBox.Text = OpenFile().Result;
            FormatChanged(dataTextBox, Format.Default);
            HasChanged = false;
        }
        private void SaveMenuItemClick(object sender, EventArgs e)
        {
            SaveFile(dataTextBox.Text);
            HasChanged = false;
        }

        public new void Show()
        {
            Application.Run(this);
        }
        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        private void TxtFormatMenuItem_Click(object sender, EventArgs e)
        {
            FormatChanged(dataTextBox, Format.Txt);
            TextBox_TextChanged(dataTextBox, null);
        }
        private void XmlFormatMenuItem_Click(object sender, EventArgs e)
        {
            FormatChanged(dataTextBox, Format.Xml);
            TextBox_TextChanged(dataTextBox, null);
        }
        private void JsonFormatMenuItem_Click(object sender, EventArgs e)
        {
            FormatChanged(dataTextBox, Format.Json);
            TextBox_TextChanged(dataTextBox, null);
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {            
            try
            {
                TextBoxDataChanged(dataTextBox);
                HasChanged = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}

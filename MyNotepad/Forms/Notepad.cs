using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using ICSharpCode.SharpZipLib.Zip;
using MyNotepad.DataLayer;
using MyNotepad.Forms;
using MyNotepad.Logic;
using File = MyNotepad.DataLayer.File;

namespace MyNotepad
{
    public partial class NotepadForm : Form, INotepadView
    {
        public event Action<string> SaveFile;
        public event Func<Task<string>> OpenFile;
        public event Action NewFile;
        public event Action ApplicationStop;
        public event Action<Format> FormatChanged;
        public event Action<TextChangedEventArgs> TextBoxDataChanged;

        public NotepadForm()
        {
            InitializeComponent();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            //if (CurrentFile != null)
            //{
            //    var window = MessageBox.Show(
            //        "Do you want save file?",
            //        "Notepad Closing",
            //        MessageBoxButtons.YesNoCancel);

            //    switch (window)
            //    {
            //        case DialogResult.Yes:
            //            SaveFile(dataRichTextBox.Text);
            //            break;
            //        case DialogResult.Cancel:
            //            e.Cancel = true;
            //            break;
            //    }
            //}
        }
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            ApplicationStop();
        }
       
        private void NewMenuItemClick(object sender, EventArgs e)
        {
            NewFile();
            dataTextBox.Clear();
        }
        private void OpenMenuItemClick(object sender, EventArgs e)
        {
            dataTextBox.Text = OpenFile().Result;
        }
        private void SaveMenuItemClick(object sender, EventArgs e)
        {
            SaveFile(dataTextBox.Text);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveFile(dataTextBox.Text);
                e.SuppressKeyPress = true;
            }
        }

        public new void Show()
        {
            Application.Run(this);
        }
        public void ShowError(string errorMessage)
        {
            throw new NotImplementedException();
        }

        private void TxtFormatMenuItem_Click(object sender, EventArgs e)
        {
            dataTextBox.Language = Language.Custom;
            FormatChanged(Format.Txt);
        }
        private void XmlFormatMenuItem_Click(object sender, EventArgs e)
        {
            dataTextBox.Language = Language.XML;
            FormatChanged(Format.Xml);
        }
        private void JsonFormatMenuItem_Click(object sender, EventArgs e)
        {
            dataTextBox.Language = Language.Custom;
            FormatChanged(Format.Json);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {            
            try
            {
                TextBoxDataChanged(e);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}

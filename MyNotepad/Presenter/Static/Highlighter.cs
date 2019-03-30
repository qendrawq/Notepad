using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyNotepad.Logic
{
    /// <summary>
    /// Static class for applying styles for highliting syntax
    /// </summary>
    static public class Highlighter
    {
        static private readonly string xmlTags = @"<.*?>";
        static private readonly string xmlComments = @"{{! .*? }}";
        static private readonly string jsonText = "\".*?\"";
        static private readonly Color originalColor = Color.Black;

        /// <summary>
        /// Apply highlighting
        /// </summary>
        /// <param name="textArea">Richtexbox object</param>
        /// <param name="type">Format type to be applyed</param>
        static public void Apply(RichTextBox textArea, Format type)
        {
            int originalIndex = textArea.SelectionStart;
            int originalLength = textArea.SelectionLength;

            switch (type)
            {
                case Format.Txt:
                    HighlightTxt(textArea);
                    break;
                case Format.Json:
                    HighlightJson(textArea);
                    break;
                case Format.Xml:
                    HighlightXml(textArea);
                    break;
            }

            textArea.SelectionStart = originalIndex;
            textArea.SelectionLength = originalLength;
            textArea.SelectionColor = originalColor;
        }

        /// <summary>
        /// Apply xml syntax highlighting
        /// </summary>
        /// <param name="textArea">Richtexbox object</param>
        static private void HighlightXml(RichTextBox textArea)
        {
            MatchCollection tagMatches = Regex.Matches(textArea.Text, xmlTags, RegexOptions.Compiled);
            MatchCollection commentMatches = Regex.Matches(textArea.Text, xmlComments, RegexOptions.Multiline);

            foreach (Match m in tagMatches)
            {
                textArea.SelectionStart = m.Index;
                textArea.SelectionLength = m.Length;
                textArea.SelectionColor = Color.Blue;
            }

            foreach (Match m in commentMatches)
            {
                textArea.SelectionStart = m.Index;
                textArea.SelectionLength = m.Length;
                textArea.SelectionColor = Color.Green;
            }
        }
        /// <summary>
        /// Apply json syntax highlighting
        /// </summary>
        /// <param name="textArea">Richtexbox object</param>
        static private void HighlightJson(RichTextBox textArea)
        {
            MatchCollection textMatches = Regex.Matches(textArea.Text, jsonText, RegexOptions.Compiled);

            foreach (Match m in textMatches)
            {
                textArea.SelectionStart = m.Index;
                textArea.SelectionLength = m.Length;
                textArea.SelectionColor = Color.Brown;
            }
        }
        /// <summary>
        /// Reset styles
        /// </summary>
        /// <param name="textArea">Richtexbox object</param>
        static private void HighlightTxt(RichTextBox textArea)
        {
            textArea.SelectionStart = 0;
            textArea.SelectionLength = textArea.Text.Length;
            textArea.SelectionColor = originalColor;
        }
    }
}
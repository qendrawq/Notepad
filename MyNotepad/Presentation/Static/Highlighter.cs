using FastColoredTextBoxNS;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotepad.Logic
{
    static public class Highlighter
    {
        static private FontStyle style = FontStyle.Regular;
        static private TextStyle blue = new TextStyle(Brushes.LightBlue, null, style);
        static private TextStyle red = new TextStyle(Brushes.Red, null, style);
        static private TextStyle green = new TextStyle(Brushes.Green, null, style);

        static public void HighlightXml(TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(blue, red, green);
            e.ChangedRange.SetStyle(blue, "<.*?>");
            e.ChangedRange.SetStyle(red, "{{(?!!)(?!GUID).*?}}");
            e.ChangedRange.SetStyle(green, "{{! .*? }}");
        }

        static public void HighlightJson(RichTextBox textBox)
        {

        }
    }
}
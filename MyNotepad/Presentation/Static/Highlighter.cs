using FastColoredTextBoxNS;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyNotepad.Logic
{
    static public class Highlighter
    {
        //XML
        static private FontStyle style = FontStyle.Regular;
        static private TextStyle blue = new TextStyle(Brushes.Blue, null, style);
        static private TextStyle red = new TextStyle(Brushes.Red, null, style);
        static private TextStyle green = new TextStyle(Brushes.Green, null, style);

        //JSON
        static private TextStyle key = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        static private TextStyle str = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        static private TextStyle boo = new TextStyle(Brushes.DarkBlue, null, FontStyle.Regular);
        static private TextStyle nul = new TextStyle(Brushes.DarkGray, null, FontStyle.Regular);


        static public void HighlightXml(TextChangedEventArgs e)
        {

            //e.ChangedRange.ClearStyle(blue, red, green);
            //e.ChangedRange.SetStyle(blue, "<.*?>");
            //e.ChangedRange.SetStyle(red, "{{(?!!)(?!GUID).*?}}");
            //e.ChangedRange.SetStyle(green, "{{! .*? }}");
        }

        static public void HighlightJson(TextChangedEventArgs e)
        {

            //e.ChangedRange.ClearStyle(blue, red, green);
            //e.ChangedRange.SetStyle(blue, "\".*?\"");
        }
    }
}
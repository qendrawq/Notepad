using System.Drawing;
using ScintillaNET;

namespace MyNotepad.Logic
{
    static public class Highlighter
    {
        static public void HighlightXml(Scintilla textArea)
        {
            textArea.StyleResetDefault();
            textArea.StyleClearAll();

            textArea.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
            textArea.Styles[Style.Xml.Entity].ForeColor = Color.Red;
            textArea.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            textArea.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
            textArea.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
            textArea.Styles[Style.Xml.DoubleString].ForeColor = Color.DeepPink;
            textArea.Styles[Style.Xml.SingleString].ForeColor = Color.DeepPink;

            textArea.Lexer = Lexer.Xml;
        }

        static public void HighlightJson(Scintilla textArea)
        {
            textArea.StyleResetDefault();
            textArea.StyleClearAll();

            textArea.Styles[Style.Json.Default].ForeColor = Color.Silver;
            textArea.Styles[Style.Json.BlockComment].ForeColor = Color.FromArgb(0, 128, 0);
            textArea.Styles[Style.Json.LineComment].ForeColor = Color.FromArgb(0, 128, 0);
            textArea.Styles[Style.Json.Number].ForeColor = Color.Olive;
            textArea.Styles[Style.Json.PropertyName].ForeColor = Color.Blue;
            textArea.Styles[Style.Json.String].ForeColor = Color.FromArgb(163, 21, 21);
            textArea.Styles[Style.Json.StringEol].BackColor = Color.Pink;
            textArea.Styles[Style.Json.Operator].ForeColor = Color.Purple;

            textArea.Lexer = Lexer.Json;
        }

        static public void HighlightTxt(Scintilla textArea)
        {
            textArea.StyleResetDefault();
            textArea.StyleClearAll();
            textArea.Lexer = Lexer.Null;
        }

    }
}
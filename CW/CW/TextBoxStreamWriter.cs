using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    // inherit the TextWriter class in order to override the Write function
    public class TextBoxStreamWriter : TextWriter
    {
        // declare the TextBox in which text will be appended
        TextBox outputTextBox = null;

        // constructor, requiring the textbox to which text will be output
        public TextBoxStreamWriter(TextBox output)
        {
            // constructor requires the TextBox in which text will be appended
            outputTextBox = output;
        }

        // overriding console write method to also add values to the textbox
        public override void Write(char value)
        {
            // when executing Write, first run Write as it normally would (outputting text to the console), then append that text into the specified TextBox
            base.Write(value);
            outputTextBox.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }

        // ensure all encoding is UTF8
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}

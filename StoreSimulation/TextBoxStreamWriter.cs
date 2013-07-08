using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace StoreSimulation
{
    public class TextBoxStreamWriter : TextWriter
    {
        TextBox output = null;

        public TextBoxStreamWriter(TextBox output){
            this.output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            if (this.output.InvokeRequired)
            {
                AppendCallback c = new AppendCallback(output.AppendText);
                output.Invoke(c, new Object[] { value.ToString() });
            }
            else
            {
                output.AppendText(value.ToString());
            }
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }

        delegate void AppendCallback(String value);
    }
}

using Eto.Forms;
using Eto.Drawing;
using Eto.Platform.Wpf;
using Eto.Platform.Wpf.Forms;
using Eto.Platform.Wpf.Drawing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using swf = System.Windows.Forms;

namespace TestApplicationforWinformCalEto.cs
{
    public class MyTextBoxHandler : WindowsFormHostHandler<swf.TextBox, TextBox>, ITextBox
    {
        swf.TextBox textBox;
        bool textChanging;

        public MyTextBoxHandler() : base(new swf.TextBox())
        {
            
            textBox = swfControl;
            PlaceholderText = null;
            textBox.Text = null;
            textBox.TextChanged += delegate //fix placeholder text.
            {
                Widget.OnTextChanged(EventArgs.Empty);
            };
        }
        
        public int MaxLength
        {
            get { return textBox.MaxLength; }
            set { textBox.MaxLength = value; }
        }

        [Obsolete("This Feature is not supported in System.Windows.Forms.")]
        public string PlaceholderText { get; set; }

        public bool ReadOnly
        {
            get { return textBox.ReadOnly; }
            set { textBox.ReadOnly = value; }
        }

        public void SelectAll()
        {
            textBox.Focus();
            textBox.SelectAll();
        }

        public string Text
        {
            get { return textBox.Text; }
            set
            {
                textChanging = true;
                textBox.Text = value;
                if (value != null)
                    textBox.TabIndex = value.Length; //.CaretIndex DNE, textChanging was declared at the top.
                textChanging = false;
            }
        }
    }
}
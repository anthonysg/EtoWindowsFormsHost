using System;
using System.IO;
using System.Text;

using Eto.Drawing;
using Eto.Forms;

namespace TestApplicationforWinformCalEto.cs
{
    class MainForm : Form
    {
        public MainForm()
        {
            this.ClientSize = new Size(700, 500);
            this.WindowState = WindowState.Normal;
            this.Title = "User Info";
            this.TopMost = true;
            var rootLayout = new DynamicLayout(this);
            var dateTimePicker = new DateTimePicker
            { 
               Font = new Font(FontFamilies.SansFamilyName, 20, FontStyle.Bold)
            };
            dateTimePicker.MaxDate = DateTime.Now;
            dateTimePicker.MinDate = new DateTime(1900, 1, 1);
            dateTimePicker.Mode = DateTimePickerMode.Date;
            dateTimePicker.Value = new DateTime(1980, 1, 1);
            
            var textBox = new TextBox()
            {
                Font = new Font(FontFamilies.SansFamilyName, 12, FontStyle.Italic)
            };
            //textBox.PlaceholderText = "This is Placeholder Text.";
            textBox.MaxLength = 5;

            rootLayout.Add(dateTimePicker);
            rootLayout.Add(textBox);
            rootLayout.Add(new Panel());
        }
    }
}
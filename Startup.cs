using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eto.Forms;
using Eto.Drawing;

namespace TestApplicationforWinformCalEto.cs
{
        class MainClass : Application
        {
            [STAThread]
            public static void Main(string[] args)
            {
                var generator = new Eto.Platform.Wpf.Generator();
                generator.Add<IDateTimePicker>(() => new MyDateTimePickerHandler());
                generator.Add<ITextBox>(() => new MyTextBoxHandler());

                var app = new Application(generator);

                app.Initialized += delegate
                {
                    app.MainForm = new MainForm();
                    app.MainForm.Show();
                };
                app.Run(args);

            }
        }
    }
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
    public class WindowsFormHostHandler<C, W> : WpfFrameworkElement<swf.Integration.WindowsFormsHost, W>
        where C : System.Windows.Forms.Control
        where W : Control
    {
        protected C swfControl;

        public WindowsFormHostHandler(C swfControl)
        {
            this.swfControl = swfControl;

            Control = new swf.Integration.WindowsFormsHost();
            Control.Child = this.swfControl;
        }

        public override Color BackgroundColor
        {
            get
            {
                var brush = Control.Background as System.Windows.Media.SolidColorBrush;
                if (brush != null)
                    return brush.Color.ToEto();
                else
                    return Colors.Transparent;
            }
            set
            {
                Control.Background = new System.Windows.Media.SolidColorBrush(value.ToWpf());
            }
        }

        Font font;
        public Font Font
        {
            get
            {
                if (font == null)
                    font = new Font(Widget.Generator, new FontHandler(Widget.Generator, Control.FontFamily, Control.FontSize, Control.FontStyle, Control.FontWeight));
                return font;
            }
            set
            {
                font = value;
                FontHandler fh = ((FontHandler)font.Handler);

                Control.FontFamily = fh.WpfFamily;
                Control.FontSize = fh.PixelSize;
                Control.FontStyle = fh.WpfFontStyle;
                Control.FontWeight = fh.WpfFontWeight;
            }
        }
    }
}

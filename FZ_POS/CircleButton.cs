using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace FZ_POS
{
    class CircleButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(2, 2, this.Width - 6, this.Height - 6);
            Graphics g = pevent.Graphics;
            g.DrawEllipse(new Pen(Color.Black, 2), 2, 2, this.Width - 6, this.Height - 6);
            Region = new Region(path);
        }
    }
}

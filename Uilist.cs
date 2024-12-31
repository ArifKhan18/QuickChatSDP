using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickChat
{
    internal class Uilist
    {
        public static int GetTextHeight(TextBox lbl)
        {
            using (Graphics g = lbl.CreateGraphics())
            {
                SizeF size = g.MeasureString(lbl.Text , lbl.Font, 495);
                return (int)Math.Ceiling(size.Height);
            }
        }
    }
}

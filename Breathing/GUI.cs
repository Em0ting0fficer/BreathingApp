using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Breathing
 * Ziele:
 * - Animierte Ellipse
 * - Graphische Textausgabe
 * - Menü
 * - About-Dialog
 * Max Rosegger
 * 09.03.2018*/

namespace Breathing
{
    public partial class GUI : Form
    {
        float size;
        float height;
        float width;
        bool isCircleGrowing = true;
        const int minSize = 10;
        float maxSize;       

        public GUI()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            size = 10;
            height = ClientSize.Height / 2 - size / 2;
            width = ClientSize.Width / 2 - size / 2;
            isCircleGrowing = true;
        }

        private void GUI_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Green);
            myPen.Width = 10;
            RectangleF circle = new RectangleF(width, height, size, size);
            g.DrawEllipse(myPen, circle);
        }

        private void tmrBreath_Tick(object sender, EventArgs e)
        {
            int margin = mainMenu.Height*3;
            float smallerSide = Math.Min(ClientSize.Width, ClientSize.Height);
            maxSize = smallerSide - margin;
            if (size < maxSize && isCircleGrowing)
            {
                size+=smallerSide / 100;
                height-= smallerSide / 100 / 2;
                width -= smallerSide / 100 / 2;
            }
            else if (size >= maxSize)
            {
                isCircleGrowing = false;
            }

            if (size > minSize && !isCircleGrowing)
            {
                size-=smallerSide / 100;
                height += smallerSide / 100 / 2;
                width += smallerSide / 100 / 2;
            }
            else if (size <= minSize)
            {
                isCircleGrowing = true;
            }
            Invalidate();
        }

        private void GUI_Resize(object sender, EventArgs e)
        {
            height = ClientSize.Height / 2 - size / 2;
            width = ClientSize.Width / 2 - size / 2;
            if (size > maxSize)
            {
                size = maxSize;
            }
            if (size < minSize)
            {
                size = minSize;
            }
        }
    }
}

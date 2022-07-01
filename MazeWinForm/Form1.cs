using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MazeWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void print(int[,] lab, int sz)
        {
            Graphics g = this.CreateGraphics();
            int x = 20;
            int xo = 20, yo = 20;
            for (int i = 0; i < sz; i++)
            {
                xo = x;
                for (int j = 0; j < sz; j++)
                {
                    if (lab[i, j] == 1)
                    {
                        g.FillRectangle(Brushes.Red, new Rectangle(yo, xo, 15, 15));
                    }
                    else
                    {
                        g.FillRectangle(Brushes.LightSkyBlue, new Rectangle(yo, xo, 15, 15));
                    }
                    xo += 15;
                }
                yo += 15;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.FromArgb(0, 0, 0));
            Laberint la = new Laberint(35);
            la.start();
            print(la.Laberi, la.Saiz);
        }
    }
}

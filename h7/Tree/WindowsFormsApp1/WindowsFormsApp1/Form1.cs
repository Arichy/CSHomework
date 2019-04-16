using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
        double k;
        private void button1_Click(object sender, EventArgs e)
        {
            th1 = double.Parse(textBox2.Text) * Math.PI / 180;
            th2 = double.Parse(textBox1.Text) * Math.PI / 180;
            per1 = double.Parse(textBox4.Text);
            per2 = double.Parse(textBox3.Text);
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 150, 350, 100, -Math.PI / 2);
        }
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0,double y0,double x1, double y1)
        {
            string SelectValues = checkedListBox1.SelectedItem.ToString();
            switch(SelectValues)
            {
                case "Blue":
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Red":
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Green":
                    graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Gray":
                    graphics.DrawLine(Pens.Gray, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Black":
                    graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "Yellow":
                    graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                default:
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
            
        }
    }
}

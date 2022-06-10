using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labacs12
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }

        Label[] lb = new Label[6];
        TextBox[] tb = new TextBox[6];
        Graphics g;
        Graphics gfx;
        PointF[] pt = new PointF[3];
        PointF[] ptFi = new PointF[3];
        static PointF pt0;
        Pen p1 = new Pen(Color.Black);
        float fii;
        float coeff;
        int numClick;
        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
            gfx.Clear(Color.White);
            gfx.DrawPie(Pens.Black, 100, 100, 100, 100, 0, 90);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
            gfx.Clear(Color.White);
            Point point1 = new Point(50, 50);
            Point point2 = new Point(150, 150);
            Point point3 = new Point(250, 150);
            Point point4 = new Point(150, 50);
            Point[] curvePoints = { point1, point2, point3, point4 };
            gfx.DrawPolygon(Pens.Black, curvePoints);
            gfx.FillPolygon(Brushes.LightPink, curvePoints);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
            gfx.Clear(Color.White);
            Point point1 = new Point(85, 5);
            Point point2 = new Point(35, 35);
            Point point3 = new Point(5, 35);
            Point point4 = new Point(5, 5);
            Point[] curvePoints = { point1, point2, point3, point4 };
            gfx.DrawPolygon(Pens.Black, curvePoints);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
            gfx.Clear(Color.White);
            gfx.DrawEllipse(Pens.Black, 100, 50, 80, 40);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            gfx = pictureBox1.CreateGraphics();
            gfx.Clear(Color.White);
            Point point1 = new Point(0, 0);
            Point point2 = new Point(50, 50);
            Point[] curvePoints = { point1, point2 };
            gfx.DrawPolygon(Pens.Black, curvePoints);
            gfx.FillPolygon(Brushes.Green, curvePoints);
            point1 = new Point(50, 0);
            point2 = new Point(0, 50);
            Point[] Points = { point1, point2 };
            gfx.DrawPolygon(Pens.Black, Points);
            gfx.FillPolygon(Brushes.Green, Points);
            point1 = new Point(50, 0);
            point2 = new Point(100, 50);
            Point[] points = { point1, point2 };
            gfx.DrawPolygon(Pens.Black, points);
            gfx.FillPolygon(Brushes.Green, points);
            point1 = new Point(50, 50);
            point2 = new Point(100, 0);
            Point[] oints = { point1, point2 };
            gfx.DrawPolygon(Pens.Black, oints);
            gfx.FillPolygon(Brushes.Green, oints);
            point1 = new Point(0, 50);
            point2 = new Point(50, 50);
            Point[] ints = { point1, point2, };
            gfx.DrawPolygon(Pens.Black, ints);
            gfx.FillPolygon(Brushes.Green, ints);
            point1 = new Point(50, 50);
            point2 = new Point(100, 50);
            Point[] nts = { point1, point2, };
            gfx.DrawPolygon(Pens.Black, nts);
            gfx.FillPolygon(Brushes.Green, nts);
            point1 = new Point(100, 0);
            point2 = new Point(100, 50);
            Point[] ts = { point1, point2, };
            gfx.DrawPolygon(Pens.Black, ts);
            gfx.FillPolygon(Brushes.Green, ts);

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            fii = coeff * (float)Math.PI;
            for (int i1 = 0; i1 < 3; i1++)
            {
                ptFi[i1] = Triangle_Top(fii, pt[i1]);
            }
            g.DrawPolygon(p1, ptFi);
            coeff += 0.05f;
            if (coeff == 2)
                coeff = 0;

        }
        static PointF Triangle_Top(float fi, PointF ptt)
        {
            float dx = ptt.X - pt0.X;
            float dy = ptt.Y - pt0.Y;
            float dxn = dx * (float)Math.Cos(fi) - dy * (float)Math.Sin(fi);
            float dyn = dx * (float)Math.Sin(fi) + dy * (float)Math.Cos(fi);
            PointF pt = new PointF(pt0.X + dxn, pt0.Y + dyn);
            return pt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                lb[i] = new Label();
                lb[i].Location = new Point(10, 45 + 30 * i);
                lb[i].Size = new Size(25, 25);
                if (i % 2 == 0)
                    lb[i].Text = "x" + (i / 2 + 1);
                else
                    lb[i].Text = "y" + (i / 2 + 1);
                lb[i].TextAlign = ContentAlignment.MiddleCenter;
                Controls.Add(lb[i]);

                tb[i] = new TextBox();
                tb[i].Location = new Point(40, 45 + 30 * i);
                tb[i].Size = new Size(35, 25);
                tb[i].TextAlign = HorizontalAlignment.Center;
                tb[i].ReadOnly = true;
                Controls.Add(tb[i]);
            }
            numClick = 0;
            g = panel1.CreateGraphics();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            for (int i = 0; i < 3; i++)
                pt[i] = new PointF(float.Parse(tb[2 * i].Text), float.Parse(tb[2 * i + 1].Text));
            g.DrawPolygon(p1, pt);
            pt0 = new PointF((pt[0].X + pt[1].X + pt[2].X) / 3.0f, (pt[0].Y + pt[1].Y + pt[2].Y) / 3.0f);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            coeff = 0;
            timer1.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            timer1.Stop();
            coeff = 0;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            tb[2 * numClick].Text = e.X.ToString();
            tb[2 * numClick + 1].Text = e.Y.ToString();
            numClick += 1;
            if (numClick == 3)
                numClick = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer2_Tick(sender, e);
            timer2.Start();
            button11.Visible = true;
            label1.Enabled = true;
            label1.Visible = true;
            label1.BringToFront();
            label1.BackColor = Color.White;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (count == 0)
            {
                System.Threading.Thread.Sleep(300);
            }
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            Pen myPen = new Pen(Color.Black, 7);
            gfx.Clear(Color.White);
            gfx.DrawEllipse(Pens.Black, 175, 20, 100, 100);
            gfx.DrawEllipse(Pens.Black, 175, 120, 100, 200);
            gfx.DrawEllipse(Pens.Black, 115, 20, 70, 100);
            gfx.DrawEllipse(Pens.Black, 270, 20, 70, 100);
            gfx.DrawEllipse(Pens.Black, 220, 70, 20, 70);
            gfx.DrawEllipse(Pens.Black, 150, 270, 60, 100);
            gfx.DrawEllipse(Pens.Black, 230, 250, 60, 100);
            gfx.DrawEllipse(Pens.Black, 175, 150, 40, 40);
            gfx.DrawEllipse(Pens.Black, 235, 150, 40, 60);
            gfx.DrawEllipse(Pens.Black, 240, 35, 5, 7);
            gfx.DrawEllipse(Pens.Black, 210, 35, 5, 7);
            pictureBox1.Image = bmp;
            count++;
            if (count == 8)
            {
                gfx.Clear(Color.White);
                gfx.DrawEllipse(Pens.Black, 175, 20, 100, 100);
                gfx.DrawEllipse(Pens.Black, 175, 120, 100, 200);
                gfx.DrawEllipse(Pens.Black, 115, 30, 70, 100);
                gfx.DrawEllipse(Pens.Black, 270, 30, 70, 100);
                gfx.DrawEllipse(Pens.Black, 220, 75, 20, 70);
                gfx.DrawEllipse(Pens.Black, 150, 250, 60, 100);
                gfx.DrawEllipse(Pens.Black, 230, 270, 60, 100);
                gfx.DrawEllipse(Pens.Black, 175, 150, 40, 60);
                gfx.DrawEllipse(Pens.Black, 235, 150, 40, 40);
                gfx.DrawEllipse(Pens.Black, 240, 35, 5, 7);
                gfx.DrawEllipse(Pens.Black, 210, 35, 5, 7);
                pictureBox1.Image = bmp;
                count = 0;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Hide();
            timer2.Stop();
            gfx = pictureBox1.CreateGraphics();
            gfx.Clear(Color.White);
            label1.Visible = false;
        }
    }
}

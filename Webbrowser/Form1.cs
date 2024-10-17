using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webbrowser
{
    public partial class Form1 : Form
    {
        int tex = 3;
        int dex = 4;
        bool is_move = false;
        int x = 0, y = 0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width)/2, textBox1.Location.Y);
        }
        private async void move()
        {
            await Task.Run(() =>
            {
                while (is_move)
                {
                    if (WindowState == FormWindowState.Maximized)
                        if (x != Cursor.Position.X || y != Cursor.Position.Y)
                        {
                            x = Size.Width / 2;
                            y = 0;
                        }
                    Location = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
                }
            });
        }
        private void resize_window_wh(Size size)
        {
            Size = size;
            panel1.Size = new Size(Size.Width, panel1.Size.Height);
            button1.Location = new Point(Size.Width - button1.Size.Width - 4, button1.Location.Y);
            button2.Location = new Point(button1.Location.X - button2.Size.Width, button2.Location.Y);
            button3.Location = new Point(button2.Location.X - button3.Size.Width, button3.Location.Y);
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width) / 2, textBox1.Location.Y);
        }
        private void resize_window_wh(int width, int height)
        {
            Size size = new Size(width, height);
            Size = size;
            panel1.Size = new Size(Size.Width, panel1.Size.Height);
            button1.Location = new Point(Size.Width - button1.Size.Width - 4, button1.Location.Y);
            button2.Location = new Point(button1.Location.X - button2.Size.Width, button2.Location.Y);
            button3.Location = new Point(button2.Location.X - button3.Size.Width, button3.Location.Y);
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width) / 2, textBox1.Location.Y);
        }
        private void resize_window_mwh(Size size)
        {
            Size = size;
            panel1.Size = new Size(Size.Width, panel1.Size.Height);
            button1.Location = new Point(Size.Width - button1.Size.Width - 4, button1.Location.Y);
            button2.Location = new Point(button1.Location.X - button2.Size.Width, button2.Location.Y);
            button3.Location = new Point(button2.Location.X - button3.Size.Width, button3.Location.Y);
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width) / 2, textBox1.Location.Y);
        }
        private void resize_window_mwh(int width, int height)
        {
            Size size = new Size(width, height);
            Size = size;
            panel1.Size = new Size(Size.Width, panel1.Size.Height);
            button1.Location = new Point(Size.Width - button1.Size.Width - 4, button1.Location.Y);
            button2.Location = new Point(button1.Location.X - button2.Size.Width, button2.Location.Y);
            button3.Location = new Point(button2.Location.X - button3.Size.Width, button3.Location.Y);
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width) / 2, textBox1.Location.Y);
        }
        private void maximize()
        {
            WindowState = FormWindowState.Maximized;
            panel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width, panel1.Size.Height);
            button1.Location = new Point(Screen.PrimaryScreen.Bounds.Width - button1.Size.Width - 4, button1.Location.Y);
            button2.Location = new Point(button1.Location.X - button2.Size.Width, button2.Location.Y);
            button3.Location = new Point(button2.Location.X - button3.Size.Width, button3.Location.Y);
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width) / 2, textBox1.Location.Y);
            panel2.Enabled = false;
            panel2.Visible = false;
            panel3.Enabled = false;
            panel3.Visible = false;
            panel4.Enabled = false;
            panel4.Visible = false;
            panel5.Enabled = false;
            panel5.Visible = false;
            panel6.Enabled = false;
            panel6.Visible = false;
            panel7.Enabled = false;
            panel7.Visible = false;
            panel8.Enabled = false;
            panel8.Visible = false;
            panel9.Enabled = false;
            panel9.Visible = false;
        }
        private void normal()
        {
            WindowState = FormWindowState.Normal;
            panel1.Size = new Size(Size.Width, panel1.Size.Height);
            button1.Location = new Point(Size.Width - button1.Size.Width - 4, button1.Location.Y);
            button2.Location = new Point(button1.Location.X - button2.Size.Width, button2.Location.Y);
            button3.Location = new Point(button2.Location.X - button3.Size.Width, button3.Location.Y);
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width) / 2, textBox1.Location.Y);
            panel2.Enabled = true;
            panel2.Visible = true;
            panel3.Enabled = true;
            panel3.Visible = true;
            panel4.Enabled = true;
            panel4.Visible = true;
            panel5.Enabled = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Enabled = true;
            panel7.Visible = true;
            panel8.Enabled = true;
            panel8.Visible = true;
            panel9.Enabled = true;
            panel9.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                normal();
            else if (WindowState == FormWindowState.Normal)
                maximize();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            is_move = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            is_move = true;
            x = e.Location.X; y = e.Location.Y;
            move();
        }
    }
}

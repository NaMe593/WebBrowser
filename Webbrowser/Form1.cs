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
using Webbrowser.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Webbrowser
{
    public partial class Form1 : Form
    {
        int tex = 2;
        int dex = 4;
        bool is_move = false;
        int x = 0, y = 0, y2 = 0, x2 = 0;
        bool is_size = false;
        Point pi = new Point();
        public Form1()
        {
            InitializeComponent();
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width)/2, textBox1.Location.Y);
            button4.BackgroundImage = Resources.qwe1;
            button5.BackgroundImage = Resources.qwe;
            button6.BackgroundImage = Resources.qwe2;
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
                            normal();
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
            panel10.Size = new Size(Size.Width - 8, Size.Height - 54);
            panel1.Size = new Size(Size.Width, panel1.Size.Height);
            panel4.Size = new Size(Size.Width, panel4.Size.Height);
            panel4.Location = new Point(0, Size.Height - 4);
            panel5.Size = new Size(Size.Width, panel5.Size.Height);
            panel3.Location = new Point(Size.Width - 4, 0);
            panel3.Size = new Size(panel3.Size.Width, Size.Height);
            panel2.Size = new Size(panel2.Size.Width, Size.Height);
            panel2.Location = new Point(0, 0);
            panel7.Location = new Point(panel1.Size.Width - 4, panel7.Location.Y);
            panel9.Location = new Point(Size.Width - 4, Size.Height - 4);
            button1.Location = new Point(Size.Width - button1.Size.Width - 4, button1.Location.Y);
            button2.Location = new Point(button1.Location.X - button2.Size.Width, button2.Location.Y);
            button3.Location = new Point(button2.Location.X - button3.Size.Width, button3.Location.Y);
            textBox1.Size = new Size(panel1.Size.Width / dex * tex, textBox1.Size.Height);
            textBox1.Location = new System.Drawing.Point((panel1.Size.Width - textBox1.Size.Width) / 2, textBox1.Location.Y);
            panel8.Location = new Point(0, Size.Height - 4);
        }
        private void maximize()
        {
            WindowState = FormWindowState.Maximized;
            panel10.Location = new Point(0, 50);
            panel10.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 50);
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
            panel10.Location = new Point(4, 50);
            panel10.Size = new Size(Size.Width - 8, Size.Height - 54);
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
        private async void resize(int oo)
        {
            await Task.Run(() =>
            {
                while (is_size)
                {
                     if(oo == 0)
                    {
                        resize_window_wh(new Size(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y));
                    }
                    if(oo == 2)
                    {
                        resize_window_wh(new Size(Cursor.Position.X - Location.X, Size.Height));
                    }
                    if(oo == 1)
                    {
                        resize_window_wh(new Size(Size.Width, Cursor.Position.Y - Location.Y));
                    }
                }
            });
        }
        private async void resizem(bool i)
        {
            await Task.Run(() =>
            {
                while (is_size)
                {
                    if (i)
                    {
                        if (!(x2 - Cursor.Position.X <= 4))
                        {
                            resize_window_wh(new Size(x2 - Cursor.Position.X, y2 - Cursor.Position.Y));
                            Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                        }
                    }
                }
            });
        }
        private async void resizemb(bool i)
        {
            await Task.Run(() =>
            {
                while (is_size)
                {
                    if (i)
                    {
                        if (!(x2 - Cursor.Position.X <= 4))
                        {
                            resize_window_wh(new Size(x2 - Cursor.Position.X, Size.Height));
                            Location = new Point(Cursor.Position.X, Location.Y);
                        }
                    }
                }
            });
        }private async void resizembb(bool i)
        {
            await Task.Run(() =>
            {
                while (is_size)
                {
                    if (i)
                    {
                        if (!(x2 - Cursor.Position.X <= 4))
                        {
                            resize_window_wh(new Size(Size.Width, y2 - Cursor.Position.Y));
                            Location = new Point(Location.X, Cursor.Position.Y);
                        }
                    }
                }
            });
        }
        private async void resizembbb(bool i)
        {
            await Task.Run(() =>
            {
                while (is_size)
                {
                    if (i)
                    {
                        if (!(x2 - Cursor.Position.X <= 4))
                        {
                            resize_window_wh(new Size(Size.Width, y2 - Cursor.Position.Y));
                            Location = new Point(Location.X, Cursor.Position.Y);
                        }
                    }
                }
            });
        }
        private async void resizembbbb(bool i)
        {
            await Task.Run(() =>
            {
                while (is_size)
                {
                    if (i)
                    {
                        if (!(x2 - Cursor.Position.X <= 4))
                        {
                            resize_window_wh(new Size(x2 - Cursor.Position.X, Cursor.Position.Y - Location.Y));
                            Location = new Point(Cursor.Position.X, Location.Y);
                        }
                    }
                }
            });
        }private async void resizembbbbb(bool i)
        {
            await Task.Run(() =>
            {
                while (is_size)
                {
                    if (i)
                    {
                        resize_window_wh(new Size(Cursor.Position.X - Location.X, y2 - Cursor.Position.Y));
                        Location = new Point(Location.X, Cursor.Position.Y);
                    }
                }
            });
        }
        private void res(object sender, MouseEventArgs e)
        {
            pi = e.Location;
            Panel p = (Panel)sender;
            is_size = true;
            if (p.Tag == "lde")
            {
                y2 = Size.Height + Location.Y; x2 = Size.Width + Location.X;
                resizembbbb(true);
            }
            if (p.Tag == "ld")
            {
                y2 = Size.Height + Location.Y; x2 = Size.Width + Location.X;
                resizemb(true);
            }
            if (p.Tag == "pde")
            {
                resize(2);
            }
            if (p.Tag == "pd")
            {
                resize(0);
            }
            if (p.Tag == "dd")
            {
                resize(1);
            }
            if (p.Tag == "vd")
            {
                y2 = Size.Height + Location.Y; x2 = Size.Width + Location.X;
                resizembb(true);
            }if (p.Tag == "lv")
            {
                y2 = Size.Height + Location.Y; x2 = Size.Width + Location.X;
                resizem(true);
            }
            if (p.Tag == "pv")
            {
                y2 = Size.Height + Location.Y; x2 = Size.Width + Location.X;
                resizembbbbb(true);
            }
        }
        private void r(object sender, MouseEventArgs e)
        {
            is_size = false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;          //Library
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_Quiz_Game
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void animal_Click(object sender, EventArgs e)
        {
            
            //Form f = new Form5();
            //Hide();
            //f.sString = "Hello";

           // f.Show();
            // f.getfiles();
            Form5 frm2 = new Form5();
            frm2.sString = "Animals";
            frm2.sString2 = "ANIMAL GAME";
            frm2.sString3 = "ANIMAL";
            frm2.ShowDialog();
          //  this.Hide();


        }

        private void bird_Click(object sender, EventArgs e)
        {
            Form5 frm2 = new Form5();
            frm2.sString = "Actions";
            frm2.sString2 = "ACTIONS GAME";
            frm2.sString3 = "ACTIONS";
            frm2.ShowDialog();
          //  this.Hide();

        }

        private void color_Click(object sender, EventArgs e)
        {
            Form5 frm2 = new Form5();
            frm2.sString = "Food";
            frm2.sString2 = "FOOD GAME";
            frm2.sString3 = "FOOD";
            frm2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm2 = new Form5();
            frm2.sString = "Home";
            frm2.sString2 = "HOME GAME";
            frm2.sString3 = "HOME";
            frm2.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bus_Management_System
{
    public partial class Form2 : Form
    {
     
       
        public Form2()
       
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form4 d = new Form4();
            this.Hide();
            d.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

          
           Form6 u = new Form6();
            this.Hide();
            u.Show();
         




                
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            this.Hide();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 a = new Form1();
            a.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

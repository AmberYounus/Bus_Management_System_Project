using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Bus_Management_System
{
    public partial class Form8 : Form
    {
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
        private string text1;
        private string text2;
        private string text3;


        public string Text1
        {
            get { return text1; }
            set { text1 = value; }
        }
        public string Text2
        {
            get { return text2; }
            set { text2 = value; }
        }
        public string Text3
        {
            get { return text3; }
            set { text3 = value; }
        }
        public Form8()
        {
            InitializeComponent();
        }
        void removeBG(PictureBox pb, PictureBox pb2)
        {
            var pos = this.PointToScreen(pb2.Location);
            pos = pb.PointToClient(pos);
            pb2.Parent = pb;
            pb2.Location = pos;
            pb2.BackColor = Color.Transparent;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form7 h = new Form7();
            h.Show();


        }

        private void Form8_Load(object sender, EventArgs e)
        {
            materialTextBox1.Text = Form7.setvalueText1;
            materialTextBox2.Text = Form7.setvalueText2;
   //        materialTextBox3.Text = Form7.setvalueText3;
    //     materialTextBox4.Text = Form7.setvalueText4;
            materialTextBox5.Text = Form7.setvalueText5;
            materialTextBox6.Text = Form7.setvalueText6;
    //    materialTextBox7.Text = Form7.setvalueText7;

            materialTextBox8.Text = Form7.setvalueText8;

            materialTextBox3.Text = Text1;
            materialTextBox4.Text = Text2;
            materialTextBox7.Text = Text3;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form7 h = new Form7();
            h.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.bust_ticket1;
                Image newImage = bmp;
            e.Graphics.DrawImage(newImage, 20, 20 ,newImage.Width,newImage.Height);
        //    e.Graphics.DrawString("Bus Ticket" , new Font("Century Gothic", 14, FontStyle.Regular), Brushes.Black, new Point(20, 180));

            e.Graphics.DrawString("CutomerName:  " + materialTextBox1.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 220));
            e.Graphics.DrawString("CNIC:  " + materialTextBox2.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 260));
            e.Graphics.DrawString("Destination:  " + materialTextBox3.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 300));
            e.Graphics.DrawString("Source:  " + materialTextBox4.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 340));
            e.Graphics.DrawString("Timing:  " + materialTextBox5.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 380));
            e.Graphics.DrawString("Date:  " + materialTextBox6.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 420));
            e.Graphics.DrawString("Seat Number:  " + materialTextBox7.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 460));
            e.Graphics.DrawString("Total Price:  " + materialTextBox8.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 500));
            e.Graphics.DrawString(dashLabel.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 700));
         //   e.Graphics.DrawString(thankLabel.Text, new Font("Century Gothic", 18, FontStyle.Bold), Brushes.Black, new Point(10, 680));




        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1; //Associate PrintPreviewDialog with PrintDocument.
            printPreviewDialog1.ShowDialog(); // Show PrintPreview Dialog
        }

        private void materialTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   materialComboBox3.Items.Add("Seat Number").ToString();
        }
    }
}

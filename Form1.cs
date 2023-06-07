using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Speech.Recognition;
namespace Bus_Management_System
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechRecognitionEngine reEngine = new SpeechRecognitionEngine();

        public Form1()
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
        private void Form1_Load(object sender, EventArgs e)
        {
           

        }
        private void ReEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "name": materialTextBox1.Text += ("amber");
                    break;



               
            }
        }
        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                



                case "password":
                    materialTextBox2.Text += ("12345");

                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        

            string conString = "server=localhost; user id=root ; password= Mysql@Password125 ; database=cnic";
            string loginQuery = "SELECT * FROM login WHERE UserName='" + materialTextBox1.Text + "' and Password='" + materialTextBox2.Text + "'";
            MySqlConnection con = new MySqlConnection(conString);
            MySqlCommand cmd = new MySqlCommand(loginQuery, con);
            MySqlDataReader reader;
            int count = 0;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    count = count + 1;

                }
                if (count >= 1)
                {
                    Form2 a = new Form2();
                    a.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username & password ");
                    materialTextBox1.Text = "";
                    materialTextBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get Value due to " + ex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 c = new Form3();
            c.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
           button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            button2.Enabled = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void materialTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "name" });
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(commands);
            Grammar grammmer = new Grammar(gbuilder);

            recEngine.LoadGrammarAsync(grammmer);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += ReEngine_SpeechRecognized;

            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            //button2.Enabled = true;
        }

        private void materialTextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "password" });
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(commands);
            Grammar grammmer = new Grammar(gbuilder);

            recEngine.LoadGrammarAsync(grammmer);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;

            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}

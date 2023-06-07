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
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Bus_Management_System
{
    public partial class Form5 : Form
    {
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
      
       
        public Form5()
        {
            InitializeComponent();
        }
        public int busID; 

        private void Form5_Load(object sender, EventArgs e)
        {
            //disp_data();
        }
        private bool Isvalid()
        {


            if (materialTextBox1.Text == string.Empty)
            {
                MessageBox.Show("BusId is required", "FAILED", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                return false;
            }
            return true;

        }
        private void clearTxts()
        {
            materialTextBox1.Clear();
          
            materialTextBox4.Clear();
       

        }
        private void retrieve()
        {
            dataGridView1.Rows.Clear();

        }
        private void getRecords()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM bus_detail", con);
            DataTable dataTable = new DataTable();
            con.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dataTable.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dataTable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Isvalid())
            {
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");

                MySqlCommand cmd = new MySqlCommand("INSERT INTO bus_detail VALUES(@BusId,@DepatureForm,@ArrivalAt,@ArrivalTime)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@BusId", materialTextBox1.Text);
                cmd.Parameters.AddWithValue("@DepatureForm", materialComboBox1.Text);
                cmd.Parameters.AddWithValue("@ArrivalAt", materialComboBox2.Text);
                cmd.Parameters.AddWithValue("@ArrivalTime", materialTextBox4.Text);
              


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record has Saved", "SAVED", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                getRecords();

            }
        }
        public void disp_data()
        {
            // con.Open();
            //  MySqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //  cmd.CommandText = "SELECT FROM bus_detail";
            /// cmd.ExecuteNonQuery();
            // DataTable dt = new DataTable();
            //  MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //  da.Fill(dt);
            //  dataGridView1.DataSource = dt;
            //  con.Close();

            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM bus_detail", con);
            DataTable dataTable = new DataTable();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dataTable.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dataTable;

        }
    
           

        private void button4_Click(object sender, EventArgs e)
        {
            if (busID > 0)
            {

                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");

                //     MySqlCommand cmd = new MySqlCommand("UPDATE customer_record SET CustomerName =@CustomerName , NIC=@NIC , sources =@sources , Destination =@Destination , SeatNumber =@SeatNumber , Dates =@Dates , Timing =@Timing ,Price =@Price WHERE Id =@ID", con);
                MySqlCommand cmd = new MySqlCommand("update bus_detail SET DepatureForm='" + this.materialComboBox1.Text + "',ArrivalAt='" + this.materialComboBox2.Text + "',ArrivalTime='" + this.materialTextBox4.Text + "' where BusId='" + this.materialTextBox1.Text + "';", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@BusId", this.busID);
                cmd.Parameters.AddWithValue("@DepatureForm", materialComboBox1.Text);
                cmd.Parameters.AddWithValue("@ArrivalAt", materialComboBox2.Text);
                cmd.Parameters.AddWithValue("@ArrivalTime", materialTextBox4.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record has Updated", "UPDATE", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                getRecords();

            }
            else
            {
                MessageBox.Show("Record has not Updated", "SELECT", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            // MySqlCommand cmd = con.CreateCommand();
            //  cmd.CommandType = CommandType.Text;
            //   cmd.CommandText = "SELECT FROM bus_detail";
            //  cmd.ExecuteNonQuery();
            //  DataTable dt = new DataTable();
            //  MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            // da.Fill(dt);
            //  dataGridView1.DataSource = dt;




          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (busID > 0)

            {

                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
                MySqlCommand cmd = new MySqlCommand("DELETE FROM driver_detail WHERE where BusId='" + this.materialTextBox1.Text + "';", con);
                //      MySqlCommand cmd = new MySqlCommand("DELETE FROM driver_detail WHERE DriverId=@DriverId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BusId", this.busID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record has Deleted", "DELETED", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                getRecords();

            }
            else
            {
                MessageBox.Show("Record has not Deleted", "SELECT", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 c = new Form3();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //     getRecord();
            disp_data();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            materialTextBox1.Text = " ";
            materialComboBox1.Text = " ";
            materialComboBox2.Text = " ";
            materialTextBox4.Text = " ";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();

                materialTextBox1.Text = a.Text;

              materialComboBox1.Text = a.Text;
              materialComboBox2.Text = a.Text;
                materialTextBox4.Text = a.Text;
             



            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                b.UnloadAllGrammars();

            }
        }

        private void materialTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();

                materialTextBox1.Text = a.Text;

            




            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                b.UnloadAllGrammars();

            }
        }

        private void materialTextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();

              

                //materialTextBox2.Text = a.Text;
             




            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                b.UnloadAllGrammars();

            }
        }

        private void materialTextBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();

        
                //materialTextBox3.Text = a.Text;
            




            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                b.UnloadAllGrammars();

            }
        }

        private void materialTextBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();

             
                materialTextBox4.Text = a.Text;




            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                b.UnloadAllGrammars();

            }
        }

        private void materialComboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();


              materialComboBox1.Text = a.Text;




            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                b.UnloadAllGrammars();

            }
        }

        private void materialComboBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();


                materialComboBox2.Text = a.Text;




            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                b.UnloadAllGrammars();

            }
        }
        public void searchData(string valueToSearch)
        {
         
            string query = "SELECT * FROM bus_detail WHERE CONCAT(`BusId`, `DepatureForm`,  `ArrivalAt` , `ArrivalTime`) like '%" + valueToSearch + "%'";
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            string valueToSearch = materialTextBox2.Text.ToString();
            searchData(valueToSearch);
       

        }

        private void materialTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Form4 : Form
    {

        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
        //MySqlCommand command;
       



        MySqlDataAdapter adapter;
        public int driverId;
        public Form4()
        {
            InitializeComponent();
        }
        public void openConnnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closeConnnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void executeQuery(string query)
        {
            try
            {
                openConnnection();
         //       command = new MySqlCommand(query, con);
               // if(command.ExecuteNonQuery() == 1)
               // {
                 //   MessageBox.Show("query executer");

             //   }
           //     else
             //   {
             //       MessageBox.Show("not executed");
             //   }
//
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnnection();
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            searchData("");
        }
        private void getRecords()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM driver_detail", con);
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

            MySqlCommand cmd = new MySqlCommand("INSERT INTO driver_detail VALUES(@DriverId,@DriverName,@DriverNIC,@DriverSalary,@DriverAge)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@DriverId", materialTextBox1.Text);
             cmd.Parameters.AddWithValue("@DriverName", materialTextBox2.Text);
               cmd.Parameters.AddWithValue("@DriverNIC", materialTextBox3.Text);
              cmd.Parameters.AddWithValue("@DriverSalary", materialTextBox4.Text);
               cmd.Parameters.AddWithValue("@DriverAge", materialTextBox5.Text);


               con.Open();
                cmd.ExecuteNonQuery();
             con.Close();

               MessageBox.Show("Record has Saved", "SAVED", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                getRecords();
              
            }
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

       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (driverId > 0)

            {
               
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
                MySqlCommand cmd = new MySqlCommand("DELETE FROM driver_detail WHERE where DriverId='" + this.materialTextBox1.Text + "';" , con);
          //      MySqlCommand cmd = new MySqlCommand("DELETE FROM driver_detail WHERE DriverId=@DriverId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DriverId", this.driverId);

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




          

            //////string deleteQuery = "DELETE FROM  driver_detail WHERE DriverId=" +materialTextBox1.Text;
          ////////  executeQuery(deleteQuery);
        }
        private void clearTxts()
        {
            materialTextBox1.Clear();
            materialTextBox2.Clear();
            materialTextBox3.Clear();
            materialTextBox4.Clear();
            materialTextBox5.Clear();
            //   materialTextBox5.Text = "";

        }
        private void retrieve()
        {
            dataGridView1.Rows.Clear();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (driverId > 0)
            {
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
                MySqlCommand cmd = new MySqlCommand("UPDATE driver_detail SET DriverName='" + this.materialTextBox2.Text + "',DriverNIC='" + this.materialTextBox3.Text + "',DriverSalary='" + this.materialTextBox4.Text + "',DriverAge='" + this.materialTextBox5.Text  + "' where DriverId = '" + this.materialTextBox1.Text + "';", con);

                //      MySqlCommand cmd = new MySqlCommand("UPDATE driver_detail SET DriverName=@DriverName ,DriverNIC=@DriverNIC ,DriverSalary=@DriverSalary ,DriverAge=@DriverAge WHERE DriverId=@DriverId", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@DriverId", this.driverId);
                cmd.Parameters.AddWithValue("@DriverName", materialTextBox2.Text);
                cmd.Parameters.AddWithValue("@DriverNIC", materialTextBox3.Text);
                cmd.Parameters.AddWithValue("@DriverSalary", materialTextBox4.Text);
                cmd.Parameters.AddWithValue("@DriverAge", materialTextBox5.Text);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record has Updated", "UPDATE", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                getRecords();
                reset();
            }
            else
            {
                MessageBox.Show("Record has not Updated", "SELECT", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
           // MySqlCommand cmd = new MySqlCommand("UPDATE driver_detail SET DriverName= '" + materialTextBox2.Text + "',DriverNIC= '" + materialTextBox3.Text + "', DriverSalary= '" + materialTextBox4.Text + "' ,DriverAge= "+int.Parse(materialTextBox5.Text) + " WHERE DriverId= " +int.Parse(materialTextBox1.Text), con);
          //  cmd.CommandType = CommandType.Text;

         //   con.Open();
          //  try
        //    {
                     //  MySqlCommand cmd = new MySqlCommand(updateQuery, con);
            
           //     if (cmd.ExecuteNonQuery() == 1)
           //     {
            //        MessageBox.Show("Record has Updated", "UPDATE", MessageBoxButtons.OK,
                //    MessageBoxIcon.Information);
             //   }
          //      else
           //     {
             //       MessageBox.Show("not updated");

           //     }
               
        //    }
        //    catch(Exception ex)
         //   {
          //      MessageBox.Show(ex.Message);
          //  }
          //  finally
          //  {
           //     con.Close();
          //  }          

        }
        private void reset()
        {
            this.materialTextBox1.Text = "";
            this.materialTextBox2.Text = "";
            this.materialTextBox3.Text = "";
            this.materialTextBox4.Text = "";
            this.materialTextBox5.Text = "";

            materialTextBox1.Focus();
            

        }
        private void button5_Click(object sender, EventArgs e)
        {
            getRecords();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
             Form3 c = new Form3();
            c.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            materialTextBox1.Text = " ";
            materialTextBox2.Text = " ";
            materialTextBox3.Text = " ";
            materialTextBox4.Text = " ";
            materialTextBox5.Text = " ";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            driverId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            materialTextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            materialTextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            materialTextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            materialTextBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            materialTextBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
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

           

                materialTextBox2.Text = a.Text;
          




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

               
                materialTextBox3.Text = a.Text;
            




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

        }

        private void materialTextBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();

                materialTextBox5.Text = a.Text;

                



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
            
   
               string query = "SELECT * FROM driver_detail WHERE CONCAT(`DriverId`, `DriverName`, `DriverNIC`, `DriverSalary` , `DriverAge`) like '%" + valueToSearch + "%'";
          MySqlCommand  command = new MySqlCommand(query, con);
           MySqlDataAdapter adapter = new MySqlDataAdapter(command);
          DataTable  table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

    
        private void button7_Click(object sender, EventArgs e)
        {
            string valueToSearch = materialTextBox6.Text.ToString();
            searchData(valueToSearch);
        }
    }
}


    


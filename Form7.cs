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
using System.Security.Cryptography;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace Bus_Management_System
{
    public partial class Form7 : Form
    {
        public static string setvalueText1;
        public static string setvalueText2;
        public static string setvalueText3;
        public static string setvalueText4;
        public static string setvalueText5;
        public static string setvalueText6;
        public static string setvalueText7;
        public static string setvalueText8;
        public static string SelectedItem;
        public int ID;
        ListViewItem itm;

        //     List<string> l1;
        //   string selectedItemText;
        //int SelectedIndex;
        //  public class PrintDocument : System.ComponentModel.Component
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
        List<string> values = null;
        MySqlCommand command = null;
        protected List<string> list = new List<string>();
        //Exception! Object reference not set to an instance of an object
        //    command.ExecuteNonQuery();
        public Form7()
        {
            InitializeComponent();

            string[] arr = { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10", "A11", "A13", "A14", "A15", "A16" };
            checkedListBox1.Items.AddRange(arr);
        }

        private void materialCheckbox14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 c = new Form3();
            c.Show();
        }
        private void reset()
        {
            this.materialTextBox1.Text = "";
            this.materialTextBox2.Text = "";
            this.materialTextBox3.Text = "";
            this.materialTextBox4.Text = "";
            this.materialTextBox5.Text = "";
          this.materialComboBox1.Text= "";
            this.materialComboBox2.Text = "";

            this.materialComboBox3.Text= "";
            materialTextBox1.Focus();


        }
        private void Form7_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            //Add column header
            listView1.Columns.Add("Arrival_time", 100);
            listView1.Columns.Add("Price", 70);


            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm;

            //Add first item
            arr[0] = "9:00:00 A.M.";
            arr[1] = "780";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            //Add second item
            arr[0] = "3:00:00 P.M.";
            arr[1] = "940";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            //Add third item
            arr[0] = "11:00:00 A.M.";
            arr[1] = "600";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);

            //Add forth item
            arr[0] = "6:00:00 P.M.";
            arr[1] = "898";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
            //Add forth item
            arr[0] = "8:00:00 P.M.";
            arr[1] = "798";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
            //Add forth item
            arr[0] = "12:00:00 P.M.";
            arr[1] = "998";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
            //Add forth item
            arr[0] = "7:00:00 P.M.";
            arr[1] = "1098";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
        }

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            setvalueText1 = materialTextBox2.Text;
            setvalueText2 = materialTextBox3.Text;
            setvalueText3 = materialComboBox2.Items.Add("Source").ToString();
            setvalueText4 = materialComboBox1.Items.Add("Destination").ToString();

            // setvalueText4 = materialComboBox1.SelectedText;

            setvalueText6 = dateTimePicker1.Text;
            //   selectedItemText = listBox1.SelectedItem.ToString();
            // SelectedIndex = listBox1.SelectedIndex;
            //  listBox1.Items.Add(selectedItemText);
            // setvalueText7 = selectedItemText;
            //if (l1 != null)
            //{
            //  l1.RemoveAt(SelectedIndex);
            //}
            //    DataBinding();
            setvalueText7 = materialComboBox3.Items.Add("Seat Number").ToString();
            setvalueText8 = materialTextBox4.Text;
            setvalueText5 = materialTextBox5.Text;

            Form8 k = new Form8();
            k.Text1 = materialComboBox1.Text;
            k.Text2 = materialComboBox2.Text;
            k.Text3 = materialComboBox3.Text;

            k.Show();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Arrival_time = null;
            string price = null;

            if (listView1.SelectedItems.Count == 0)
                return;
            //   Arrival_time = listView1.SelectedItems(0).Index(0);
            Arrival_time = listView1.SelectedItems[0].SubItems[0].Text;
            price = listView1.SelectedItems[0].SubItems[1].Text;
            MessageBox.Show(Arrival_time + " , " + price);


        }

        private void button6_Click(object sender, EventArgs e)
        {

            //     PrintDialog pDlg = new PrintDialog();
            //     PrintDocument pDoc = new PrintDocument();
            //     pDoc.DocumentName = "Print Document";
            //  pDlg.Document = pDoc;
            //  pDlg.AllowSelection = true;
            //  pDlg.AllowSomePages = true;
            //   if (pDlg.ShowDialog() == DialogResult.OK)
            //   {
            //   pDoc.Print();
            //    }
            //   else
            //  {
            //    MessageBox.Show("Print Cancelled");
            //  }

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            listView1.Show();
        }

        private void materialCheckedListBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            foreach (Object item in checkedListBox1.SelectedItems)
              {
           listBox1.Items.Add(item);
          }

        }

        private void materialTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            itm = null;
            if (itm != null && itm.SubItems != null)
            {
                //  string Aival_time = itm.SubItems;
                //   itm.SubItems.
                //  string arrival_time = listView1.SelectedItems[0].SubItems[0].Text;
                //  string Price = listView1.SelectedItems[0].SubItems[1].Text;
                //  listBox1.Items.Trim();
            }
            string arrival_time = listView1.SelectedItems[0].SubItems[0].Text;
            string Price = listView1.SelectedItems[0].SubItems[1].Text;

            materialTextBox5.Text = arrival_time;
            materialTextBox4.Text = Price;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 c = new Form3();
            c.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (materialTextBox1.Text == "" || materialTextBox3.Text == "")
            {
                MessageBox.Show("please enter id no and nic... ");
            }
            else
            {
                MySqlCommand md = new MySqlCommand("SELECT * FROM customer_record WHERE NIC= '" + materialTextBox3.Text + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(md);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                int i = dataTable.Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("NIC " + materialTextBox3.Text + " Already exists");

                }
                else if (Isvalid())
                {
                    MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO customer_record VALUES(@Id,@CustomerName,@NIC,@Sources,@Destination,@SeatNumber,@Dates,@Timing,@Price)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", materialTextBox1.Text);
                    cmd.Parameters.AddWithValue("@CustomerName", materialTextBox2.Text);
                    cmd.Parameters.AddWithValue("@NIC", materialTextBox3.Text);
                    cmd.Parameters.AddWithValue("@Sources", materialComboBox1.Text);
                    cmd.Parameters.AddWithValue("@Destination", materialComboBox2.Text);
                    cmd.Parameters.AddWithValue("@SeatNumber", materialComboBox3.Text);
                    cmd.Parameters.AddWithValue("@Dates", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Timing", materialTextBox5.Text);
                    cmd.Parameters.AddWithValue("@Price", materialTextBox4.Text);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record has Saved", "SAVED", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    getRecords();

                }
            }
        }
        private bool Isvalid()
        {


            if (materialTextBox1.Text == string.Empty)
            {
                MessageBox.Show("Id is required", "FAILED", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                return false;
            }
            return true;

        }
        public void getRecords()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer_record", con);
            DataTable dataTable = new DataTable();
            con.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dataTable.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dataTable;
        }

        private void materialTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            SpeechRecognitionEngine b = new SpeechRecognitionEngine();

            Grammar word = new DictationGrammar();

            b.LoadGrammar(word);

            try

            {

                b.SetInputToDefaultAudioDevice();

                RecognitionResult a = b.Recognize();

                materialTextBox1.Text = a.Text;

                materialTextBox2.Text = a.Text;
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

          
        }

        private void button7_Click(object sender, EventArgs e)
        {


            //  Form6 u = new Form6(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
            dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
         //   u.Show();

            // dataGridView1.SelectedRows[0].Cells[1].Value.ToString();



        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (var item in checkedListBox1.Items)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.SelectedRows[0].Cells["Column6"].Value = item.ToString();
                //     dataGridView1.Rows[index].Cells["Column2"].Value = item.ToString();
                dataGridView1.SelectedRows[0].Cells["Column6"].Value = setvalueText7;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   foreach (Object item in listBox1.SelectedItems)
        //    {
             //   checkedListBox1.Items.Add(item);
             //   dataGridView1.Rows.Add(item);
                //  dataGridView1.Items.Add(item);
                //setvalueText7.Items.Add(item);
               // setvalueText7.Contains(listBox1.SelectedItems);

          //  }
         //   foreach (var item in listBox1.SelectedItems)
         //   {
          //      int index = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[index].Cells["Column6"].Value = item.ToString();
               // dataGridView1.Rows[index].Cells["Column2"].Value = item.ToString();
              //  dataGridView1.Rows[index].Cells["Column3"].Value = textBox3.Text;
             //   dataGridView1.Rows[index].Cells["Column4"].Value = textBox1.Text;
          //  }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            materialTextBox1.Text = " ";
            materialTextBox2.Text = " ";
            materialTextBox3.Text = " ";
            materialTextBox4.Text = " ";
            materialTextBox5.Text = " ";
            materialComboBox1.Text = " ";
            materialComboBox2.Text = " ";
            materialComboBox3.Text = " ";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ID > 0)
            {
                
                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");

                //     MySqlCommand cmd = new MySqlCommand("UPDATE customer_record SET CustomerName =@CustomerName , NIC=@NIC , sources =@sources , Destination =@Destination , SeatNumber =@SeatNumber , Dates =@Dates , Timing =@Timing ,Price =@Price WHERE Id =@ID", con);
                MySqlCommand cmd = new MySqlCommand("update customer_record SET CustomerName='" + this.materialTextBox2.Text + "',NIC='" + this.materialTextBox3.Text + "',sources='" + this.materialComboBox1.Text + "',Destination='" + this.materialComboBox2.Text + "',SeatNumber ='" + this.materialComboBox3.Text + "',Dates='" + this.dateTimePicker1.Text + "',Timing='" + this.materialTextBox4.Text + "',Price='" + this.materialTextBox5.Text + "' where Id='" + this.materialTextBox1.Text + "';" , con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", this.ID);
                cmd.Parameters.AddWithValue("@CustomerName", materialTextBox2.Text);
                cmd.Parameters.AddWithValue("@NIC", materialTextBox3.Text);

                cmd.Parameters.AddWithValue("@sources", materialComboBox1.Text);
                cmd.Parameters.AddWithValue("@Destination", materialComboBox2.Text);
                cmd.Parameters.AddWithValue("@SeatNumber", materialComboBox3.Text);
                cmd.Parameters.AddWithValue("@Dates", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Timing", materialTextBox4.Text);
                cmd.Parameters.AddWithValue("@Price", materialTextBox5.Text);


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
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ID > 0)

            {

                MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");
                MySqlCommand cmd = new MySqlCommand("DELETE FROM customer_record WHERE ID='" + this.materialTextBox1.Text + "';" , con);

             //   MySqlCommand cmd = new MySqlCommand("DELETE FROM customer_record WHERE ID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", this.ID);

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            materialTextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            materialTextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            materialTextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            materialComboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            materialComboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            materialComboBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            materialTextBox4.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            materialTextBox5.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
          
            
        }
    }
}
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
using System.Configuration;
using System.CodeDom;

namespace Bus_Management_System
{
    public partial class Form6 : Form
    {
        MySqlConnection con = new MySqlConnection(@"server=localhost;user id=root;persistsecurityinfo=True; password= Mysql@Password125; database=bus_pass_manangement_system");

        public Form6()
        //   public Form6(string Id, string CustomerName, string NIC, string Sources, string Destination, string SeatNumber, string Dates, string Timing, string Prices)

        {
            InitializeComponent();
            //  dataGridView1.Rows.Add();
            //  dataGridView1.Rows[0].Cells[0].Value = Id;
            //   dataGridView1.Rows[0].Cells[1].Value = CustomerName;
            //   dataGridView1.Rows[0].Cells[2].Value = NIC;
            //   dataGridView1.Rows[0].Cells[3].Value = Sources;
            /// dataGridView1.Rows[0].Cells[4].Value = Destination;
            //   dataGridView1.Rows[0].Cells[5].Value = SeatNumber;
            //   dataGridView1.Rows[0].Cells[6].Value = Dates;
            //   dataGridView1.Rows[0].Cells[7].Value = Timing;
            //   dataGridView1.Rows[0].Cells[8].Value = Prices;
            //  dataGridView2.Rows[0].Cells[8].Value = Id;

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            //  dataGridView1.DataSource = GetCustomerRecord();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 b = new Form2();
            b.Show();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            getRecords();

            //   label3.Text = "0";
            //   for(int i=0;i<dataGridView1.Rows.Count; i++)
            //   {
            //     label3.Text = Convert.ToString(double.Parse(label1.Text)+double.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
            // }

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 c = new Form3();
            c.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //      foreach(DataGridViewRow row in dataGridView1.Rows)
            //     row.Cells["Price"].Value  = Convert.ToDouble(row.Cells[""].Value) +
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //  label1.Text = "0";
            //  Decimal sum = 0;
            //  for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            //   {
            //   Decimal temp;
            //       if (Decimal.TryParse((dataGridView1.Rows[i].Cells[8].Value ?? "").ToString(), out temp))
            //           sum += temp;
            //   }

            //   label3.Text = sum.ToString();

            //    int sum = 0;

            //  for (int i = 0; i < dataGridView1.Rows.Count; ++i)

            //  {
            //      sum += int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            //
            // sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);

            //   }
            //   dataGridView1.AllowUserToAddRows = false;
            //      label1.Text = "Total sum is:" + sum.ToString();


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Decimal sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                Decimal temp;
                if (Decimal.TryParse((dataGridView1.Rows[i].Cells[8].Value ?? "").ToString(), out temp))
                    sum += temp;
            }

            label3.Text = sum.ToString();
        }
        public void searchData(string valueToSearch)
        {

            string query = "SELECT * FROM customer_record WHERE CONCAT(`Id` , `CustomerName` , `NIC` , `Sources` , `Destination` , `SeatNumber` , `Dates`, `Timing` , 'Price`) like '%" + valueToSearch + "%'";
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }




        private void button6_Click(object sender, EventArgs e)
        {
            string valueToSearch = materialTextBox1.Text.ToString();
            searchData(valueToSearch);

        }
    }
}

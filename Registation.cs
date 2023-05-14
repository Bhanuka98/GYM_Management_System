using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Data;



namespace GYM
{
    public partial class Registation : Form
    {
        MySqlConnection con = new MySqlConnection(
           "server=localhost;userid = root; password=;database=gymnew;  ");

       //  OleDbConnection connection = new OleDbConnection();

        public Registation()
        {
            InitializeComponent();
            this.ActiveControl = txboxName;
            txboxName.Focus();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Registation r = new Registation();

            r.Show();
            this.Hide();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home r = new Home();

            r.Show();
            this.Hide();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchMember s = new SearchMember();

            s.Show();
            this.Hide();
        }

        private void PaymentBtn_Click(object sender, EventArgs e)
        {
            Payment p = new Payment();
            p.Show();
            this.Hide();
        }

        private void AttendanceBtn_Click(object sender, EventArgs e)
        {
            Attendance r = new Attendance();

            r.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            /* connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dinesh\Desktop\NewProject\GYM\GYMNEW.accdb";
             connection.Open();
             OleDbCommand com = new OleDbCommand();
             com.Connection = connection;
             com.CommandText = "insert into Register values(@RegNo,@Name,@NIC,@Date,@Day)";
             com.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
             com.Parameters.AddWithValue("@Name", txboxName.Text);
             com.Parameters.AddWithValue("@NIC", txboxNIC.Text);

             com.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
             com.Parameters.AddWithValue("@Day", daytxbox.Text);


             com.ExecuteNonQuery();
             connection.Close();
             MessageBox.Show("Registation Successfull", "Registation", MessageBoxButtons.OK, MessageBoxIcon.Information);
             txboxRegNo.Text = null;
             txboxName.Text = null;
             txboxNIC.Text = null;*/
            try
            {
                con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm = new MySqlCommand("insert into register values(@RegNo,@Name,@NIC,@Date,@Day)", con);
                sm.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
                sm.Parameters.AddWithValue("@Name", txboxName.Text);
                sm.Parameters.AddWithValue("@NIC", txboxNIC.Text);

                sm.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                sm.Parameters.AddWithValue("@Day", daytxbox.Text);
                /* MySqlDataAdapter da = new MySqlDataAdapter(sm);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;*/
                sm.ExecuteNonQuery();
                MessageBox.Show("Registation Successfull", "Registation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txboxRegNo.Text = null;
                txboxName.Text = null;
                txboxNIC.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void Registation_Load(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            daylbl.Text += d.Day;
        }

        private void Barcodebtn_Click(object sender, EventArgs e)
        {
            GenarateBarcode b = new GenarateBarcode();
            b.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void HomeBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // button1.Focus();
                RegisterBtn.Focus();
            }
        }

        private void txboxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txboxNIC.Focus();
            }
        }

        private void txboxNIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txboxRegNo.Focus();
            }
        }

        private void txboxRegNo_KeyDown(object sender, KeyEventArgs e)
        {
            
           if (e.KeyCode == Keys.Down)
            {
                daytxbox.Focus();
            }
        }

        private void daytxbox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down)
            {
                bunifuButton1.Focus();
            }
        }

        private void bunifuButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Barcodebtn.Focus();
            }
        }
    }
}

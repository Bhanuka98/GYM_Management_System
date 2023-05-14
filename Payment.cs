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
    public partial class Payment : Form
    {

        MySqlConnection con = new MySqlConnection(
          "server=localhost;userid = root; password=;database=gymnew;  ");

        OleDbConnection connection = new OleDbConnection();
        public Payment()
        {
            InitializeComponent();
            this.ActiveControl = txboxRegNo;
            txboxRegNo.Focus();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home r = new Home();

            r.Show();
            this.Hide();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Registation r = new Registation();

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

        private void shoebtn_Click(object sender, EventArgs e)
        {
            

            try
            {
                con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm = new MySqlCommand("insert into Payment values(@RegNo,@Month,@Status)", con);
                sm.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
                sm.Parameters.AddWithValue("@Month", dropMonth.Text);
                sm.Parameters.AddWithValue("@Status", "Pay");

              //  sm.ExecuteNonQuery();

              /*  MySqlCommand sm1 = new MySqlCommand("select * from Payment", con);
                sm1.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
                sm1.Parameters.AddWithValue("@Month", dropMonth.Text);
                sm1.Parameters.AddWithValue("@Status", "Pay");*/
               MySqlDataAdapter da = new MySqlDataAdapter(sm);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;
                //  sm.ExecuteNonQuery();
                MessageBox.Show("Payment Successfull", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txboxRegNo.Text = null;

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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
           

            try
            {
                con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm = new MySqlCommand("select * from Payment where RegNo=@regno AND Month=@month", con);
                sm.Parameters.AddWithValue("@regNo", txboxRegNo.Text);
                sm.Parameters.AddWithValue("@month", dropMonth.Text);
              
                MySqlDataAdapter da = new MySqlDataAdapter(sm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                sm.ExecuteNonQuery();
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

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void txboxRegNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                dropMonth.Focus();
            }
        }

        private void dropMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                shoebtn.Focus();
            }
        }

        private void shoebtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                bunifuButton1.Focus();
            }
        }
    }
}

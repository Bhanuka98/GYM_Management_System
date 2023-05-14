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
    public partial class SearchMember : Form
    {
        MySqlConnection con = new MySqlConnection(
        "server=localhost;userid = root; password=;database=gymnew;  ");
     //   OleDbConnection connection = new OleDbConnection();
        public SearchMember()
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
                MySqlCommand sm = new MySqlCommand("select * from Register where RegNo=@regno", con);
                sm.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
              
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

        private void SearchMember_Load(object sender, EventArgs e)
        {
           

            try
            {
                con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm = new MySqlCommand("select * from Register", con);
           

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

        private void removebtn_Click(object sender, EventArgs e)
        {
          
            try
            {
                con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm = new MySqlCommand("delete from Register where RegNo=@regno", con);
                sm.Parameters.AddWithValue("@regno", txboxRegNo.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(sm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
               

             /*   MySqlCommand sm7 = new MySqlCommand("delete * from payment where RegNo=@regno", con);
                sm7.Parameters.AddWithValue("@regno", txboxRegNo.Text);
                MySqlDataAdapter da7 = new MySqlDataAdapter(sm7);
                DataTable dt7 = new DataTable();
                da7.Fill(dt7);
                dataGridView1.DataSource = dt7;*/
              //  sm7.ExecuteNonQuery();
                sm.ExecuteNonQuery();
                /* MySqlCommand sm8 = new MySqlCommand("delete from attendance where RegNo=@regno", con);
                 sm8.Parameters.AddWithValue("@regno", txboxRegNo.Text);
                 MySqlDataAdapter da8 = new MySqlDataAdapter(sm8);
                 DataTable dt8 = new DataTable();
                 da8.Fill(dt8);
                 dataGridView1.DataSource = dt8;
                 sm8.ExecuteNonQuery();*/


                delpayment();
                delattendance();


                MessageBox.Show("Remove Successfull", "Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                


               MySqlCommand sm1 = new MySqlCommand("select * from Register", con);

                MySqlDataAdapter da1 = new MySqlDataAdapter(sm1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;


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

        private void txboxRegNo_KeyDown(object sender, KeyEventArgs e)
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
                removebtn.Focus();
            }
        }

        public void delpayment()
        {
          //  con.Open();
            // textBox1.Text = "you are now connect database";
            MySqlCommand sm = new MySqlCommand("delete from payment where RegNo=@regno", con);
            sm.Parameters.AddWithValue("@regno", txboxRegNo.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(sm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sm.ExecuteNonQuery();
        }

        public void delattendance()
        {
           // con.Open();
            // textBox1.Text = "you are now connect database";
            MySqlCommand sm = new MySqlCommand("delete from attendance where RegNo=@regno", con);
            sm.Parameters.AddWithValue("@regno", txboxRegNo.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(sm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sm.ExecuteNonQuery();
        }
    }
}

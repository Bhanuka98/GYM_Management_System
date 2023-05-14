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
using System.Media;

namespace GYM
{
    public partial class Attendance : Form
    {
        MySqlConnection con = new MySqlConnection(
         "server=localhost;userid = root; password=;database=gymnew;  ");
        private SoundPlayer _soundplayer;

        //  OleDbConnection connection = new OleDbConnection();
        public Attendance()
        {
            InitializeComponent();
            txboxRegNo.MaxLength = 6;
            this.ActiveControl = txboxRegNo;
            txboxRegNo.Focus();

            _soundplayer = new SoundPlayer("Dolphin Fitness.wav");
          
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Home r = new Home();

            r.Show();
            this.Hide();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
           

            try
            {
              /*  DateTime d = DateTime.Now;
                label6.Text += d.Day;
                label7.Text += d.Month;  //to test*/

                con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm = new MySqlCommand("select * from attendance where Date=@Date", con);
                sm.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(sm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void btnok_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            daylbl.Text += d.Day;//day
            mnthlbl.Text += d.Month;//month


          /*  label6.Text += d.Day;
            label7.Text += d.Month;*/

            try
            {

                
                con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm2 = new MySqlCommand("select Day from Register where RegNo=@Regno", con);
                sm2.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
                MySqlDataReader dat = sm2.ExecuteReader();
                
                while (dat.Read())
                {
                  //  regdatelbl.Text = dat.GetValue(0).ToString();
                    label1.Text = dat.GetValue(0).ToString();
                 //   label6.Text = dat.GetValue(0).ToString();

                }
                con.Close();

                //  sm2.ExecuteNonQuery();






                con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm1 = new MySqlCommand("select Status from Payment where Month=@month AND RegNo=@regno", con);
                sm1.Parameters.AddWithValue("@month", mnthlbl.Text);
                sm1.Parameters.AddWithValue("@regno", txboxRegNo.Text);
                MySqlDataReader dat7 = sm1.ExecuteReader();

                while (dat7.Read())
                {
                  statuslbl.Text = dat7.GetValue(0).ToString();
                 //  label5.Text = dat7.GetValue(0).ToString();
                }

                //   sm1.ExecuteNonQuery();
                con.Close();



                if (statuslbl.Text != "Pay")
                {
                    // if (int.Parse(label1.Text) <= int.Parse(daylbl.Text))
                    if (int.Parse(daylbl.Text) >= int.Parse(label1.Text))
                    {
                        _soundplayer.Play();
                        MessageBox.Show("You need to Pay This Month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //  txboxRegNo.Clear();
                        con.Open();
                        // textBox1.Text = "you are now connect database";
                        MySqlCommand sm3 = new MySqlCommand("insert into Attendance values(@RegNo,@Date)", con);
                        sm3.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
                        sm3.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                        /*   mnthlbl.Text = "";
                            label1.Text = "";
                            daylbl.Text = "";//day*/

                        MySqlDataAdapter da3 = new MySqlDataAdapter(sm3);

                        DataTable dt3 = new DataTable();
                        da3.Fill(dt3);
                        dataGridView1.DataSource = dt3;




                        /*  MySqlCommand sm0 = new MySqlCommand("select * from attendance where Date=@Date", con);
                          sm0.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                          MySqlDataAdapter da0 = new MySqlDataAdapter(sm0);
                          DataTable dt0 = new DataTable();
                          da0.Fill(dt0);
                          dataGridView1.DataSource = dt0;*/
                        // sm3.ExecuteNonQuery();
                        //  connection.Close();
                        //con.Close();
                        /*  txboxRegNo.Clear();
                          mnthlbl.Text = "";
                          label1.Text = "";
                          daylbl.Text = "";
                          statuslbl.Text = "";*/
                        /*  daylbl.Text += d.Day;//day
                          mnthlbl.Text += d.Month;//month*/
                           goto next1;

                    }
                    // connection.Open();

                    //  con.Close();



                }
                


                

                    con.Open();
                    // textBox1.Text = "you are now connect database";
                    MySqlCommand sm4 = new MySqlCommand("insert into Attendance values(@RegNo,@Date)", con);
                    sm4.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
                    sm4.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                    MySqlDataAdapter da4 = new MySqlDataAdapter(sm4);
                    /* mnthlbl.Text = "";
                     label1.Text = "";
                     daylbl.Text = "";*/
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    dataGridView1.DataSource = dt4;



            /*  MySqlCommand sm00 = new MySqlCommand("select * from attendance where Date=@Date", con);
              sm00.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
              MySqlDataAdapter da00 = new MySqlDataAdapter(sm00);
              DataTable dt00 = new DataTable();
              da00.Fill(dt00);
              dataGridView1.DataSource = dt00;*/
            next1:
                con.Close();
                //  sm4.ExecuteNonQuery();
                //  connection.Close();


                displydateat();





               /*
                *     con.Open();
                    // textBox1.Text = "you are now connect database";
                    MySqlCommand sm5 = new MySqlCommand("select * from Attendance", con);

                    MySqlDataAdapter da5 = new MySqlDataAdapter(sm5);

                    DataTable dt5 = new DataTable();
                    da5.Fill(dt5);
                    dataGridView1.DataSource = dt5;
                    con.Close();*/
                    //   sm5.ExecuteNonQuery();


                    /* txboxRegNo.Clear();
                     mnthlbl.Text = "";
                     label1.Text = "";
                     daylbl.Text = "";*/
                    // goto up;
                
                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txboxRegNo.Clear();
            }
            finally
            {
                con.Close();
               txboxRegNo.Clear();
                mnthlbl.Text = "";
                label1.Text = "";
                daylbl.Text = "";
               statuslbl.Text = null;
              /*  daylbl.Text += d.Day;//day
                mnthlbl.Text += d.Month;//month*/
                

            /*  con.Open();
                // textBox1.Text = "you are now connect database";
                MySqlCommand sm2 = new MySqlCommand("select Day from Register where RegNo=@Regno", con);
                sm2.Parameters.AddWithValue("@RegNo", txboxRegNo.Text);
                MySqlDataReader dat = sm2.ExecuteReader();

                while (dat.Read())
                {
                    //regdatelbl.Text = dat.GetValue(0).ToString();
                    label1.Text = dat.GetValue(0).ToString();
                }
                con.Close();*/
            }



        }

        private void txboxRegNo_KeyPress(object sender, KeyPressEventArgs e)
        {
                 }

        private void txboxRegNo_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txboxRegNo_TextChanged(object sender, EventArgs e)
        {
            if(txboxRegNo.Text.Length==6)
            {
                btnok.PerformClick();
            }
        }

        private void btnalert_Click(object sender, EventArgs e)
        {
            _soundplayer.Play();
        }

        public void displydateat()
        {

            con.Open();
            // textBox1.Text = "you are now connect database";
            MySqlCommand sm = new MySqlCommand("select * from attendance where Date=@Date", con);
            sm.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
            MySqlDataAdapter da = new MySqlDataAdapter(sm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

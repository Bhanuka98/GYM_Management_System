using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using MySql.Data.MySqlClient;
using System.Data;


namespace GYM
{
    public partial class GenarateBarcode : Form
    {
        MySqlConnection con = new MySqlConnection(
        "server=localhost;userid = root; password=;database=gymnew;  ");
        public GenarateBarcode()
        {
            InitializeComponent();
        }

        private void Encodebtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                pic.Image = writer.Write(txboxEncode.Text);
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

        private void Decodebtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode((Bitmap)pic.Image);
                if (result != null)
                    txboxDecode.Text = result.Text;
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
               // con.Open();
                PrintDialog pd = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += myPrintpage;
                pd.Document = doc;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    doc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
              //  con.Close();
            }

          
        }
        private void myPrintpage(object sender,PrintPageEventArgs e)
        {
          

            try
            {
               con.Open();
                Bitmap bm = new Bitmap(pic.Width, pic.Height);
                pic.DrawToBitmap(bm, new Rectangle(0, 0, pic.Width, pic.Height));
                e.Graphics.DrawImage(bm, 0, 0);
                bm.Dispose();
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

        private void BACKBTTN_Click(object sender, EventArgs e)
        {
            Registation r = new Registation();

            r.Show();
            this.Hide();
        }
    }
}

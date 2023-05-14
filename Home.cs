using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
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
            this.Hide();
        }
    }
}

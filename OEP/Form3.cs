using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OEP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            richTextBox1.Text = "Account Number : " + Form1.AC;
            richTextBox1.Text += "\nName : " + Form1.NAME;
            richTextBox1.Text += "\nLoan_Aamount : " + Form1.LOAN_ammount;
            richTextBox1.Text += "\nInterest Rate : " + Form1.Rate;
            richTextBox1.Text += "\nDuration : " + Form1.Duration;
            richTextBox1.Text += "\nTotal Payment : " + Form1.Total_payment;
            richTextBox1.Text += "\nMonthly Payments : " + Form1.Monthly;
            richTextBox1.Text += "\nInterest : " + Form1.I;
            richTextBox1.Text += "\nYour Account Balance is : " + Form1.balance;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.ShowDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

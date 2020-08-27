using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;


namespace OEP
{
    public partial class Form1 : Form
    {
        public static Double T;
        public static Double balance;
        public static string message;
        public static Double I;
        public static string AC;
        public static string NAME;
        public static string LOAN_ammount;
        public static string Rate;
        public static string Duration;
        public static string Total_payment;
        public static string Monthly;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            textBox1.Text = login.Text1;
            textBox2.Text = login.name;
            progressBar2.Hide();
            label8.Hide();
            button2.Enabled = false;
            textBox4.Text =Convert.ToString( login.Intrest);
            NAME = textBox2.Text;


        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Double total = Convert.ToDouble(textBox3.Text);
            Double rate = Convert.ToDouble(textBox4.Text);
            Double duration = Convert.ToDouble(textBox5.Text);

            /// MessageBox.Show(login.Text1);

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dotnet;";
            string query = "SELECT * FROM loan where Account_No='" + textBox1.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                // All succesfully executed, now do something

                // IMPORTANT : 
                // If your query returns result, use the following processor :

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                        // Do something with every received database ROW
                        string[] row = { reader.GetString(3), reader.GetString(4) };
                        T = Convert.ToDouble(row[1]);

                    }

                   
                        Double temp;
                        temp = (total * rate * duration) / 100 + total;
                        textBox6.Text = Convert.ToString(temp);

                        Double m, mp;
                        m = duration * 12;
                        mp = temp / m;
                        Double m1;
                        m1 = Convert.ToInt64(mp);
                        textBox7.Text = Convert.ToString(mp);
                        I = temp - total;
                    if (mp > T)
                    {

                        message = "you can  not take this loan becuse your equated monthly installment's is " + m1 + " and you monthly transection is"+T+".";
                        MessageBox.Show(message);
                        Form1 f1 = new Form1();
                        this.Hide();
                        
                        f1.ShowDialog();
                    }




                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                // Finally close the connection
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }

            progressBar2.Show();
            label8.Show();
            for (int i = 0; i < 100; i++)
            {
                progressBar2.Value = i + 1;
                Thread.Sleep(50);
            }

            progressBar2.Value = 0;
            label8.Hide();
            progressBar2.Hide();

            AC = textBox1.Text;
            Name = textBox2.Text;
            LOAN_ammount = textBox3.Text;
            Rate = textBox4.Text;
            Duration = textBox5.Text;
            Total_payment = textBox6.Text;
            Monthly = textBox7.Text;



            richTextBox1.Text = "Account Number : " + textBox1.Text;
            richTextBox1.Text += "\nName : " + textBox2.Text;
            richTextBox1.Text += "\nLoan_Aamount : " + textBox3.Text;
            richTextBox1.Text += "\nInterest Rate : " + textBox4.Text;
            richTextBox1.Text += "\nDuration : " + textBox5.Text;
            richTextBox1.Text += "\nTotal Payment : " + textBox6.Text;
            richTextBox1.Text += "\nMonthly Payments : " + textBox7.Text;
            richTextBox1.Text += "\nInterest : " + I;
            button2.Enabled = true;
            databaseConnection.Close();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {



        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dotnet;";
            double o;
            o = T;
            balance = T + Convert.ToDouble(textBox3.Text);

            string query = "UPDATE loan  SET LoanTaken='YES'   Where Account_No='" + textBox1.Text + "'";
          string query2 = "UPDATE loan  SET Balance = '" + balance + "' Where Account_No='" + textBox1.Text + "'";


            DateTime th = DateTime.Today;
            string s = Convert.ToString(th);
            string query1 = "Insert into loan_taken (Account_No,C_name,Loan_Ammount,Rate,Duration,M_Payment,Date) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox7.Text + "','" + s+ "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
           MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection);

            MySqlDataReader reader;
            MySqlDataReader reader1;


            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
              reader = commandDatabase.ExecuteReader();

                try
                {

                    databaseConnection.Close();
                    databaseConnection.Open();
                    reader1 = commandDatabase1.ExecuteReader();
                    databaseConnection.Close();
                    databaseConnection.Open();
                    reader1 = commandDatabase2.ExecuteReader();
                    databaseConnection.Close();


                   MessageBox.Show("Loan Approved!!!! Your old balance was "+o+" and new balance is "+balance );
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.ShowDialog();



                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }

            }
            
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
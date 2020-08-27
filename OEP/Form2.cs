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



namespace OEP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            dataGridView1.Enabled = false;

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dotnet;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM loan_taken ";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //MySqlDataReader reader;
            try
            {
                // Open the database
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Enabled = false;
            string search_no = textBox1.Text;

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dotnet;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM loan_taken where Account_No='"+search_no+"'";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //MySqlDataReader reader;
            try
            {
                // Open the database
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView1.Enabled = false;
           

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dotnet;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM loan_taken";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //MySqlDataReader reader;
            try
            {
                // Open the database
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionString))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                databaseConnection.Close();
                textBox1.Text = "";

            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            login.Intrest = Convert.ToDouble(textBox2.Text);
            MessageBox.Show("Intrest Rate updated to "+textBox2.Text+ " successfully");
            Form2 h = new Form2();
            this.Hide();
            h.ShowDialog();
        }
    }
}

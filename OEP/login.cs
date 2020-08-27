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

    public partial class login : Form
    {
        public static string Text1 = "";
        public static string name = "";
        public static double Intrest = 1.5;



        public login()
        {
            InitializeComponent();

        }

        private void login_Load(object sender, EventArgs e)
        {
            
                comboBox1.Items.Add("Customer");
                comboBox1.Items.Add("Admin");
            comboBox1.SelectedText = "Customer";
;        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   if (comboBox1.SelectedIndex==1)
            {
                Text1 = textBox1.Text;
                String Text2 = textBox2.Text;
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dotnet;";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                string query = "SELECT * FROM admin where admin_name='" + Text1 + "' and admin_password='" + Text2 + "' ";
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
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

                        Form2 f2 = new Form2();
                        this.Hide();
                        f2.ShowDialog();

                     }


                    
                    else
                    {
                        MessageBox.Show("Invalid User Name And Password");
                        login h = new login();
                        this.Hide();
                        h.ShowDialog();
                    }

                    // Finally close the connection
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }
                databaseConnection.Close();


            }
            else
            {
                Text1 = textBox1.Text;
                String Text2 = textBox2.Text;
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dotnet;";
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                string query = "SELECT * FROM loan where Account_No='" + Text1 + "' and Password='" + Text2 + "' ";
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
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
                            string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(5) };
                            name = row[3];
                            String s = row[4];
                            if (s == "YES") {
                                MessageBox.Show(row[3] + " You have Alredy Taken a loan So you Can not Take Another One.. Till First loan is Completed ");
                                    this.Controls.Clear();
                                this.InitializeComponent();
                                break;
                            }
                            else {

                                MessageBox.Show("Welcome ... " + row[3]);
                                this.Hide();
                                Form1 f1 = new Form1();
                                f1.ShowDialog();
                            }

                        }


                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name And Password");
                        login h1 = new login();
                        this.Hide();
                        h1.ShowDialog();
                    }

                    // Finally close the connection
                    databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }
            }
      
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

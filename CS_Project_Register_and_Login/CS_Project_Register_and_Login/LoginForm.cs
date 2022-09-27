
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Project_Register_and_Login
{
   
    public partial class LoginForm : Form
    {
        //Establishes the connection to the database
        //Using the port from XAMPP
        MySqlConnection sqlConnection = new MySqlConnection( "server=localhost; port=3306; username=root;password=;database=databasecsharp_users_db;");
        public LoginForm()
        {
            InitializeComponent();
        }


        //login button
        private void button1_Click(object sender, EventArgs e)
        {

            

            dataBase dataBase = new dataBase();
            //Assigns a name to inputs in the textboxes
            String username = usernameInput.Text;
            String password = passwordInput.Text;
            //Allows adding objects to the database
            DataTable dataTable = new DataTable();

            //Used to fetch data from the database
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();


            //Esttablishes a connection to the database
            //Assigns the variables typed in the textbox to the related fields in the database
            MySqlCommand sqlCommand0 = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", dataBase.GetConnection());
            sqlCommand0.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            sqlCommand0.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;


            //Gets or sets a Transact-SQL statement or stored procedure used to select records in the data source.
            sqlAdapter.SelectCommand = sqlCommand0;
            //Allows columns to be filled inside database
            sqlAdapter.Fill(dataTable);


            //is there a user with the entered credentials? Checks it by checking if there is data in the table which exists (so if there are more than 0 rows)
            if (dataTable.Rows.Count > 0)
            {

             //Goes to main form where you enter your grades
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
           }
            else
            {

                MessageBox.Show("Username or password incorrect.");
            }


        }


     
   



        
        //Label to go to signup form
        private void SUlink_Click(object sender, EventArgs e)
        {
            this.Hide();

            registerForm registerform = new registerForm();
                registerform.Show();

        }

        private void SUlink_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Sends the user to the register form
            this.Hide();
     
            registerForm registerform = new registerForm();
            registerform.Show();
        }
    }
}

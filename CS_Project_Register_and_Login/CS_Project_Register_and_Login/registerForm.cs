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

namespace CS_Project_Register_and_Login
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }
    



 
        private void registerForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //adds new user
           
            dataBase dataBase = new dataBase();
            //Inserts the values of the database to the name
            //Gets the connection from the .cs file "dataBase"
            MySqlCommand sqlCommand0 = new MySqlCommand("INSERT INTO `users`( `fName`, `lName`, `mail`, `username`, `password`) VALUES (@fn, @ln, @email, @usn, @pass)", dataBase.GetConnection());
            // Assigns the inserted variables into the related fields of the database
            sqlCommand0.Parameters.Add("@fn", MySqlDbType.VarChar).Value = forenameInput.Text;
            sqlCommand0.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastnameInput.Text;
            sqlCommand0.Parameters.Add("@email", MySqlDbType.VarChar).Value = mailInput.Text;
            sqlCommand0.Parameters.Add("@usn", MySqlDbType.VarChar).Value = userInput.Text;
            sqlCommand0.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passInput.Text;

            //Creating account part
            //Allows program to connect to database
            dataBase.connOpen();
            if (!isEmpty())
            {

                if (userCheck())
                {
                    MessageBox.Show("Cannot use this username. It already exists in the database/You must fill in all of the fields.");

                }

                else
                {
                    //Opens query(ies) to database to create account 
                    if (sqlCommand0.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Your account has been created");
                        this.Hide();

                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Warning, account has not been created");
                    }


                }
            }
            else
            {

                MessageBox.Show("Fill in all of the fields first.");
            }


            

    
        
        
        }
   
   //Checks if user is already created
 

        public Boolean userCheck()
        {

            dataBase dataBase = new dataBase();
            //Assigns input box for username a variable.
            String username = userInput.Text;
           //Allows adding objects to the database
            DataTable dataTable = new DataTable();
            //Used to fetch data from the database
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter();

             //Allows sql use. Selects all users in the database 
            MySqlCommand sqlCommand0 = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", dataBase.GetConnection());
            //Assigns the text inside of the username textbox to the username column in the database
            sqlCommand0.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            



            sqlAdapter.SelectCommand = sqlCommand0;
           //Allows columns to be filled inside database
            sqlAdapter.Fill(dataTable);


            //If nothing was added then that means that someone already had that username
            if (dataTable.Rows.Count > 0)
            {

              
                return true;
            }
            else
            {

                return false;
            }

           

             

        }
    
 //Checks if the textboxes are full 

      

        public Boolean isEmpty()
        {
            //Assigns the inputs in the boxes a name.
            String fName = forenameInput.Text;
            String lName = lastnameInput.Text;
            String mail = mailInput.Text;
            String user = userInput.Text;
            String pass = passInput.Text;

            //Verifies if all of the fields are equal to each other (so if they have text inside of them)
            if(fName.Equals("first name") || lName.Equals("last name") || mail.Equals("email address") || user.Equals("username") || pass.Equals("password"))
            {
                return true;
            }
            else
            {
               return false;    
            }
            
        }

        private void LIlink_MouseEnter(object sender, EventArgs e)
        {

        }

        private void LIlink_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
          
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void registerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LIlink_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CLoses the register form and opens the login form
            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void forenameInput_TextChanged(object sender, EventArgs e)
        {

        }
    }


}

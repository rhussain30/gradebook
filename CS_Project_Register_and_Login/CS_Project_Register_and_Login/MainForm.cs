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
using System.Data.SqlClient;
using System.IO;

namespace CS_Project_Register_and_Login


    //SERVER PASSWORD IS "Password1"
  
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        //Conects to local SQL Server
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-T13JVFF\SQLEXPRESS;Initial Catalog=school;Persist Security Info=True;User ID=sa;Password=Password1");
        private void button1_Click(object sender, EventArgs e)
        {
            //Opens connection
            con.Open();
            //Inserts all of the data from the textboxes into the database table
            String query = "INSERT INTO tbl_insertion (Id,Name,teacher_name,academic_year,test_notes,grade_percent) VALUES('"+idTextBox.Text+ "','" + nameTextBox.Text + "','" + teacherNameTextBox.Text + "','" + academicYearTextBox.Text + "','" + testNotesTextBox.Text + "','" + gradeTextBox.Text + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            //Closes connection
            con.Close();
            MessageBox.Show("User has been added to the database");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            con.Open();
            //Selects everything in table
            string query = "SELECT * FROM tbl_insertion";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            //Variable datatable. This is so the values of the table in the database can be stored in a variable
            DataTable dt = new DataTable();
            //Fills the variable dt with the table data
            SDA.Fill(dt);
            //Puts the table data into the datagrid. 
            dataGridView1.DataSource = dt;
            //Closes connection
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

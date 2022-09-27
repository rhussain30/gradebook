using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CS_Project_Register_and_Login

{

    class dataBase
    {
        MySqlConnection connect0 = new MySqlConnection("server=localhost; port=3306; username=root; password=;database=csharp_users_db; ");
        //Opens connection 
        public void connOpen()
        {

            if(connect0.State == System.Data.ConnectionState.Closed)
            {

                connect0.Open();

            }
            
        }

        //Closes connection
        public void connClose()
        {

            if (connect0.State == System.Data.ConnectionState.Open)
            {

                connect0.Close();

            }

        }


        //Returns connection

        public MySqlConnection GetConnection()
        {

            return connect0;
        }

    }
}

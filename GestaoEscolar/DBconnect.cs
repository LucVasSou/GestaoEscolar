using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace GestaoEscolar
{
    partial class DBconnect
    {
        //to create connection
        MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=studentdb");

        // to get connection
        public MySqlConnection getConnection
        {
            get
            {
                return connect;
            }
        }

        //function to Open connection
        public void openConnect ()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
        }

        //function to Close connection
        public void cloaseConnect()
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }
    }

}

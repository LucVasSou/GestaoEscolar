using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace GestaoEscolar
{
    class StudentClass
    {
        DBconnect connect = new DBconnect();
        //create a function to add a new students to the database

        public bool isertStudent(string fname, string lname, DateTime bdate, string gender, string phone, string address, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student` (`StdFirstName`, `StdLastName`, `Birthdate`, `Gender`, `Phone`, `Address`, `Photo`) VALUES (@fn,@ln,@bd,@gd,@ph,@adr,@img)", connect.getConnection);

            //@fn,@ln,@bd,@gd,@ph,@adr,@img
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.cloaseConnect();
                return true;
            }
            else
            {
                connect.cloaseConnect();
                return false;
            }
        }
        //to get student table
        public DataTable getStudentlist()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student`", connect.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //Create a function to execute the count query (total, male, female)
        public string exeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getConnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.cloaseConnect();
            return count;
        }

        //To get the total student
        public string totalStudent()
        {
            return exeCount("SELECT COUNT(*) FROM student");
        }

        //To get the total male student
        public string maleStudent()
        {
            return exeCount("SELECT COUNT(*) FROM student WHERE `Gender`='Male'");
        }

        //To get the total female student
        public string femaleStudent()
        {
            return exeCount("SELECT COUNT(*) FROM student WHERE `Gender`='Female'");
        }
    }
}

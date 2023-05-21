using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace ClassDB.ConnectDB
{
    internal class PostgresSqlConnect
    {
      
        public int execute(string sqlexecute)
        {

            NpgsqlConnection connection = new NpgsqlConnection(sqlexecute);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(sqlexecute, connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            connection.Close();
            return 1;
        }

        public DataTable selectquery(string sqlexecute)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sqlexecute);
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(sqlexecute, connection);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            connection.Close();

            DataTable dt =new DataTable();


            return dt;
        }



    }
}

using ClassDB.SqlKataTools;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oracle.ManagedDataAccess.Client;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassDB.ConnectDB.OraConnect;

namespace ClassDB.ConnectDB
{
    public class ExecuteFromDBMSProvider
    {

        public OraConnect ora = new OraConnect();

        public string ExecuterCompiler(Query sqlQuery)
        {
            try
            {


                var DbmsProvider = Environment.GetEnvironmentVariable("PROVIDER");
                if (DbmsProvider == null)
                {
                    Console.WriteLine("No tiene cargado el DbmsProvider");
                }
                else
                {
                    Console.WriteLine("tiene cargado el DbmsProvider" + DbmsProvider.ToString());
                }


                string SqlQuery;
                switch (DbmsProvider)
                {
                    case "oracle":
                        {


                            SqlQuery = SqlKataCommpiler.OraCompileQuery(sqlQuery);
                            return SqlQuery;

                        }
                    case "sqlserver":
                        {
                            SqlQuery = SqlKataCommpiler.SqlCompileQuery(sqlQuery);
                            return SqlQuery;

                        }
                    case "postgresql":
                        {
                            SqlQuery = SqlKataCommpiler.PsgCompileQuery(sqlQuery);
                            return SqlQuery;

                        }
                    default:
                        Console.WriteLine("error : " + DbmsProvider);
                        return sqlQuery.ToString();
                        break;

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }

        }

        public bool ExecuterOracle(string sqlQuery)
        {
            try
            {
                var STR = Environment.GetEnvironmentVariable("STR");


                Console.WriteLine(STR);


                ora.ConnectToDatabase(STR);

                OracleCommand ora_Command = new OracleCommand(sqlQuery, ora.OracleContext);
                ora_Command.CommandType = CommandType.Text;
                ora_Command.CommandText = sqlQuery;

                ora_Command.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : * ---- " + sqlQuery + " ---- *" + ex.Message);
                return false;
            }


        }

        public bool ExecuteDecider(string Query)
        {

            try
            {
                var DbmsProvider = Environment.GetEnvironmentVariable("PROVIDER");

                if (DbmsProvider == null)
                {
                    return false;
                }

                switch (DbmsProvider)
                {
                    case "oracle":
                        {
                            var r = ExecuterOracle(Query);
                            return r;
                        }
                    case "sqlserver":
                        {

                            var r = ExecuterOracle(Query);
                            return r;
                        }

                        case "postgresql":
                        {
                            var r = ExecuterOracle(Query);
                            return r;
                        }

                }


                return true;
            }
            catch
            {
                return false;
            }

        }


        public bool ExecuterSQL(string sqlQuery)
        {

            return true;
        }
        public bool ExecuterPSG(string sqlQuery)
        {

            return true;
        }

        public void DataReader(string cmdQuery, Action<DbDataReader> action)
        {









            try
            {
                if (ora.OracleContext.State == ConnectionState.Closed)
                {
                    var STR = Environment.GetEnvironmentVariable("STR");


                    Console.WriteLine(STR);

                    if (STR != null)
                    {

                        OraConnect ora = new OraConnect();
                        Console.WriteLine("pass");

                        ora.ConnectToDatabase(STR);

                        OracleCommand ora_Command = new OracleCommand(cmdQuery, ora.OracleContext);
                        ora_Command.CommandType = CommandType.Text;
                        using (OracleDataReader reader = ora_Command.ExecuteReader())
                        {
                            action(reader);
                        }
                        string log = "success " + cmdQuery.ToString();

                        Console.WriteLine("success " + cmdQuery.ToString());
                    }
                    else
                    {
                        OracleCommand ora_Command = new OracleCommand(cmdQuery, ora.OracleContext);
                        ora_Command.CommandType = CommandType.Text;
                        using (OracleDataReader reader = ora_Command.ExecuteReader())
                        {
                            action(reader);
                        }
                        string log = "success " + cmdQuery.ToString();

                        Console.WriteLine("success " + cmdQuery.ToString());
                    }
                }else
                {
                    OracleCommand ora_Command = new OracleCommand(cmdQuery, ora.OracleContext);
                    ora_Command.CommandType = CommandType.Text;
                    using (OracleDataReader reader = ora_Command.ExecuteReader())
                    {
                        action(reader);
                    }
                    string log = "success " + cmdQuery.ToString();

                    Console.WriteLine("success " + cmdQuery.ToString());
                }

            }

            catch (Exception ex)
            {
                string log = "error " + cmdQuery + " " + ex.Message;

                Console.WriteLine(log);
            }
        }
    }
}


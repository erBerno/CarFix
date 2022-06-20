using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFixDAO.Model;
using CarFixDAO.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace CarFixDAO.Implementation
{
    public class TownImpl : BaseImpl, ITown
    {
        public Town Get(string townName)
        {
            Town t = null;
            string query = @"SELECT id FROM Town WHERE townName=@townName";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@townName", townName);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                while (reader.Read())
                {
                    t = new Town(byte.Parse(reader[0].ToString()));
                }
            }
            catch (Exception ex)
            {
                //Log
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            return t;
        }

        public DataTable Select()
        {
            string query = @"SELECT townName FROM Town";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                //Log
                throw ex;
            }
        }
    }
}

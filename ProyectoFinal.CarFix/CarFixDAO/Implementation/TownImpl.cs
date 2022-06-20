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
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de GET de la tabla Town - Usuario: " + SessionClass.sessionUserName));

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
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GET de la tabla Town ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GET de la tabla Town  - ERROR: " + ex.Message));
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
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SELECT de la tabla Town - Usuario: " + SessionClass.sessionUserName));
            string query = @"SELECT townName FROM Town";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SELECT de la tabla Town ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SELECT de la tabla Town  - ERROR: " + ex.Message));
                throw ex;
            }
        }
    }
}

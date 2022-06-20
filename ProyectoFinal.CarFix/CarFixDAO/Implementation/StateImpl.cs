using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFixDAO.Interfaces;

namespace CarFixDAO.Implementation
{
    public class StateImpl : BaseImpl, IState
    {
        public DataTable SelectIDName()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SelectIDName de la tabla State - Usuario: " + SessionClass.sessionUserName));
            string query = @"SELECT id, stateName FROM State ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SelectIDName de la tabla State ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SelectIDName de la tabla State  - ERROR: " + ex.Message));
                throw ex;
            }
        }
    }
}

using CarFixDAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Implementation
{
    public class ConfigImpl : BaseImpl, IConfig
    {
        public DataTable Select()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SELECT de la tabla Config - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT pathPhotoEmployee, pathPhotoStorehouse, pathPhotoReplacement FROM Config";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SELECT de la tabla Config ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SELECT de la tabla Config  - ERROR: " + ex.Message));
                throw ex;
            }
        }
    }
}

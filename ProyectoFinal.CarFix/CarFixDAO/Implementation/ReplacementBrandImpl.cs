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
    public class ReplacementBrandImpl : BaseImpl, IReplacementBrand
    {
        public ReplacementBrand Get(byte id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método GET de la tabla ReplacementBrand - Usuario: " + SessionClass.sessionUserName));

            ReplacementBrand t = null;
            string query = @"SELECT id, brandName, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), userID
                             FROM ReplacementBrand
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                while (reader.Read())
                {
                    t = new ReplacementBrand(byte.Parse(reader[0].ToString()), reader[1].ToString(), byte.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()), int.Parse(reader[5].ToString()));
                }
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GET de la tabla ReplacementBrand ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GET de la tabla ReplacementBrand  - ERROR: " + ex.Message));
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
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método SELECT de la tabla ReplacementBrand - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT id, brandName AS 'Nombre de la Marca', registerDate AS 'Fecha de Registro', status AS 'Disponibilidad'
                             FROM ReplacementBrand
                             WHERE status=1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SELECT de la tabla ReplacementBrand ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SELECT de la tabla ReplacementBrand  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Insert(ReplacementBrand t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método INSERT de la tabla ReplacementBrand - Usuario: " + SessionClass.sessionUserName));

            string query = @"INSERT INTO ReplacementBrand (brandName, userID) 
                             VALUES (@brandName, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@brandName", t.BrandName);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método INSERT de la tabla ReplacementBrand ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método INSERT de la tabla ReplacementBrand  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Update(ReplacementBrand t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método UPDATE de la tabla ReplacementBrand - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE ReplacementBrand SET brandName=@brandName, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@brandName", t.BrandName);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método UPDATE de la tabla ReplacementBrand ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método UPDATE de la tabla ReplacementBrand  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Delete(ReplacementBrand t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método DELETE de la tabla ReplacementBrand - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE ReplacementBrand SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método DELETE de la tabla ReplacementBrand ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método DELETE de la tabla ReplacementBrand  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public DataTable SelectIDName()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método SelectIDName de la tabla ReplacementBrand - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT id, brandName
                             FROM ReplacementBrand
                             WHERE status=1
                             ORDER BY 2";

            SqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SelectIDName de la tabla ReplacementBrand ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SelectIDName de la tabla ReplacementBrand  - ERROR: " + ex.Message));
                throw ex;
            }
        }
    }
}

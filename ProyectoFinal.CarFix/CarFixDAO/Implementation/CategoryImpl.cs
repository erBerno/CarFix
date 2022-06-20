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
    public class CategoryImpl : BaseImpl, ICategory
    {
        public Category Get(byte id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de GET de la tabla Category - Usuario: " + SessionClass.sessionUserName));

            Category t = null;
            string query = @"SELECT id, categoryName, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), userID
                             FROM Category
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                while (reader.Read())
                {
                    t = new Category(byte.Parse(reader[0].ToString()), reader[1].ToString(), byte.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()), int.Parse(reader[5].ToString()));
                }
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GET de la tabla Category ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GET de la tabla Category  - ERROR: " + ex.Message));
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
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SELECT de la tabla Category - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT id, categoryName AS 'Nombre de la Categoria', registerDate AS 'Fecha de Registro'
                             FROM Category
                             WHERE status=1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SELECT de la tabla Category ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SELECT de la tabla Category  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Insert(Category t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de INSERT de la tabla Category - Usuario: " + SessionClass.sessionUserName));

            string query = @"INSERT INTO Category (categoryName, userID) 
                             VALUES (@categoryName, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@categoryName", t.CategoryName);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método INSERT de la tabla Category ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método INSERT de la tabla Category  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Update(Category t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de UPDATE de la tabla Category - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Category SET categoryName=@categoryName, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@categoryName", t.CategoryName);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método UPDATE de la tabla Category ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método UPDATE de la tabla Category  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Delete(Category t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de DELETE de la tabla Category - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Category SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método DELETE de la tabla Category ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método DELETE de la tabla Category  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public DataTable SelectIDName()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SelectIdName de la tabla Category - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT id, categoryName
                             FROM Category
                             WHERE status=1
                             ORDER BY 2";

            SqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SelectIdName de la tabla Category ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SelectIdName de la tabla Category  - ERROR: " + ex.Message));
                throw ex;
            }
        }
    }
}

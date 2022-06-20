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
            string query = @"SELECT id, brandName AS 'Nombre de la Marca', registerDate AS 'Fecha de Registro', status AS 'Disponibilidad'
                             FROM ReplacementBrand
                             WHERE status=1";
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

        public int Insert(ReplacementBrand t)
        {
            string query = @"INSERT INTO ReplacementBrand (brandName, userID) 
                             VALUES (@brandName, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@brandName", t.BrandName);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                //Log
                throw ex;
            }
        }

        public int Update(ReplacementBrand t)
        {
            string query = @"UPDATE ReplacementBrand SET brandName=@brandName, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@brandName", t.BrandName);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                //Log
                throw ex;
            }
        }

        public int Delete(ReplacementBrand t)
        {
            string query = @"UPDATE ReplacementBrand SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                //Log
                throw ex;
            }
        }
    }
}

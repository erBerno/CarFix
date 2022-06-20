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
    public class StorehouseImpl : BaseImpl, IStorehouse
    {
        public int Delete(Storehouse t)
        {
            string query = @"UPDATE Storehouse SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
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

        public Storehouse Get(byte id)
        {
            Storehouse t = null;
            string query = @"SELECT id, storehouseName, address, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), userID
                             FROM Storehouse
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                while (reader.Read())
                {
                    t = new Storehouse(byte.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), byte.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()), DateTime.Parse(reader[5].ToString()), int.Parse(reader[6].ToString()));
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

        public int Insert(Storehouse t)
        {
            string query = @"INSERT INTO Storehouse (storehouseName, address, userID) 
                             VALUES (@storehouseName, @address, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@storehouseName", t.StoreHouseName);
            command.Parameters.AddWithValue("@address", t.Address);
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

        public DataTable Select()
        {
            string query = @"SELECT id, storehouseName AS 'Almacén', address AS 'Dirección', registerDate AS 'Fecha Creación'
                             FROM Storehouse
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

        public int Update(Storehouse t)
        {
            string query = @"UPDATE Storehouse SET storehouseName=@storehouseName, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@storehouseName", t.StoreHouseName);
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
    }
}

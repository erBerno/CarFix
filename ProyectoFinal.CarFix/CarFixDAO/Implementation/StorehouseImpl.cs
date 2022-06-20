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
        TownImpl townImpl = new TownImpl();

        public int Delete(Storehouse t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de DELETE de la tabla Storehouse - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Storehouse SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);

            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método DELETE de la tabla Storehouse ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método DELETE de la tabla Storehouse  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public Storehouse Get(byte id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de GET de la tabla Storehouse - Usuario: " + SessionClass.sessionUserName));

            Storehouse t = null;

            string query = @"SELECT S.id, S.storehouseName, S.latitude, S.longitude, S.photo, T.townName, S.status, S.registerDate, ISNULL(S.lastUpdate, CURRENT_TIMESTAMP), S.userID
                             FROM Storehouse S
                             LEFT JOIN Town T ON T.id = S.townID
                             WHERE S.id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                while (reader.Read())
                {
                    t = new Storehouse(byte.Parse(reader[0].ToString()), reader[1].ToString(), float.Parse(reader[2].ToString()), float.Parse(reader[3].ToString()),
                        reader[4].ToString(), reader[5].ToString(), byte.Parse(reader[6].ToString()), DateTime.Parse(reader[7].ToString()), DateTime.Parse(reader[8].ToString()),
                        int.Parse(reader[9].ToString()));
                }
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GET de la tabla Storehouse ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GET de la tabla Storehouse  - ERROR: " + ex.Message));
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
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de INSERT de la tabla Storehouse - Usuario: " + SessionClass.sessionUserName));

            TownImpl townImpl = new TownImpl();

            string query = @"INSERT INTO Storehouse (storeHouseName, latitude, longitude, photo, userID, townID)
                             VALUES (@storeHouseName, @latitude, @longitude, @photo, @userID, @townID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@storehouseName", t.StoreHouseName);
            command.Parameters.AddWithValue("@latitude", t.Latitude);
            command.Parameters.AddWithValue("@longitude", t.Longitude);
            command.Parameters.AddWithValue("@photo", t.Photo);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            command.Parameters.AddWithValue("@townID", townImpl.Get(t.TownName).Id);

            //ID Generado?
            int id = GetGenerateID();

            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método INSERT de la tabla Storehouse ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método INSERT de la tabla Storehouse  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int GetGenerateID()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de GetGenerateID de la tabla Storehouse - Usuario: " + SessionClass.sessionUserName));
            try
            {
                return int.Parse(GetGenerateIDTable("Storehouse"));
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GetGenerateID de la tabla Storehouse ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GetGenerateID de la tabla Storehouse  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public DataTable Select()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SELECT de la tabla Storehouse - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT photo, id, storehouseName AS 'Almacén', CONCAT(latitude, ' | ', longitude) AS 'Dirección', registerDate AS 'Fecha Creación'
                             FROM Storehouse
                             WHERE status=1";

            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SELECT de la tabla Storehouse ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SELECT de la tabla Storehouse  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Update(Storehouse t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de UPDATE de la tabla Storehouse - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Storehouse SET storehouseName=@storehouseName, latitude=@latitude, longitude=@longitude, photo=@photo, townID=@townID, 
                             lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            var town = townImpl.Get(t.TownName).Id;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@storehouseName", t.StoreHouseName);
            command.Parameters.AddWithValue("@latitude", t.Latitude);
            command.Parameters.AddWithValue("@longitude", t.Longitude);
            command.Parameters.AddWithValue("@photo", t.Photo);
            command.Parameters.AddWithValue("@townID", town);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método UPDATE de la tabla Storehouse ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método UPDATE de la tabla Storehouse  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public DataTable SelectIDName()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SelectIDName de la tabla Storehouse - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT id, storehouseName
                             FROM Storehouse
                             WHERE status=1
                             ORDER BY 2";

            SqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SelectIDName de la tabla Storehouse ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SelectIDName de la tabla Storehouse  - ERROR: " + ex.Message));
                throw ex;
            }
        }
    }
}

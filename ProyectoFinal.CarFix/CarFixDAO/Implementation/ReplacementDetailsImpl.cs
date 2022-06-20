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
    public class ReplacementDetailsImpl : BaseImpl, IReplacementDetails
    {
        public int Delete(ReplacementDetails t)
        {
            throw new NotImplementedException();
        }

        public int GetGenerateID()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de GetGenerateID de la tabla ReplacementDetails - Usuario: " + SessionClass.sessionUserName));
            try
            {
                return int.Parse(GetGenerateIDTable("Replacement"));
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GetGenerateID de la tabla ReplacementDetails ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GetGenerateID de la tabla ReplacementDetails  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public void Insert(Replacement r, ReplacementDetails rd)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de INSERT de la tabla ReplacementDetails - Usuario: " + SessionClass.sessionUserName));

            string queryR = @"INSERT INTO Replacement (replacementName, replacementPrice, description, userID)
                              VALUES (@replacementName, @replacementPrice, @description, @userID)";

            string queryRD = @"INSERT INTO ReplacementDetails (id, replacementCode, photo, stock, categoryID, replacementBrandID, storehouseID, userID)
                               VALUES (@id, @replacementCode, @photo, @stock, @categoryID, @replacementBrandID, @storehouseID, @userID)";

            List<SqlCommand> commands = CreateNBasicCommand(2);

            commands[0].CommandText = queryR;
            commands[0].Parameters.AddWithValue("@replacementName", r.ReplacementName);
            commands[0].Parameters.AddWithValue("@replacementPrice", r.ReplacementPrice);
            commands[0].Parameters.AddWithValue("@description", r.Description);
            commands[0].Parameters.AddWithValue("@userID", SessionClass.sessionUserID);

            //ID Generado
            int id = GetGenerateID();

            commands[1].CommandText = queryRD;
            commands[1].Parameters.AddWithValue("@id", id);
            commands[1].Parameters.AddWithValue("@replacementCode", rd.ReplacementCode);
            commands[1].Parameters.AddWithValue("@photo", rd.Photo);
            commands[1].Parameters.AddWithValue("@stock", rd.Stock);
            commands[1].Parameters.AddWithValue("@categoryID", rd.CategoryID);
            commands[1].Parameters.AddWithValue("@replacementBrandID", rd.ReplacementBrandID);
            commands[1].Parameters.AddWithValue("@storehouseID", rd.StorehouseID);
            commands[1].Parameters.AddWithValue("@userID", SessionClass.sessionUserID);

            try
            {
                ExecuteNBasicCommand(commands);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método INSERT de la tabla ReplacementDetails ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método INSERT de la tabla ReplacementDetails  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Insert(ReplacementDetails t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(ReplacementDetails t)
        {
            throw new NotImplementedException();
        }
    }
}

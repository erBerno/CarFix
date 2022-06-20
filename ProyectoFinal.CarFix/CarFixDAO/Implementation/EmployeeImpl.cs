using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFixDAO.Interfaces;
using CarFixDAO.Model;

namespace CarFixDAO.Implementation
{
    public class EmployeeImpl : BaseImpl, IEmployee
    {
        public int Delete(Employee t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de DELETE de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Employee SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método DELETE de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método DELETE de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public Employee Get(int id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de GET de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            Employee t = null;
            string query = @"SELECT E.id, E.firstName, E.lastName, ISNULL(E.secondLastName, ''), E.ci, E.email, E.address, E.phones, 
                             E.role, T.townName, E.status, E.registerDate, ISNULL(E.lastUpdate, CURRENT_TIMESTAMP), E.userID
                             FROM Employee E
                             LEFT JOIN Town T ON T.id = E.townID
                             WHERE E.id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                while (reader.Read())
                {
                    t = new Employee(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                        reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(),
                        byte.Parse(reader[10].ToString()), DateTime.Parse(reader[11].ToString()), DateTime.Parse(reader[12].ToString()), int.Parse(reader[13].ToString()));
                }
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GET de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GET de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            return t;
        }

        public int Insert(Employee t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de INSERT de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            TownImpl townImpl = new TownImpl();
            string query = @"INSERT INTO Employee (firstName, lastName, secondLastName, ci, email, birthDate, gender, address, 
                             phones, photo, userName, password, role, userID, townID) 
                             VALUES (@firstName, @lastName, @secondLastName, @ci, @email, @birthDate, @gender, @address, @phones, @photo, @userName, 
                             HASHBYTES('md5', @password), @role, @userID, @townID)";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@firstName", t.FirstName);
            command.Parameters.AddWithValue("@lastName", t.LastName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@birthDate", t.BirthDate.Year + "-" + t.BirthDate.Month + "-" + t.BirthDate.Day);
            command.Parameters.AddWithValue("@gender", t.Gender);
            command.Parameters.AddWithValue("@address", t.Address);
            command.Parameters.AddWithValue("@phones", t.Phones);
            command.Parameters.AddWithValue("@photo", t.Photo);
            command.Parameters.AddWithValue("@userName", t.UserName);
            command.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@role", t.Role);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            command.Parameters.AddWithValue("@townID", townImpl.Get(t.TownName).Id);

            //ID Generado?
            int id = GetGenerateID();

            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método INSERT de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método INSERT de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public DataTable Login(string userName, string password)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de LOGIN de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT E.id, E.userName, E.role, E.firstName, E.lastName, ISNULL(E.secondLastName, ''), P.provinceName, T.townName, E.isFirstTime
                             FROM Employee E
                             LEFT JOIN Town T ON T.id = E.townID
                             LEFT JOIN Province P ON T.provinceID = P.id
                             WHERE status = 1 AND userName = @userName AND password = HASHBYTES('md5', @password)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;

            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método LOGIN de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método LOGIN de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public DataTable Select()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SELECT de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT photo, id, CONCAT(firstName,' ',lastName,' ',ISNULL(secondLastName,'')) AS 'Nombre Completo', 
                             userName AS 'Nombre de Usuario', ci AS 'CI', birthDate AS 'Fecha de Nacimiento', gender AS 'Género', phones AS 'Telefonos'
                             FROM Employee
                             WHERE status=1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SELECT de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SELECT de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public DataTable Select(string firstName)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SELECT que recibe 'firstName' de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT id, CONCAT(firstName,' ',lastName,' ',ISNULL(secondLastName,'')) AS 'Nombre Completo', 
                             ci AS 'CI', birthDate AS 'Fecha de Nacimiento', gender AS 'Género', phones AS 'Telefonos'
                             FROM Employee
                             WHERE status=1 AND firstName=@firstName";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@firstName", firstName);
            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SELECT que recibe 'firstName' de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SELECT que recibe 'firstName' de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public DataTable SelectFirstTime(byte data)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de SelectFirstTime de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"SELECT id, isFirstTime FROM Employee WHERE isFirstTime=@isFirstTime AND userName=@userName";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userName", SessionClass.sessionUserName);
            command.Parameters.AddWithValue("@isFirstTime", data);

            try
            {
                return ExecuteDataTableCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método SelectFirstTime de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método SelectFirstTime de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int Update(Employee t)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de UPDATE de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            TownImpl townImpl = new TownImpl();
            string query = @"UPDATE Employee SET firstName=@firstName, lastName=@lastName, secondLastName=ISNULL(@secondLastName, ''), 
                             ci=@ci, email=@email, address=@address, phones=@phones, role=@role, townID=@townID, 
                             lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                             WHERE id=@id";
            var town = townImpl.Get(t.TownName).Id;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@firstName", t.FirstName);
            command.Parameters.AddWithValue("@lastName", t.LastName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@address", t.Address);
            command.Parameters.AddWithValue("@phones", t.Phones);
            command.Parameters.AddWithValue("@role", t.Role);
            command.Parameters.AddWithValue("@townID", town);
            command.Parameters.AddWithValue("@userID", SessionClass.sessionUserID);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método UPDATE de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método UPDATE de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int ChangePassword(int id, string password)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de ChangePassword(int id, string password) de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Employee SET password=HASHBYTES('md5', @password), lastUpdate=CURRENT_TIMESTAMP
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@id", id);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método ChangePassword(int id, string password) de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método ChangePassword(int id, string password) de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public int ChangePassword(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método de ChangePassword(string username, string password) de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Employee SET password=HASHBYTES('md5', @password), lastUpdate=CURRENT_TIMESTAMP, isFirstTime=1

                             WHERE userName=@userName";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@userName", username);
            try
            {
                return ExecuteBasicCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método ChangePassword(string username, string password) de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método ChangePassword(string username, string password) de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }

        public void ChangeFirstLogin(int id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método ChangeFirstLogin de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Employee SET isFirstTime=0
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método ChangeFirstLogin de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método ChangeFirstLogin de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
        }

        public void ChangeBeforeReset(int id)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método ChangeBeforeReset de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            string query = @"UPDATE Employee SET isFirstTime=1
                             WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método ChangeBeforeReset de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método ChangeBeforeReset de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
        }

        public Employee GetEmail(string username)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método GetEmail de la tabla Employee - Usuario: " + SessionClass.sessionUserName));

            Employee t = null;
            string query = @"SELECT email FROM Employee WHERE userName=@userName";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userName", username);
            SqlDataReader reader = null;
            try
            {
                reader = ExecuteDataReaderCommand(command);
                while (reader.Read())
                {
                    t = new Employee(reader[0].ToString());
                }
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GetEmail de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GetEmail de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            return t;
        }

        public int GetGenerateID()
        {
            System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Iniciando el método GetGenerateID de la tabla Employee - Usuario: " + SessionClass.sessionUserName));
            try
            {
                return int.Parse(GetGenerateIDTable("Employee"));
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | Método GetGenerateID de la tabla Employee ejecutado exitosamente"));
            }
            catch (Exception ex)
            {
                //Log
                System.Diagnostics.Debug.WriteLine(string.Format(DateTime.Now + " | ERROR en el Método GetGenerateID de la tabla Employee  - ERROR: " + ex.Message));
                throw ex;
            }
        }
    }
}

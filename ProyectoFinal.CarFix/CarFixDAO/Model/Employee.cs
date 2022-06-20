using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Model
{
    public class Employee : BaseTable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Ci { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public string Phones { get; set; }
        public string Photo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public byte TownID { get; set; }
        public string TownName { get; set; }

        public Employee(int id, string firstName, string lastName, string secondLastName, string ci, DateTime birthDate, char gender, string address, string phones, string userName, string password, string role, byte status, DateTime registerDate, DateTime lastUpdate, int userID, byte townID )
            : base(status, registerDate, lastUpdate, userID)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SecondLastName = secondLastName;
            Ci = ci;
            BirthDate = birthDate;
            Gender = gender;
            Address = address;
            Phones = phones;
            UserName = userName;
            Password = password;
            Role = role;
            TownID = townID;
        }

        //INSERT
        public Employee(int id, string firstName, string lastName, string secondLastName, string ci, string email, string address, string phones, string photo, string role, string townName, byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SecondLastName = secondLastName;
            Ci = ci;
            Email = email;
            Address = address;
            Phones = phones;
            Photo = photo;
            Role = role;
            TownName = townName;
        }

        public Employee(int id, string firstName, string lastName, string secondLastName, string ci, string email, string address, string phones, string role, string townName, byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SecondLastName = secondLastName;
            Ci = ci;
            Email = email;
            Address = address;
            Phones = phones;
            Role = role;
            TownName = townName;
        }
        //FIN INSERT

        public Employee(string firstName, string lastName, string secondLastName, string ci, string email, DateTime birthDate, char gender, string address, string phones, string role, string townName)
        {
            FirstName = firstName;
            LastName = lastName;
            SecondLastName = secondLastName;
            Ci = ci;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Address = address;
            Phones = phones;
            Role = role;
            TownName = townName;
        }

        public Employee(int id, string firstName, string lastName, string secondLastName, string ci, string email, string address, string phones, string role, string townName)
        {
            Id=id;
            FirstName = firstName;
            LastName = lastName;
            SecondLastName = secondLastName;
            Ci = ci;
            Email = email;
            Address = address;
            Phones = phones;
            Role = role;
            TownName = townName;
        }

        public Employee(int id, string userName, string password, string role, byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Role = role;
        }

        public Employee(string email)
        {
            Email = email;
        }
    }
}

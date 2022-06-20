using CarFixDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Interfaces
{
    interface IEmployee : IBaseInterface<Employee>
    {
        DataTable Login(string userName, string password);
        DataTable Select(string firstName);
        Employee Get(int id);
        DataTable SelectFirstTime(byte data);
        int GetGenerateID();
    }
}

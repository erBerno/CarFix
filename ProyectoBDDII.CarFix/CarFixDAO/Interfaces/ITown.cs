using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFixDAO.Model;

namespace CarFixDAO.Interfaces
{
    interface ITown
    {
        Town Get(string townName);
        DataTable Select();
    }
}

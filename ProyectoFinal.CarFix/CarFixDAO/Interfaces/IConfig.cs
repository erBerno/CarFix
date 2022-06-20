using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Interfaces
{
    public  interface IConfig
    {
        DataTable Select(); 
    }
}

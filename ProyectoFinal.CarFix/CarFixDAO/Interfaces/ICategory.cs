using CarFixDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Interfaces
{
    public interface ICategory : IBaseInterface<Category>
    {
        Category Get(byte id);
        DataTable SelectIDName();
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFixDAO.Model;

namespace CarFixDAO.Interfaces
{
    public interface IReplacementBrand : IBaseInterface<ReplacementBrand>
    {
        ReplacementBrand Get(byte id);
        DataTable SelectIDName();
    }
}

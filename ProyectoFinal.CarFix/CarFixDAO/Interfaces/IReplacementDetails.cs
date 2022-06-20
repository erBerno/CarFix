using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFixDAO.Model;

namespace CarFixDAO.Interfaces
{
    public interface IReplacementDetails : IBaseInterface<ReplacementDetails>
    {
        void Insert(Replacement r, ReplacementDetails rd);
        int GetGenerateID();
    }
}

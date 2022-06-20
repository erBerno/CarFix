using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Model
{
    public class ReplacementBrand : BaseTable
    {
        public byte Id { get; set; }
        public string BrandName { get; set; }

        public ReplacementBrand(byte id, string brandName, byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            Id = id;
            BrandName = brandName;
        }

        public ReplacementBrand(string brandName)
        {
            BrandName = brandName;
        }
    }
}

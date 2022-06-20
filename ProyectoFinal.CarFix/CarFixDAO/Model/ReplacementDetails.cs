using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Model
{
    public class ReplacementDetails : BaseTable
    {
        public int Id { get; set; }
        public string ReplacementCode { get; set; }
        public string Photo { get; set; }
        public int Stock { get; set; }
        public byte CategoryID { get; set; }
        public byte ReplacementBrandID { get; set; }
        public byte StorehouseID { get; set; }

        public ReplacementDetails()
        {
        }

        //INSERT
        public ReplacementDetails(string replacementCode, int stock, byte categoryID, byte replacementBrandID, byte storehouseID)
        { 
            ReplacementCode = replacementCode;
            Stock = stock;
            CategoryID = categoryID;
            ReplacementBrandID = replacementBrandID;
            StorehouseID = storehouseID;
        }
    }
}

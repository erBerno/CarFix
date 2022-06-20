using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Model
{
    public class BaseTable
    {
        public byte Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int UserID { get; set; }

        public BaseTable(byte status, DateTime registerDate, DateTime lastUpdate, int userID)
        {
            Status = status;
            RegisterDate = registerDate;
            LastUpdate = lastUpdate;
            UserID = userID;
        }

        public BaseTable(int userID)
        {
            UserID = userID;
        }

        public BaseTable()
        {
        }
    }
}

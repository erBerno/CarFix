using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Model
{
    public class Category : BaseTable
    {
        public byte Id { get; set; }
        public string CategoryName { get; set; }

        public Category(byte id, string categoryName, byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            Id = id;
            CategoryName = categoryName;
        }

        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}

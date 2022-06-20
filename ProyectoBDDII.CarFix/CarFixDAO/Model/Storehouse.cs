using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Model
{
    public class Storehouse : BaseTable
    {
        public byte Id { get; set; }
        public string StoreHouseName { get; set; }
        public string Address { get; set; }

        public Storehouse(byte id, string storeHouseName, string address, byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            Id = id;
            StoreHouseName = storeHouseName;
            Address = address;
        }

        public Storehouse(string storeHouseName)
        {
            StoreHouseName = storeHouseName;
        }

        public Storehouse(string storeHouseName, string address)
        {
            StoreHouseName = storeHouseName;
            Address = address;
        }
    }
}

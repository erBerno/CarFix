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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Photo { get; set; }
        public byte TownID { get; set; }
        public string TownName { get; set; }

        public Storehouse()
        {
        }

        //INSERT
        public Storehouse(string storeHouseName, double latitude, double longitude, string townName)
        {
            StoreHouseName = storeHouseName;
            Latitude = latitude;
            Longitude = longitude;
            TownName = townName;
        }

        //UPDATE
        public Storehouse(byte id, string storeHouseName, double latitude, double longitude, string townName, string photo)
        {
            Id = id;
            StoreHouseName = storeHouseName;
            Latitude = latitude;
            Longitude = longitude;
            TownName = townName;
            Photo = photo;
        }

        //GET
        public Storehouse(byte id, string storeHouseName, double latitude, double longitude, string photo, string townName, byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            Id = id;
            StoreHouseName = storeHouseName;
            Latitude = latitude;
            Longitude = longitude;
            Photo = photo;
            TownName = townName;
        }
    }
}

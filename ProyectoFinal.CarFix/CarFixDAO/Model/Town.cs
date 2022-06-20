using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Model
{
    public class Town
    {
        public byte Id { get; set; }
        public string TownName { get; set; }

        public Town(byte id, string townName)
        {
            Id = id;
            TownName = townName;
        }

        public Town(byte id)
        {
            Id = id;
        }
    }
}

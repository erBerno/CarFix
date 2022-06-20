using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFixDAO.Model
{
    public class Replacement : BaseTable
    {
        public string ReplacementName { get; set; }
        public string ReplacementPrice { get; set; }
        public string Description { get; set; }

        public Replacement()
        {
        }

        //INSERT
        public Replacement(string replacementName, string replacementPrice, string description)
        {
            ReplacementName = replacementName;
            ReplacementPrice = replacementPrice;
            Description = description;
        }
    }
}

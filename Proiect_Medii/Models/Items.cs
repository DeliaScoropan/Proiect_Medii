using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Medii.Models
{
    public class Items
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }

        [MaxLength(250), Unique]
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}

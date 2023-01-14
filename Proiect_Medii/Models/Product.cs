using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Medii.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }

        [OneToMany]
        public List<ProductList> ProductLists { get; set; }
    }
}


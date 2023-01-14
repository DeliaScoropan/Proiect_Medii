using SQLite;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;


namespace Proiect_Medii.Models
{
    public class ProductList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Items))]
        public int ItemsID { get; set; }
        public int ProductID { get; set; }
    }
}

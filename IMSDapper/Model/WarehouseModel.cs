using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDapper.Model
{
    [Table("Warehouses")]
    public class WarehouseModel
    {
        [Key]
        public int WarehouseID { get; set; }

        [Column("Name")]
        public string WarehouseName { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

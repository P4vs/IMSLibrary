using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDapper.Model
{
    [Table("Stock")]
    public class StockModel
    {
        [Key]
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}   
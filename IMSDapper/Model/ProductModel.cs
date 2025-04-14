using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IMSDapper.Model
{
    [Table("Products")]
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public int DefaultWarehouseID { get; set; }
        public DateTime CreatedAt { get; set; } 
        

        // Navigation properties
        [JsonIgnore]
        public CategoryModel Category { get; set; }
        [JsonIgnore]
        public SupplierModel Supplier { get; set; } 
        [JsonIgnore]
        public WarehouseModel Warehouses { get; set; }
    }
}

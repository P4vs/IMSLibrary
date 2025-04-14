using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDapper.Model
{
    [Table("Categories")]
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Column("Name")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}

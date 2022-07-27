using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(25)]
        public string CategoryName { get; set; }
        [StringLength(250)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        public virtual ICollection<Heading> Heading { get; set; }
    }
}

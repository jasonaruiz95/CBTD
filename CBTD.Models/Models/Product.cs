using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTD.ApplicationCore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name="MSRP List Price")]
        [Range(0.01, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(0.01, 10000)]
        [Display(Name = "Price 1-5")]
        public double UnitPrice { get; set; }
        [Required]
        [Range(0.01, 10000)]
        [Display(Name = "Price 6-11")]
        public double HalfDozenPrice { get; set; }
        [Required]
        [Range(0.01, 10000)]
        [Display(Name = "Price 12 or more")]
        public double DozenPrice { get; set; }
        [Required]
        public String Size { get; set; }
        [Required]
        public String UPC { get; set; }
        
        public String ImageURL { get; set; }


        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]
        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }


    }
}

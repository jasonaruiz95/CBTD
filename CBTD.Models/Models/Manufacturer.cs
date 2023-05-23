using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTD.ApplicationCore.Models
{
    public class Manufacturer
    {
        //Annotations for the properties. Explicitly creating primary key. Implicit that if any fields contain ID it will be the primary key in table.
        [Key]
        public int Id { get; set; }

        // Explicitly creating a non null
        [Required]
        public string Name { get; set; }
    }
}

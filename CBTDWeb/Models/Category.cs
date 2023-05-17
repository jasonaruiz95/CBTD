using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CBTDWeb.Models
{
    public class Category
    {
        //Annotations for the properties. Explicitly creating primary key. Implicit that if any fields contain ID it will be the primary key in table.
        [Key]
        public int Id { get; set; }

        // Explicitly creating a non null
        [Required]
        public string Name { get; set; }


        [Required]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }

        public DateTime DateModified { get; set; } = DateTime.Now;

    }
}

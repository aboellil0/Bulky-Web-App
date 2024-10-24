using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        // use display name for the client side what you want to display
        [DisplayName("Name")]
        //this vlaidation will not inmplement in the page untell adding validation to view and check if model state is valid ni controller
        [MaxLength(100)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        //you can add acustom error meessege
        [Range(1,100,ErrorMessage ="mohamed aboellil")]
        public int DisplayOrder { get; set; }
    }
}

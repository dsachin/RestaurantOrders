using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class MenuViewModel : BaseViewModel
    {
        [Required]
        public string MenuId { get; set; }
        public string Name { get; set; }
        [Range(1, 1000, ErrorMessage = "Price should be betwwn 1 to 1000")]
        public int Price { get; set; }
        public string Category { get; set; }
        public int? Quantity { get; set; }

    }
}
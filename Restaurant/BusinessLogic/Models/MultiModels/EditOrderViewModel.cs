using System.Collections.Generic;

namespace BusinessLogic.Models.MultiModels
{
    public class EditOrderViewModel 
    {
        public List<OrderViewModel> OrderList { get; set; }
        public int? EditTableId { get; set; }
        public int[] EditedQuantity { get; set; }
        public bool OrderDeletion { get; set; }
    }
}

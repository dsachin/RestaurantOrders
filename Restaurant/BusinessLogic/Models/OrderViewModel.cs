using System;
namespace BusinessLogic.Models
{
    public class OrderViewModel : BaseViewModel
    {
        public int TableNo { get; set; }
        public string OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }
        public int OrderIndex { get; set; }
    }
}
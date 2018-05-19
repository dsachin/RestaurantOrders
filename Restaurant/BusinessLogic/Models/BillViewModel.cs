namespace BusinessLogic.Models
{
    public class BillViewModel : BaseViewModel
    {
        public int BillID { get; set; }
        public int TableNo { get; set; }
        public float TotalPrice { get; set; }
        public float CashTaken { get; set; }
        public float CashReturned { get; set; }
    }
}
namespace BusinessLogic.Models
{
    public class TaxViewModel : BaseViewModel
    {
        public float CGST { get; set; }
        public float SGST { get; set; }
        public float ServiceTax { get; set; }
        public int TaxID { get; set; }
    }
}
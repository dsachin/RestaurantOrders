using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models.MultiModels
{
    public class CustomerBillViewModel
    {
        public List<OrderViewModel> OrderList { get; set; }
        public List<CustomerDetailViewModel> CustomerList { get; set; }
        public List<TableViewModel> TableList { get; set; }
        public BillAmountViewModel Bills { get; set; }
        public TaxViewModel Tax { get; set; }
        [Range(101, 1000, ErrorMessage = "Please Provide correct Table No.  ")]
        public int SelectedTable { get; set; }
        public float TotalPrice { get; set; }
        public float CashTaken { get; set; }
        public float CashReturned { get; set; }
    }
}

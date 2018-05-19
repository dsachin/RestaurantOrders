using System;
namespace BusinessLogic.Models
{
    public class CustomerDetailViewModel : BaseViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }         
        public string MobNo { get; set; }
        public Nullable<int> BillID { get; set; }
        
    }
}

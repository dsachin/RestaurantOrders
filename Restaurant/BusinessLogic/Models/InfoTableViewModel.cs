using System.Collections.Generic;

namespace BusinessLogic.Models
{
    public class InfoTableViewModel:BaseViewModel
    {
        public int TableNo { get; set; }
        public List<TableViewModel> tableList { get; set; }
    }
}

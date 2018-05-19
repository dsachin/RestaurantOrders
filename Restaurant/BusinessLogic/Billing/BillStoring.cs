using BusinessLogic.Models.MultiModels;
using BusinessLogic.RestaurantManagement;
using DataModel;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Billing
{
    public class BillStoring
    {
        #region Class Initiation
        private RestaurantEntities3 db = new RestaurantEntities3();
        #endregion

        #region  Storage of Bill 
        /// <summary>
        ///Bill Information such as Customer Name, Mob No, Bill Id, amount Paid etc is getting stored on database and Clearing Order Data from Database 
        ///and Changing the table status to available
        /// </summary>
        /// <param name="bill"></param>
        public BillStoring(CustomerBillStoringViewModel bill)
        {
            Mappings map = new Mappings();
            map.BillStoring(bill.Bill);
            map.CustomerStoring(bill.Customer);
            int tableNo = (bill.Bill.TableNo);
            List<Order> orderList = db.Orders.Where(a => a.TableNo == tableNo).ToList();
            foreach (Order index in orderList)
            {
                db.Orders.Remove(index);
                db.SaveChanges();
            }
            ManageRestaurant manage = new ManageRestaurant();
            bool check = manage.TableStatus(bill.Bill.TableNo, false);
        }
        #endregion
    }
}

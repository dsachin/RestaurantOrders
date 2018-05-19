using BusinessLogic.Models;
using BusinessLogic.Models.MultiModels;

namespace BusinessLogic.Billing
{
    public class BillDisplay
    {
        #region Initiate Class
        CustomerBillViewModel customerBill = new CustomerBillViewModel();
        Mappings map = new Mappings();
        RestaurantManagement.ManageRestaurant manage = new RestaurantManagement.ManageRestaurant(); 
        #endregion

        #region  Display and Calculate Bill 
        /// <summary>
        /// Display Method to View all orders regarding particular table for bill payment
        /// </summary>
        /// <returns></returns>

        public CustomerBillViewModel Bill()
        {
            CustomerBillViewModel billDisplay = DisplayBill();
            billDisplay.Bills = new BillAmountViewModel();
            billDisplay.Bills.ItemPrice = new string[billDisplay.OrderList.Count];
            return billDisplay;
        }

        public CustomerBillViewModel DisplayBill()
        {
            customerBill.CustomerList = map.DisplayCustomer();
            customerBill.OrderList = map.DisplayOrders();
            customerBill.Tax = map.DisplayTaxes();
            customerBill.TableList = map.DisplayTable(true);
            foreach (OrderViewModel index in customerBill.OrderList)
            {
                //Table no 999 is reserved for Parcle
                if (index.TableNo == manage.parcelTable)
                {
                    TableViewModel table = new TableViewModel();
                    table.TableID = manage.parcelTable;
                    table.TableStatus = false;
                    customerBill.TableList.Add(table);
                    break;
                }
            }
            return customerBill;
        }

        //Calling of functions to calculate the bill Accordingly and passing info such as taxes and orderlist to it. 
        public CustomerBillViewModel DisplayBillDetails(int? tableNo)
        {
            BillCalculation billCalculation = new BillCalculation();
            customerBill.OrderList = map.DisplayOrdersByTable(tableNo);
            customerBill.Tax = map.DisplayTaxes();
            customerBill.Bills = billCalculation.BillAmountCalculation(customerBill.OrderList, customerBill.Tax);
            return customerBill;
        }
        #endregion
    }
}

using System.Collections.Generic;
using BusinessLogic.Models;
using BusinessLogic.Models.MultiModels;
namespace BusinessLogic.Billing
{
    class BillCalculation
    {
        #region  Initiate Class
        Mappings mapcalculate = new Mappings();
        BillAmountViewModel bill = new BillAmountViewModel();
        #endregion

        #region Calculation Of total Bill and applying taxes
        /// <summary>
        /// Bill Calculation is done using orderList that is ordered by customer and taxes are applied on them.
        /// </summary>
        /// <param name="orderList"></param>
        /// <param name="taxList"></param>
        /// <returns></returns>
        public BillAmountViewModel BillAmountCalculation(List<OrderViewModel> orderList, TaxViewModel taxList)
        {
            int menuItemPrice = 0, index = 0;
            string[] itemPrice = new string[orderList.Count];
            float totalBill = 0;
            List<MenuViewModel> menu = mapcalculate.DisplayMenu();
            //OrderList is iterated to get the individual menuList price so that bill calculation can be done. 
            foreach (OrderViewModel outerIndex in orderList)
            {
                //MenuView model is iterated to get individual item price.
                foreach (MenuViewModel innerIndex in menu)
                {
                    if (outerIndex.OrderId == innerIndex.MenuId)
                        menuItemPrice = innerIndex.Price;
                }
                //Indivisual Item price is Calculated and Total price is added
                itemPrice[index] = (menuItemPrice * outerIndex.Quantity).ToString();
                totalBill = totalBill + (menuItemPrice * outerIndex.Quantity);
                index++;
            }
            //Taxes are added to total Bill
            totalBill = totalBill + (totalBill * (taxList.CGST / 100)) + (totalBill * (taxList.SGST / 100)) + (totalBill * (taxList.ServiceTax / 100));
            bill.ItemPrice = itemPrice;
            bill.TotalBill = totalBill;
            return bill;
        }
        #endregion
    }
}

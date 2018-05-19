using BusinessLogic.Models;
using BusinessLogic.Models.MultiModels;
using System.Collections.Generic;

namespace BusinessLogic.DataStoring
{
    public class OrderDisplay
    {
        #region Class Initiation
        Mappings map = new Mappings();
        #endregion

        #region Display Order
        /// <summary>
        /// Display Order calls mapper function to map and returns order object to display on view
        /// </summary>
        /// <returns>order</returns>
        public OrderMenuListViewModel DisplayOrder()
        {
            OrderMenuListViewModel order = new OrderMenuListViewModel();
            List<MenuViewModel> menuList = map.DisplayMenu();
            order.MenuList = menuList;
            order.TableList = map.DisplayTable(false);
            return order;
        }
        #endregion
    }
}

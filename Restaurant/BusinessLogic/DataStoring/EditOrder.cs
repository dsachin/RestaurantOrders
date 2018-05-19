using BusinessLogic.Models.MultiModels;
using BusinessLogic.RestaurantManagement;
using DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessLogic.DataStoring
{
    public class EditOrder
    {
        #region Edit Or Delete Order
        /// <summary>
        /// Edit Order Function updates previously  ordered order or delete the order entirely
        /// by using Table no and modified quantity List
        /// </summary>
        private RestaurantEntities3 db = new RestaurantEntities3();
        public EditOrder(EditOrderViewModel edit)
        {
            List<Order> order = db.Orders.Where(m => m.TableNo == edit.EditTableId).ToList();
            Mappings map = new Mappings();
            //Delete Order
            if (edit.OrderDeletion == true)
            {
                ManageRestaurant manage = new ManageRestaurant();
                foreach (Order index in order)
                {
                    db.Orders.Remove(index);
                    db.SaveChanges();
                }
                manage.TableStatus((int)edit.EditTableId, false);
            }
            //Update Order
            else
            {
                for (int index = 0; index < edit.EditedQuantity.Count(); index++)
                {
                    order[index].Quantity = edit.EditedQuantity[index];
                    db.Entry(order[index]).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        #endregion
    }
}

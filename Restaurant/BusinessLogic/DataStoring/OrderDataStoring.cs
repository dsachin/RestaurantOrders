using BusinessLogic.Models;
using BusinessLogic.RestaurantManagement;
using DataModel;
using System.Collections.Generic;

namespace BusinessLogic.DataStoring
{
    public class OrderDataStoring
    {
        #region Class Initiation
        private RestaurantEntities3 db = new RestaurantEntities3();
        int selectedTable = 0;
        Order orderModel = new Order();
        #endregion

        #region Order Storing To Database
        /// <summary>
        /// OrderData storing adds order into database checks for duplicate orders and combine them into single order and also change the status of the table.
        /// </summary>      
        public OrderDataStoring(List<OrderViewModel> orderData)
        {
            Mappings map = new Mappings();
            int count = orderData.Count;
            //For Loop to combine Duplicate orders 
            for (int index = 0; index < count - 1; index++)
            {
                //loop to check for duplicate values.
                for (int innerIndex = index+1; innerIndex < count; innerIndex++)
                {
                    if (orderData[index].OrderId == orderData[innerIndex].OrderId)
                    {
                        orderData[index].Quantity = orderData[index].Quantity + orderData[innerIndex].Quantity;
                        count--;
                        orderData.RemoveAt(innerIndex);
                    }
                }
            }
            //store the order in database
            foreach (OrderViewModel index in orderData)
            {                            
                selectedTable = index.TableNo;
                orderModel.TableNo = index.TableNo;
                orderModel.OrderId = index.OrderId;
                orderModel.Quantity = index.Quantity;
                orderModel.OrderTime = index.OrderTime;
                db.Orders.Add(orderModel);
                db.SaveChanges();
            }
            //To toggle the status of table
            ManageRestaurant manage = new ManageRestaurant();
            bool check = manage.TableStatus(selectedTable, true);
        }
        #endregion
    }
}
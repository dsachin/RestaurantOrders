using AutoMapper;
using BusinessLogic.Models;
using DataModel;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Mappings
    {
        #region Mapper Functions
        /// <summary>
        /// Mapping is used to map all the viewModel to DataModel
        /// </summary>

        private RestaurantEntities3 db = new RestaurantEntities3();

        public static void Mapping()
        {
            AutoMapper.Mapper.Initialize(config =>
             {
                 config.CreateMap<Bill, BillViewModel>().ReverseMap();
                 config.CreateMap<CustmerDetail, CustomerDetailViewModel>().ReverseMap();
                 config.CreateMap<Menu, MenuViewModel>().ReverseMap();
                 config.CreateMap<Order, OrderViewModel>().ReverseMap();
                 config.CreateMap<Stat, StatisticsViewModel>().ReverseMap();
                 config.CreateMap<TableConfig, TableViewModel>().ReverseMap();
                 config.CreateMap<Tax, TaxViewModel>().ReverseMap();
             });
        }

        public List<MenuViewModel> DisplayMenu()
        {
            List<MenuViewModel> menuview = new List<MenuViewModel>();
            List<Menu> menuList = db.Menus.ToList();
            menuview = Mapper.Map<List<Menu>, List<MenuViewModel>>(menuList);
            return menuview;
        }

        public List<OrderViewModel> DisplayOrders()
        {
            List<OrderViewModel> order = new List<OrderViewModel>();
            List<Order> orderList = db.Orders.ToList();
            order = Mapper.Map<List<Order>, List<OrderViewModel>>(orderList);
            return order;
        }

        public Order AddOrder(OrderViewModel orderView)
        {
            Order order = Mapper.Map<OrderViewModel, Order>(orderView);
            db.Orders.Add(order);
            db.SaveChanges();
            return order;
        }

        public List<TableViewModel> DisplayTable(bool status)
        {
            List<TableViewModel> table = new List<TableViewModel>();
            List<TableConfig> tableList = db.TableConfigs.Where(a => a.TableStatus == status).ToList();
            table = Mapper.Map<List<TableConfig>, List<TableViewModel>>(tableList);
            return table;
        }

        public List<CustomerDetailViewModel> DisplayCustomer()
        {
            List<CustomerDetailViewModel> customer = new List<CustomerDetailViewModel>();
            List<CustmerDetail> customerList = db.CustmerDetails.ToList();
            customer = Mapper.Map<List<CustmerDetail>, List<CustomerDetailViewModel>>(customerList);
            return customer;
        }

        public TaxViewModel DisplayTaxes()
        {
            TaxViewModel taxViewModel = new TaxViewModel();
            Tax taxList = db.Taxes.Single();
            taxViewModel.CGST = (float)taxList.CGST;
            taxViewModel.SGST = (float)taxList.SGST;
            taxViewModel.ServiceTax = (float)taxList.ServiceTax;
            return taxViewModel;
        }

        public List<OrderViewModel> DisplayOrdersByTable(int? tableNo)
        {
            List<OrderViewModel> order = new List<OrderViewModel>();
            List<Order> orderList = db.Orders.Where(l => l.TableNo == tableNo).ToList();
            order = Mapper.Map<List<Order>, List<OrderViewModel>>(orderList);
            return order;
        }

        public bool BillStoring(BillViewModel bill)
        {
            Bill billData = new Bill();
            billData.CashReturned = bill.CashReturned;
            billData.CashTaken = bill.CashTaken;
            billData.TableNo = bill.TableNo;
            billData.TotalPrice = bill.TotalPrice;
            db.Bills.Add(billData);
            db.SaveChanges();
            return true;
        }

        public bool CustomerStoring(CustomerDetailViewModel customer)
        {
            CustmerDetail customerData = new CustmerDetail();
            customerData.MobNo = customer.MobNo;
            customerData.Name = customer.Name;
            db.CustmerDetails.Add(customerData);
            db.SaveChanges();
            return true;
        }
    }
    #endregion
}

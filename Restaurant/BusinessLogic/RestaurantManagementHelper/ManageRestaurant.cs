using AutoMapper;
using BusinessLogic.Models;
using DataModel;
using System.Data.Entity;
using System.Linq;
namespace BusinessLogic.RestaurantManagement
{
    public class ManageRestaurant
    {
        #region Initiating Db entity
        private RestaurantEntities3 db = new RestaurantEntities3();
        #endregion

        #region Helper Variables
        // Table 999 is reserved for parcel  
        public int parcelTable = 999;
        #endregion

        #region Menu configurations       
        /// <summary>
        /// Add Menu Method adds new menu to the MenuTable
        /// It checks the menu Table if the inputed item is already present if present it returns false
        /// if not then updates the database.
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool AddMenu(MenuViewModel menu)
        {
            Menu menuConfig = db.Menus.Where(x => x.MenuId == menu.MenuId).FirstOrDefault();
            if (menuConfig != null)
                return false;
            menuConfig = Mapper.Map<MenuViewModel, Menu>(menu);
            db.Menus.Add(menuConfig);
            db.SaveChanges();
            return true;
        }
        /// <summary>
        /// find Menu finds the menu by using parameter id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public MenuViewModel FindMenu(string id)
        {
            Menu menu = db.Menus.Find(id);
            MenuViewModel menuFind = Mapper.Map<Menu, MenuViewModel>(menu);
            return menuFind;
        }
        /// <summary>
        /// Edit menu is used for editing the menu, Menuview is passed to it as argument.
        /// </summary>
        /// <param name="menuView"></param>
        /// <returns></returns>

        public MenuViewModel EditMenu(MenuViewModel menuView)
        {
            Menu menu = Mapper.Map<MenuViewModel, Menu>(menuView);
            db.Entry(menu).State = EntityState.Modified;
            db.SaveChanges();
            return menuView;
        }

        /// <summary>
        /// Delete manu deletes the menu based on id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMenu(string id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
            db.SaveChanges();
        }
        #endregion

        #region Table Configuration
        /// <summary>
        /// Add Table Method adds new table to the Table
        /// It checks the Table if the inputed table is already present if present it returns false
        /// if not then updates the database.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>

        public bool AddTable(TableViewModel table)
        {
            TableConfig tableConfig = db.TableConfigs.Where(x => x.TableID == table.TableID).FirstOrDefault();
            if (tableConfig != null)
                return false;
            tableConfig = Mapper.Map<TableViewModel, TableConfig>(table);
            db.TableConfigs.Add(tableConfig);
            db.SaveChanges();
            return true;
        }
        public TableViewModel FindTable(int id)
        {
            TableConfig table = db.TableConfigs.Find(id);
            TableViewModel tableFind = Mapper.Map<TableConfig, TableViewModel>(table);
            return tableFind;
        }
        /// <summary>
        /// Edit table is used for editing the Table, TableView is passed to it as argument.
        /// </summary>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public void EditTable(TableViewModel tableView)
        {
            TableConfig table = Mapper.Map<TableViewModel, TableConfig>(tableView);
            db.Entry(table).State = EntityState.Modified;
            db.SaveChanges();
        }
        /// <summary>
        /// Delete menu deletes the menu based on paramter id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTable(int id)
        {
            TableConfig table = db.TableConfigs.Find(id);
            db.TableConfigs.Remove(table);
            db.SaveChanges();
        }
        /// <summary>
        /// Updates the status of table for booking
        /// </summary>
        /// <param name="tableNo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool TableStatus(int tableNo, bool status)
        {              //Parcel Facility Table 999 is reserved for Parcel
            if (tableNo != parcelTable)
            {
                TableConfig tableConfig = db.TableConfigs.Where(x => x.TableID == tableNo).FirstOrDefault();
                tableConfig.TableStatus = status;
                db.Entry(tableConfig).State = EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }
        #endregion

        #region Tax Addition
        /// <summary>
        /// Add Tax Method updates tax table with new values 
        /// </summary>
        /// <param name="tax"></param>
        /// <returns></returns>
        public bool AddTax(TaxViewModel tax)
        {
            Tax taxConfig = db.Taxes.FirstOrDefault();
            taxConfig.CGST = tax.CGST;
            taxConfig.SGST = tax.SGST;
            taxConfig.ServiceTax = tax.ServiceTax;
            db.Entry(taxConfig).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        #endregion
    }
}

//using BusinessLogic.Models;
//using DataModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLogic.MapperMethods
//{
//    class GenericMapping<T>
//    {
//        private RestaurantEntities3 db = new RestaurantEntities3();
//        MenuViewModel menu = new MenuViewModel();
//        private T genericMemberVariable;

//            public GenericMapping(T value)
//            {
//                genericMemberVariable = value;
//            }


//            public List<T> genericMethod(T genericParameter)
//            {
//            if (genericParameter.GetType() == menu.GetType() )
//            {               
//                var menuList = db.Menus.ToList();
                             
//            }
//            else if(genericParameter.GetType() == order.GetType(){

//            }





//            menuview = Mapper.Map<List<Menu>, List<MenuViewModel>>(menuList);
//            //List<T> generic = new List<T>();
//            //T menuList = db..ToList();
//            //menuview = Mapper.Map<List<Menu>, List<MenuViewModel>>(menuList);
//            //return menuview;


//            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
//                Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);

//                return genericMemberVariable;
//            }

//            public T genericProperty { get; set; }
        

//    }
//}

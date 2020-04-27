using OnlineShoppingStore.DATA;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Models.Home
{
    public class HomeIndexViewModel 
    {
        Entities2 context = new Entities2();
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public IEnumerable<TBL_PRODUCT> ListOfProducts { get; set; }
        public IEnumerable<TBL_CATEGORY> ListOfProductsCategory { get; set; }

        public HomeIndexViewModel CreatModel()
        {
            //IEnumerable<TBL_PRODUCT> data = context.Database.SqlQuery<TBL_PRODUCT>()
            return new HomeIndexViewModel()
            { ListOfProducts = _unitOfWork.GetRepositoryInstance<TBL_PRODUCT>().GetAllRecords()};
        }
    }
}
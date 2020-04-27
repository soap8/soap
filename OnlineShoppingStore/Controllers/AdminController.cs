using Newtonsoft.Json;
using OnlineShoppingStore.DATA;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin

        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public ActionResult Dashboard()
        {
            return View();
        }
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var categ = _unitOfWork.GetRepositoryInstance<TBL_CATEGORY>().GetAllRecords();
            foreach (var item in categ)
            {
                list.Add(new SelectListItem { Value = item.CATEGORYID.ToString(), Text = item.CATEGORYNAME });

            }
            return list;
        }

        public ActionResult Categories()
        {
            List<TBL_CATEGORY> allcategories = _unitOfWork.GetRepositoryInstance<TBL_CATEGORY>().GetAllRecordsIQueryable().Where(i => i.ISDELETE == null).ToList();
            return View();
        }
        public ActionResult AddCategory()
        {
            ViewBag.CategoryList = GetCategory();

            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(TBL_CATEGORY tbl)
        {
            _unitOfWork.GetRepositoryInstance<TBL_CATEGORY>().Add(tbl);
            return RedirectToAction("AddCategory");
        }

        public ActionResult UpdateCategory(int? categoryId)
        {
            CategoryDetail cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<TBL_CATEGORY>().GetFirstorDefault(Convert.ToInt32(categoryId))));
            }
            else
            {
                cd = new CategoryDetail();
            }
            return View("UpdateCategory", cd);

        }
        public ActionResult CategoryEdit(int categoryId)
        {
            return View(_unitOfWork.GetRepositoryInstance<TBL_CATEGORY>().GetFirstorDefault(categoryId));
        }
        [HttpPost]
        public ActionResult CategoryEdit(TBL_CATEGORY tbl)
        {
            _unitOfWork.GetRepositoryInstance<TBL_CATEGORY>().Update(tbl);
            return RedirectToAction("Categories");
        }
        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<TBL_PRODUCT>().GetProduct());
        }
        public ActionResult ProductEdit(int productId)
        {
            ViewBag.CategoryList = GetCategory();

            return View(_unitOfWork.GetRepositoryInstance<TBL_PRODUCT>().GetFirstorDefault(productId));
        }
        [HttpPost]
        public ActionResult ProductEdit(TBL_PRODUCT tbl,HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                file.SaveAs(path);
            }
            tbl.PRODUCTIMAGE = file!=null?pic:tbl.PRODUCTIMAGE;
            tbl.MODIFIEDDATE = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<TBL_PRODUCT>().Update(tbl);
            return RedirectToAction("Product");
        }
        public ActionResult ProductAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(TBL_PRODUCT tbl,HttpPostedFileBase file)
        {
            string pic = null;
            if(file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"),pic);
                file.SaveAs(path);
            }
            tbl.PRODUCTIMAGE = pic;
            tbl.CREATEDATE = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<TBL_PRODUCT>().Add(tbl);
            return RedirectToAction("Product");
        }

    }
}
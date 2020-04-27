using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Models
{
    public class CategoryDetail
    {
        public decimal CATEGORYID { get; set; }
        [Required(ErrorMessage = "Category Name Requird")]
        [StringLength(100, ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 charaters are allwed", MinimumLength = 3)]
        public string CATEGORYNAME { get; set; }
        public Nullable<bool> ISACTIVE { get; set; }
        public Nullable<bool> ISDELETE { get; set; }
    }

    public class ProductDetail
    {
        public decimal PRODUCTID { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        [StringLength(100, ErrorMessage = "Minimum 3 and minimum 5 and maximum 100 charaters are allwed", MinimumLength = 3)]
        public string PRODUCTNAME { get; set; }
        public Nullable<decimal> CATEGORYID { get; set; }
        public Nullable<bool> ISACTIVE { get; set; }
        public Nullable<bool> ISDELETE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string DESCRIPTION { get; set; }
        public string PRODUCTIMAGE { get; set; }
        public Nullable<bool> ISFEATURED { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "500", ErrorMessage = "Invalid Quantity")]
        public Nullable<decimal> QUANTITY { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "invalid Price")]

        public Nullable<decimal> PRICE { get; set; }
        public SelectList Categories { get; set; }
    }
}
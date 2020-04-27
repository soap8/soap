using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class ShippingDetail
    {
        public decimal SHIPPINGDETAILID { get; set; }
        [Required]
        public Nullable<decimal> MEMBERID { get; set; }
        [Required]
        public string ADDRESS { get; set; }
        [Required]
        public string CITY { get; set; }
        [Required]
        public string STATE { get; set; }
        [Required]
        public string COUNTRY { get; set; }
        public string ZIPCODE { get; set; }
        public Nullable<decimal> ORDERID { get; set; }
        public Nullable<decimal> AMOUNTPAID { get; set; }
        [Required]

        public string PAYMENTTYPE { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShoppingStore.DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PRODUCT()
        {
            this.TBL_CART = new HashSet<TBL_CART>();
        }
    
        public decimal PRODUCTID { get; set; }
        public string PRODUCTNAME { get; set; }
        public Nullable<decimal> CATEGORYID { get; set; }
        public Nullable<bool> ISACTIVE { get; set; }
        public Nullable<bool> ISDELETE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
        public string DESCRIPTION { get; set; }
        public string PRODUCTIMAGE { get; set; }
        public Nullable<bool> ISFEATURED { get; set; }
        public Nullable<decimal> QUANTITY { get; set; }
        public Nullable<decimal> PRICE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CART> TBL_CART { get; set; }
        public virtual TBL_CATEGORY TBL_CATEGORY { get; set; }
    }
}

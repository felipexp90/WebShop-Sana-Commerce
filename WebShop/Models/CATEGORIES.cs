//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CATEGORIES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIES()
        {
            this.PRODUCT_CATEGORIES = new HashSet<PRODUCT_CATEGORIES>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<System.DateTime> DATE_CREATION { get; set; }
        public Nullable<System.DateTime> DATE_MODIFI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_CATEGORIES> PRODUCT_CATEGORIES { get; set; }
    }
}
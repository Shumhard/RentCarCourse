//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbElement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderAdditionalServices = new HashSet<OrderAdditionalServices>();
            this.ClientOrders = new HashSet<ClientOrders>();
        }
    
        public System.Guid Guid { get; set; }
        public Nullable<System.Guid> CarGuid { get; set; }
        public Nullable<System.Guid> AreaGuid { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RentBeginDate { get; set; }
        public Nullable<System.DateTime> RentEndDate { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> PaymentTypeId { get; set; }
        public string Name { get; set; }
        public Nullable<double> TotalCost { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual Car Car { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderAdditionalServices> OrderAdditionalServices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientOrders> ClientOrders { get; set; }
    }
}

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
    
    public partial class OrderAdditionalServices
    {
        public System.Guid Guid { get; set; }
        public System.Guid OrderGuid { get; set; }
        public System.Guid ServiceGuid { get; set; }
    
        public virtual AdditionalServices AdditionalServices { get; set; }
        public virtual Order Order { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreightChelCompanyProject.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProdsInRequests
    {
        public int RequeId { get; set; }
        public int ProdId { get; set; }
        public int Quantity { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Requests Requests { get; set; }
    }
}

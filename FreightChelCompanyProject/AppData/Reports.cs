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
    
    public partial class Reports
    {
        public int Id { get; set; }
        public int NumWorker { get; set; }
        public string Text { get; set; }
        public decimal Amount { get; set; }
        public string MarkPosition { get; set; }
        public int MarkLevel { get; set; }
        public int ArchStatus { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Workers Workers { get; set; }
    }
}

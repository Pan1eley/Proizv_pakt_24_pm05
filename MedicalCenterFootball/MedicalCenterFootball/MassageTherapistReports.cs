//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicalCenterFootball
{
    using System;
    using System.Collections.Generic;
    
    public partial class MassageTherapistReports
    {
        public int ReportID { get; set; }
        public Nullable<System.DateTime> SessionDate { get; set; }
        public string PlayerName { get; set; }
        public string MassageType { get; set; }
        public Nullable<int> Duration { get; set; }
        public string Remarks { get; set; }
    }
}

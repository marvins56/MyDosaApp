//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentAffiairs.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserLocation
    {
        public string AccessNumber { get; set; }
        public string From_Address { get; set; }
        public string To_Adddress { get; set; }
        public Nullable<int> Distance { get; set; }
        public System.TimeSpan Estimated_Arrival_time { get; set; }
        public System.TimeSpan Set_Off_Time { get; set; }
    
        public virtual Student Student { get; set; }
    }
}

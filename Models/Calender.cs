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
    
    public partial class Calender
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public Nullable<long> event_length { get; set; }
        public string rec_type { get; set; }
        public Nullable<int> event_pid { get; set; }
        public string userid { get; set; }
    }
}

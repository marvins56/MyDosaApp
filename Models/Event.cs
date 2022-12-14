
namespace StudentAffiairs.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

    public partial class Event
    {
        [Display(Name = "EVENT")]
        public int EventID { get; set; }
        [Display(Name="TRAVEL SUBJECT")]
        public string Subject { get; set; }

        [Display(Name = " TRAVEL DESCRIPTION")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "please give a shorter sentence")]
        [MinLength(100, ErrorMessage = "invalid description length")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " Body Content field required")]
        public string Description { get; set; }
        [Display(Name = "SET OFF TIME")]
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = " setofftime field required")]
        [DisplayFormat(DataFormatString = "{DD/MM/YYYY HH:mm A}", ApplyFormatInEditMode = true)]
        public System.DateTime Start { get; set; }
        [Display(Name = "ESTIMATED ARRIVAL TIME")]
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = " arrival time field required")]
        [DisplayFormat(DataFormatString = "{DD/MM/YYYY HH:mm A}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
        [Display(Name = "STUDENT ACCESS NUMBER")]
        public string userid { get; set; }
    }
}

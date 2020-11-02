using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCompany.Entities
{
    public class ServiceItem: EntityBase
    {
        [Required(ErrorMessage = "Please enter service name")]
        [Display(Name = "Service Name (Title)")]
        public override string Title { get; set; }

        [Display(Name = "Service Short Description")]
        public override string Subtitle { get; set; }


        [Display(Name = "Service Description")]
        public override string Text { get; set; }
    }
}

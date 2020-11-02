using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetCompany.Entities
{
    public class TextField: EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Page Name (Title)")] 
        public override string Title { get; set; } = "Info Page";


        [Display(Name = "Page Description")]
        public override string Text { get; set; } = "Content is filled in by the administrator";
    }
}

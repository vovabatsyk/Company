using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Company.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => DateAdded = DateTime.UtcNow;

        [Required]
        public  Guid Id { get; set; }

        [Display(Name = "Название (заголовок)")]
        public virtual  string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "Seo метатег title")]
        public virtual string MetaTitle { get; set; }

        [Display(Name = "Seo метатег keyword")]
        public virtual string MetaKeyword { get; set; }

        [Display(Name = "Seo метатег description")]
        public virtual string MetaDescription { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}

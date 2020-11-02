using System;
using System.ComponentModel.DataAnnotations;

namespace dotNetCompany.Entities
{
    public class EntityBase
    {

        protected EntityBase() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Name (Title)")]
        public virtual string Title { get; set; }

        [Display(Name = "Short description")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Description")]
        public virtual string Text { get; set; }

        [Display(Name = "Title Image")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO Meta Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO Meta Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO Meta Keywords")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

    }
}

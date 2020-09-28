﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Domain.Entities
{
    public class TextField: EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информацыонная страница";

        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; } = "Содержание страницы заполняется администратором";
    }
}

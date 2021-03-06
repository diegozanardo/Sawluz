﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawlux.ViewModel
{
    public class PratoVM
    {
        public int Id { get; set; }

        public string Restaurante { get; set; }

        [Display(Name = "Prato")]
        public string Nome { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}

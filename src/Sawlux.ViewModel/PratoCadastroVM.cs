using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sawlux.ViewModel
{
    public class PratoCadastroVM
    {
        public int Id { get; set; }

        [Display(Name = "Prato")]
        public string Nome { get; set; }

        [Display(Name = "Preço R$")]
        [RegularExpression(@"\d+(\,\d{1,2})?", ErrorMessage = "Preço inválido")]
        public decimal Preco { get; set; }

        [Display(Name = "Restaurante")]
        public string Restaurante { get; set; }

        public IEnumerable<SelectListItem> Restaurantes { get; set; }
    }
}

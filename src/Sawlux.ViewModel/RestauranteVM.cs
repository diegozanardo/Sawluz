using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawlux.ViewModel
{
    public class RestauranteVM
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [StringLength(250, ErrorMessage = "O campo Nome maior que 20 caracteres")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

    }
}

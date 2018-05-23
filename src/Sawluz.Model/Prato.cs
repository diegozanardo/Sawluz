using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawluz.Model
{
    public class Prato
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }

        [ForeignKey("Restaurante")]
        public int IdRestaurante { get; set; }
        public virtual Restaurante Restaurante { get; set; }
    }
}

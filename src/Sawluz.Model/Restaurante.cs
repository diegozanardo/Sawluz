using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawluz.Model
{
    public class Restaurante
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string Nome { get; set; }
        public virtual ICollection<Prato> Pratos { get; set; }
    }
}

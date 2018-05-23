using Sawluz.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sawlux.Data.Contexto
{
    public class SawluxContexto : DbContext
    {
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Prato> Prato { get; set; }

        public SawluxContexto()
            : base("Sawlux")
        {
            Database.SetInitializer<SawluxContexto>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapeleriaBellasArtes.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base("PapeleríaBellasArtes")
        {
            

        }

        public DbSet<Producto> Productos { get; set; }
    }
}

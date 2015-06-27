using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public  class SiteContexto : DbContext
    {
        private readonly bool _excluir = false;

        //Inicializar as classes que seram espelhadas em tabelas
        // ex: public DbSet<NomeDaClasse> NomeDaTabela { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public SiteContexto(bool exclui)
        {
            _excluir = exclui;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (_excluir)
                Database.SetInitializer(new DropCreateDatabaseAlways<SiteContexto>());
            else
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SiteContexto>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            base.OnModelCreating(modelBuilder);
            
        }
    }


}

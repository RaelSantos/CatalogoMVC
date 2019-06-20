using CatalogoMvc.Data.Mapeamento;
using CatalogoMvc.Dominio;
using System.Data.Entity;

namespace CatalogoMvc.Data.Contexto
{
    public class CatalogoMvcContextoDados : DbContext
    {
        public CatalogoMvcContextoDados() : base("CatalogoMvcStringConexao")
        { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapUsuario());
            base.OnModelCreating(modelBuilder);
        }
    }
}

using CatalogoMvc.Dominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace CatalogoMvc.Data.Mapeamento
{
    public class MapUsuario : EntityTypeConfiguration<Usuario>
    {
        public MapUsuario()
        {
            ToTable("Usuario");

            HasKey(x => x.Id);

            Property(x => x.Email).IsRequired().HasMaxLength(160).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_USUARIO_EMAIL") { IsUnique = true }));
            Property(x => x. Nome).IsRequired().HasMaxLength(60);
            Property(x => x. Senha).IsRequired().HasMaxLength(32).IsFixedLength();
            Property(x => x.NomeUsuario).IsRequired().HasMaxLength(20).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_USUARIO_NOMEUSUARIO") { IsUnique = true }));          
        }
    }
}

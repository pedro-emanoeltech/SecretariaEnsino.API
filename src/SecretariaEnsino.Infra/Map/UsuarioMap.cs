using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.Infra.Map
{
    public class UsuarioMap : BaseEntidadeMap<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);
 
            builder.Property(s => s.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.Tipo).HasMaxLength(100).HasConversion(new EnumToStringConverter<TipoUsuario>());

            builder.Property(s => s.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.Senha)
                   .IsRequired()
                   .HasMaxLength(500);
  
            builder.Property(s => s.DataCadastro)
                   .HasDefaultValueSql("GETUTCDATE()");  

            builder.Property(s => s.Ativo)
                   .HasDefaultValue(true);
 
        }
    }
}

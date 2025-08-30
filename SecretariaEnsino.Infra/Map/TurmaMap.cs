using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Domain.Enum;

namespace SecretariaEnsino.Infra.Map
{
    public class TurmaMap : BaseEntidadeMap<Turma>
    {
        public override void Configure(EntityTypeBuilder<Turma> builder)
        {
            base.Configure(builder);
 
            builder.Property(s => s.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Descricao)
                   .HasMaxLength(500);

            builder.Property(s => s.DataInicio)
                   .IsRequired();

            builder.Property(s => s.DataFim)
                   .IsRequired(false);

            builder.Property(s => s.Capacidade)
                   .IsRequired();

            builder.Property(s => s.Professor)
                   .HasMaxLength(150);

            builder.Property(s => s.Status).HasMaxLength(100).HasConversion(new EnumToStringConverter<StatusTurma>());
 
            builder.HasMany(s => s.Matriculas)
                   .WithOne(m => m.Turma)
                   .HasForeignKey(m => m.TurmaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

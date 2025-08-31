using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.Infra.Map
{
    public class AlunoMap : BaseEntidadeMap<Aluno>
    {
        public override void Configure(EntityTypeBuilder<Aluno> builder)
        {
            base.Configure(builder);
 

            builder.Property(s => s.DataNascimento)
                   .IsRequired();

            builder.Property(s => s.Cpf)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(s => s.Telefone)
                   .HasMaxLength(20);

            builder.HasIndex(s => s.Cpf).IsUnique();
          
            builder.HasMany(s => s.Matriculas)
                   .WithOne(m => m.Aluno)
                   .HasForeignKey(m => m.AlunoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Usuario).WithOne(e => e.Aluno).HasForeignKey<Aluno>(x => x.UsuarioId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

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
 
            builder.Property(s => s.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.DataNascimento)
                   .IsRequired();

            builder.Property(s => s.Cpf)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(s => s.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.SenhaHash)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(s => s.Telefone)
                   .HasMaxLength(20);

            builder.Property(s => s.DataCadastro)
                   .HasDefaultValueSql("GETUTCDATE()");  

            builder.Property(s => s.Ativo)
                   .HasDefaultValue(true);

            
            builder.HasIndex(s => s.Cpf).IsUnique();
            builder.HasIndex(s => s.Email).IsUnique();

          
            builder.HasMany(s => s.Matriculas)
                   .WithOne(m => m.Aluno)
                   .HasForeignKey(m => m.AlunoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

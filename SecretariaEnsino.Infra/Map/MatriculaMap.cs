using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecretariaEnsino.Domain.Entidades;

namespace SecretariaEnsino.Infra.Map
{
    public class MatriculaMap : BaseEntidadeMap<Matricula>
    {
        public override void Configure(EntityTypeBuilder<Matricula> builder)
        {
            base.Configure(builder);
 
            builder.Property(s => s.DataMatricula)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(s => s.Status)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.NotaFinal)
                   .HasColumnType("decimal(5,2)");

            builder.Property(s => s.CertificadoEmitido)
                   .HasDefaultValue(false);

            //evitar que o aluno se matricule mais de uma vez na mesma turma a nivel de banco
            builder.HasIndex(s => new { s.AlunoId, s.TurmaId }).IsUnique();
 
        }
    }
}

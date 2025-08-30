using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecretariaEnsino.Domain.Abastacao;

namespace SecretariaEnsino.Infra.Map
{
    public abstract class BaseEntidadeMap<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntidade
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);


            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();

            //indices
            builder.HasIndex(p => p.Id).IsUnique();
        }
    }
}

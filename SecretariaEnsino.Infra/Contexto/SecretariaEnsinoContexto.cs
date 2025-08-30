using Microsoft.EntityFrameworkCore;
using SecretariaEnsino.Domain.Entidades;
using SecretariaEnsino.Infra.Map;

namespace SecretariaEnsino.Infra.Contexto
{
    public class SecretariaEnsinoContexto : BaseContexto
    {
        public SecretariaEnsinoContexto(DbContextOptions options) : base(options)
        {
      
        }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new MatriculaMap());
        }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
    }
}

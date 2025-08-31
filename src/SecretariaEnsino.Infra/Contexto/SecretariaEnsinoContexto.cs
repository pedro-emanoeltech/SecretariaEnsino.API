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
            //implementar reflexão para carregar todos os mapas automaticamente
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new MatriculaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

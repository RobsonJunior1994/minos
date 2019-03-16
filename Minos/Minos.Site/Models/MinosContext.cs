using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Minos.Site.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class MinosContext : DbContext
    {
        public MinosContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Questionario> Questionarios { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Resposta> Respostas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProfessorTurma>().HasKey(pt => new { pt.ProfessorId, pt.TurmaId });
            modelBuilder.Entity<ProfessorTurma>()
                .HasOne(pt => pt.Professor)
                .WithMany(p => p.Turmas)
                .HasForeignKey(pt => pt.ProfessorId);

            modelBuilder.Entity<ProfessorTurma>()
                .HasOne(pt => pt.Turma)
                .WithMany(p => p.Professores)
                .HasForeignKey(pt => pt.TurmaId);

            modelBuilder.Entity<QuestionarioPergunta>().HasKey(qp => new { qp.QuestionarioId, qp.PerguntaId });

            
            //modelBuilder.Entity<Usuario>().HasKey(t => t.Id);
            //modelBuilder.Entity<Turma>().HasKey(t => t.Id);
            //modelBuilder.Entity<Professor>().HasKey(t => t.Id);
            //modelBuilder.Entity<Questionario>().HasKey(t => t.Id);
            //modelBuilder.Entity<Pergunta>().HasKey(t => t.Id);
            //modelBuilder.Entity<Periodo>().HasKey(t => t.Id);
            //modelBuilder.Entity<Aluno>().HasKey(t => t.Id);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Minos;Trusted_Connection=true");
        }

    }
}

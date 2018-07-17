using Microsoft.EntityFrameworkCore;
using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class MinosContext : DbContext
    {
        public MinosContext(DbContextOptions<MinosContext> options) : base(options)
        {
        }

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Turma>().ToTable("Turma");
        }
    }
}

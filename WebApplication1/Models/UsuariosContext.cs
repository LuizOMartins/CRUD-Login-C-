using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UsuariosContext : DbContext
    {

        public UsuariosContext() : base("Usuario") { }


        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>().ToTable("Medico");
            modelBuilder.Entity<Especialidade>().ToTable("Especialidade");
            modelBuilder.Entity<Cidade>().ToTable("Cidade");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }

    }

}


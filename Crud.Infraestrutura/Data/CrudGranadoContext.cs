using Crud.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infraestrutura.Data
{
    public class CrudGranadoContext : DbContext 
    {
        public CrudGranadoContext()
        {
                
        }

        public CrudGranadoContext(DbContextOptions<CrudGranadoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Pessoa>().HasKey(e => e.Id);

            _ = modelBuilder.Entity<Pessoa>().Property(e => e.Nome).IsRequired(true);

            _ = modelBuilder.Entity<Pessoa>().Property(e => e.Cpf).HasMaxLength(11).IsRequired(true);

            _ = modelBuilder.Entity<Pessoa>().Property(e => e.Email).IsRequired(true);

            _ = modelBuilder.Entity<Pessoa>().Property(e => e.Telefone).IsRequired(true);

        }

        public virtual DbSet<Pessoa> Pessoas { get; set; }

   }
   
}

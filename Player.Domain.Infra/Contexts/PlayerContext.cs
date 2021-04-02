using Microsoft.EntityFrameworkCore;

namespace Player.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {

        }
     

        public DbSet<Player.Domain.Entities.Player> Players {get; set;} //ligação com o banco e criando a tabela através do mapeamento

        protected override void OnModelCreating(ModelBuilder modelBuilder) // criando o banco a partir do modelo, isto é, ele reflete a nossa entidade
        {
            modelBuilder.Entity<Player.Domain.Entities.Player>().ToTable("Players");
            modelBuilder.Entity<Player.Domain.Entities.Player>().Property(x => x.Id);
            modelBuilder.Entity<Player.Domain.Entities.Player>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Player.Domain.Entities.Player>().Property(x => x.Assists).HasMaxLength(120);
            modelBuilder.Entity<Player.Domain.Entities.Player>().Property(x => x.Assists).HasMaxLength(120);
        }
    }
}
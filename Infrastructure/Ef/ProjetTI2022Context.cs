using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;


public class ProjetTI2022Context : DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;

    public ProjetTI2022Context(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }
    
    public DbSet<DbUser> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionStringProvider.Get("db"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.ToTable("utilisateur");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Nom).HasColumnName("nom");
            entity.Property(u => u.Prenom).HasColumnName("prenom");
        });
    }


}
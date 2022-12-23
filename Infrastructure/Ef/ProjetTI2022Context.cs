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
    public DbSet<DbAuction> Auctions { get; set; }
    
    public DbSet<DbAuctionPayment> AuctionPayments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionStringProvider.Get("db"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Pseudo).HasColumnName("pseudo");
            entity.Property(u => u.Mail).HasColumnName("mail");
            entity.Property(u => u.Pass).HasColumnName("pass");
        });
        
        modelBuilder.Entity<DbAuction>(entity =>
        {
            entity.ToTable("auction");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).HasColumnName("id");
            entity.Property(a => a.IdUser).HasColumnName(("id_user"));
            entity.Property(a => a.Title).HasColumnName("title");
            entity.Property(a => a.Category).HasColumnName("category");
            entity.Property(a => a.Descri).HasColumnName("descri");
            entity.Property(a => a.Img).HasColumnName("img");
            entity.Property(a => a.Price).HasColumnName("price");
            entity.Property(a => a.IdUserBid).HasColumnName("id_user_bid");
            entity.Property(a => a.Timer).HasColumnName("timer");
        });

        modelBuilder.Entity <DbAuctionPayment>(entity =>
        {
            entity.ToTable("auctionPayment");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).HasColumnName("id");
            entity.Property(a => a.IdUser).HasColumnName(("id_user"));
            entity.Property(a => a.Title).HasColumnName("title");
            entity.Property(a => a.Price).HasColumnName("price");
        });
    }
    
    
    


}
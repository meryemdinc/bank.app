using bank.app.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bank.app.infrastructure.Data
{
    public class BankDbContext : DbContext
    {
        // DbContext, uygulamanın veri tabanı ile iletişimini sağlar.
        // Bağlantı ayarları Program.cs üzerinden verilir.

        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options)
        {
        }

        // DbSet'ler tablo karşılıklarıdır
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        // Veritabanı yapılandırmaları burada tanımlanır
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique indexler
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.NationalId)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.IBAN)
                .IsUnique();

            modelBuilder.Entity<Card>()
                .HasIndex(c => c.CardNumber)
                .IsUnique();

            // İlişkiler
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Accounts)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Cards)
                .WithOne(c => c.Account)
                .HasForeignKey(c => c.AccountId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>()
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Card)
                .HasForeignKey(t => t.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.TransactionType)
                .WithMany(tt => tt.Transactions)
                .HasForeignKey(t => t.TransactionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Card>()
                .HasOne(c => c.CardType)
                .WithMany(ct => ct.Cards)
                .HasForeignKey(c => c.CardTypeId);

            // Örnek veri
            modelBuilder.Entity<CardType>().HasData(
                new CardType { Id = 1, Name = "Bank Card" },
                new CardType { Id = 2, Name = "Credit Card" }
            );

            // Decimal alanlar için precision ayarı (RiskLimit ve Amount uyarılarını önler)
            modelBuilder.Entity<Customer>()
                .Property(c => c.RiskLimit)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);
        }
    }
}

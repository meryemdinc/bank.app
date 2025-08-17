using bank.app.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Data
{
    public class BankDbContext : DbContext
    {
        //Bu yapı, dışarıdan (örneğin Program.cs dosyasından) bu context'in nasıl çalışacağını belirlemek için kullanılır.
        //   Bağlantı ayarları(ConnectionString) burada verilir.


        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options)
        {
        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        //Veritabanındaki ilişkileri, benzersiz alanları (unique) ve örnek verileri burada tanımlarsın.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Accounts)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);
            //bir hesap bir müşteriye ait, bir müşteri birden fazla hesaba sahip olabilir
            modelBuilder.Entity<Account>()
                .HasMany(x => x.Cards)
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
            //"Bir hesabı silmeye çalışırsan ama o hesaba bağlı işlemler varsa, silinemez."
            modelBuilder.Entity<Card>()
                .HasOne(c => c.CardType)
                .WithMany(ct => ct.Cards)
                .HasForeignKey(c => c.CardTypeId);

            modelBuilder.Entity<CardType>().HasData(
                new CardType { Id = 1, Name = "Bank Card" },
                new CardType { Id = 2, Name = "Credit Card" }
            );

        }
    }
}
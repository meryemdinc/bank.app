using bank.app.infrastructure.Data;
using bank.app.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankDbContext _context;//veritabanı bağlantısını temsil eder
        /*Her biri bir tabloya (veya tablo grubuna) ait işlemleri temsil eder.
Örn: Accounts → tüm hesaplarla ilgili sorguları burada yaparsın.*/
        public IAccountRepository Accounts { get; }
        public ICardRepository Cards { get; }
        public ICustomerRepository Customers { get; }
        public ITransactionRepository Transactions { get; }
        /*DI (dependency injection) ile bu sınıflar dışarıdan veriliyor ve içteki değişkenlere atanıyor.
Böylece dışarıdan bağlılıklar yönetiliyor, test etmek kolaylaşıyor.*/
        public UnitOfWork(
            BankDbContext context,
            IAccountRepository accountRepository,
            ICardRepository cardRepository,
            ICustomerRepository customerRepository,
            ITransactionRepository transactionRepository)
        {
            _context = context;
            Accounts = accountRepository;
            Cards = cardRepository;
            Customers = customerRepository;
            Transactions = transactionRepository;
        }
        //> Repository'ler üzerinden yapılan tüm değişiklikleri **tek bir noktadan kaydetmek** için çağrılır.
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        //kullanılmayan kaynakları serbest bırakmak için Dispose metodu kullanılır.
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();//veritabanı bağlantısını kapatır
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

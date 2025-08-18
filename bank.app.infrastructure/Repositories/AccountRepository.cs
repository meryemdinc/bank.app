using bank.app.domain.Entities;
using bank.app.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.app.infrastructure.Repositories
{
    public class AccountRepository : EfRepository<Account>, IAccountRepository
    {
        // BankDbContext sınıfını kullanarak veritabanı işlemlerini yapar.( miras aldığımız EfRepository Dbcontext nesnesini kullandıgı için burada tekrar tanımlamaya gerek yok ve constructorda parametre olarak almalıyız) 
        //base(context) ile EfRepository sınıfının constructor'ını çağırıyoruz.
        public AccountRepository(BankDbContext context) : base(context)
        {
        }

        //hesap id sinden hesabı bulup hesap kartlar ve işlemleri getirir.
        //async: Bu fonksiyon asenkron çalışır, yani işlemi başlatır, sonucu beklerken başka işlere de devam edebilir.
        //Task<Account>: Bu fonksiyon bir Account nesnesi döndürecek, ancak bu işlem asenkron olduğu için Task içinde dönecek.
        public async Task<Account> GetWithDetailsAsync(int id)
        {
            //await der ki:
            // "Veritabanından bu sorgunun sonucunu bekle, tamamlanınca sonucu döndür."Bu sayede program burada bekler ama başka işleri engellemez.
            //veritabanondan veri çektiğimiz için await kullanma ihtiyacı duyuyoruz,veritabanı işlemleri uzun sürüyor
            return await _context.Accounts
                .Include(a => a.Cards)
                .Include(a => a.Transactions)
                .FirstOrDefaultAsync(a => a.Id == id);
            //FirstOrDefaultAsync: Veritabanında, şartı sağlayan ilk kaydı asenkron olarak getirir.
            //(a => a.Id) hesapların idsini gösterir.
        }
    }
}

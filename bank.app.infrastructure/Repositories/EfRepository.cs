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
    public class EfRepository<T> : IRepository<T> where T : class, IEntity
    {  //readonly: Bu alan sadece constructor (yapıcı metod) içinde bir kez atanabilir. Sonradan değiştirilemez.
        protected readonly BankDbContext _context;//bağlantı
        protected readonly DbSet<T> _dbSet;//tablo

        public EfRepository(BankDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        //veri getiriyor
        //IEnumerable <T> : T tipinde bir koleksiyon döndürüyor, yani birden fazla veri olabilir.
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        //veri getiriyor
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        //veri ekliyor
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        //veri güncelliyor
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        //veri siliyor
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        //hepsini kaydediyor
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

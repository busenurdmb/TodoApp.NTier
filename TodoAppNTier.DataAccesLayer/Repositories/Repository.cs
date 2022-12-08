using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DataAccesLayer.Context;
using TodoAppNTier.DataAccesLayer.Interfaces;
using TodoAppNTier.EntityLayer.Concrete_Domains;

namespace TodoAppNTier.DataAccesLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T :Base_Entity
    {
        private readonly TodoContext _context;

        public Repository(TodoContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
          await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> Find(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        
        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            //bu deletedıd null alabilir böyle yapmamalı entity den almalı
            //controlu businessda yapılmalı
          //  var deletedıd = _context.Set<T>().Find(id);
             _context.Set<T>().Remove(entity);
        }

        public void Update(T entity,T unchanged)
        {
            //update methodu şunu yapıyor geliyor ilgili entity doğrudan
            //entry sinin statetini doğrudan modified olarak setliyor
            //şöyle bir sorunla karşı karşıya klaıyoruz
            //değişmemiş propertimi ben database tarafına gönderiyorum 
            //ancak ben istiyorumki değişmemiş propertim databaase tarfaıına hiç göndermiyim
            //_context.Set<T>().Update(entity);
          //  var updateEntity = _context.Set<T>().Find(entity.Id);
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}

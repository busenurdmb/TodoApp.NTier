using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DataAccesLayer.Context;
using TodoAppNTier.DataAccesLayer.Interfaces;
using TodoAppNTier.DataAccesLayer.Repositories;
using TodoAppNTier.EntityLayer.Concrete_Domains;

namespace TodoAppNTier.DataAccesLayer.UnitofWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;

        public Uow(TodoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : Base_Entity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}

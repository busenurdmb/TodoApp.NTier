using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DataAccesLayer.Interfaces;
using TodoAppNTier.EntityLayer.Concrete_Domains;

namespace TodoAppNTier.DataAccesLayer.UnitofWork
{
   public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : Base_Entity;
        Task SaveChanges();
    }
}

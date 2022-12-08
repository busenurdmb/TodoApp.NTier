using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DataAccesLayer.Configurations;
using TodoAppNTier.EntityLayer.Concrete_Domains;

namespace TodoAppNTier.DataAccesLayer.Context
{
   public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WokrConfiguration());
           
        }
        public DbSet<Work> Works { get; set; }
    }
}

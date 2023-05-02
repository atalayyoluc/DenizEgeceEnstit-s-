using Data.Context;
using Data.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Concretes
{
    public class Repository<T>:IRepository<T> where T : class,new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public IQueryable<T> GetAll(/*Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties*/)
        {
            IQueryable<T> query = Table;

            //if (filter != null)
            //{
            //    query = query.Where(filter);
            //}
            //if (includeProperties.Any())
            //{
            //    foreach (var item in includeProperties)
            //    {
            //        query = query.Include(item);
            //    }
            //}
            return query;
        }
    }
}

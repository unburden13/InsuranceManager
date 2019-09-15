using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InsuranceManager.Domain;



namespace InsuranceManager.SqlRepository
{
    public class BaseRepository<T> where T : class
    {
        protected DbContext Context = new Context();
        protected DbSet<T> DbSet;

        public BaseRepository()
        {
            DbSet = Context.Set<T>();
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void CreateRange(IEnumerable<T> entityList)
        {
            DbSet.AddRange(entityList);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

    }
}

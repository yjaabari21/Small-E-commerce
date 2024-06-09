using System;
using System.Data.Entity;
using System.Linq;
using HelloWorld.Data;

namespace HelloWorld.Services
{
    public abstract class Repository<T> where T : class
    {
        protected readonly MyDBEntities _context;
        protected readonly DbSet<T> Table;

        public Repository(MyDBEntities context)
        {
            _context = context;
            Table = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public T GetById(params object[] pks)
        {
            return Table.Find(pks);
        }

        public bool Add(T entity)
        {
            try
            {
                Table.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return true;
                }
                Table.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
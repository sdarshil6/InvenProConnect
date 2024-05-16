using InvenProConnect.DAOs.Interfaces;
using InvenProConnect.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace InvenProConnect.DAOs.Implementations
{
    public class BaseDao<T> : IBaseDao<T> where T : class
    {
        private InventoryManagementSystemContext _context;
        private DbSet<T> table;
        public BaseDao(InventoryManagementSystemContext context) 
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Create(T entity)
        {
            table.Add(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return table.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }
    }
}

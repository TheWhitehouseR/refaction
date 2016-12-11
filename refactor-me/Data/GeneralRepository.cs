using ProductsApi.Attributes;
using ProductsApi.Contracts;
using ProductsApi.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProductsApi.Data
{
    /// <summary>
    /// A general implementation of the IRepository 
    /// </summary>
    [Component(Scope = ScopeEnum.Transient, RegisterAsImplementedInterface = true)]
    public class GeneralRepository : IRepository
    {
        private readonly ProductDbContext _context;

        public GeneralRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Insert<T>(T item) where T : class, IEntity
        {
            _context.Set<T>().Add(item);
        }

        public void Insert<T>(IEnumerable<T> items) where T : class, IEntity
        {
            _context.Set<T>().AddRange(items);
        }

        public void Update<T>(T item) where T : class, IEntity
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete<T>(Guid guid) where T : class, IEntity
        {
            var item = _context.Set<T>().Find(guid);

            if (item == null)
            {
                throw new KeyNotFoundException($"Could not find the item with id: {guid} and type {typeof(T)}");
            }

            _context.Set<T>().Remove(item);

        }

        /// <summary>
        /// Saves the changes that have been made to the repository.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Disposes the repository
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        IQueryable<TData> IRepository.Query<TData>()
        {
            return _context.Set<TData>();
        }
    }
}

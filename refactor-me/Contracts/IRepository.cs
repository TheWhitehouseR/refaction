using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsApi.Contracts
{
    public interface IRepository : IDisposable
    {
        IQueryable<TData> Query<TData>() where TData : class, IEntity;

        /// <summary>
        /// Insert a single item into the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        void Insert<T>(T item) where T : class, IEntity;

        /// <summary>
        /// Insert multiple items into the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        void Insert<T>(IEnumerable<T> items) where T : class, IEntity;

        /// <summary>
        /// Update a single item in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        void Update<T>(T item) where T : class, IEntity;

        /// <summary>
        /// Delete a single item in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        void Delete<T>(Guid guid) where T : class, IEntity;

        /// <summary>
        /// Saves the changes that have been made to the repository.
        /// </summary>
        void SaveChanges();
    }
}
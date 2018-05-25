using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NETCoreSimpleApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreSimpleApp.Data.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        protected readonly MovieRentalDbContext context;

        public Repository(MovieRentalDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Saves all the changes made in the context to the database.
        /// </summary>
        protected void Save()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Passes a delegate from outside and determines, which elements to search and returns the count of them.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate).Count();
        }

        /// <summary>
        /// Passes the entity and adds this object to the context, then saves the change.
        /// </summary>
        /// <param name="entity"></param>
        public void Create(T entity)
        {
            context.Add(entity);
            Save();
        }

        /// <summary>
        /// Removes the entity from the context and saves.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            context.Remove(entity);
            Save();
        }

        /// <summary>
        /// Passes a delegate from outside to search, which elements to return.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        /// <summary>
        /// Gets the set of entities and returns this value.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        /// <summary>
        /// Calls to the current set and finds an entity by primary IDs.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        /// <summary>
        /// Changes state of the object and saves it.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}

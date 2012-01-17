using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Core.DomainObjects;

namespace Data.Repository
{
    public interface IDatabase
    {
        //Data Sources
        

        //Heavy Lifting
        void Delete<TEntity>(TEntity instance) where TEntity : class;
        void DeleteAll<TEntity>(IEnumerable<TEntity> instances) where TEntity : class;
        IList<TEntity> DeleteChangeSet<TEntity>() where TEntity : class;
        ITable GetEditable<TEntity>() where TEntity : class;
        IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;
        void Insert<TEntity>(TEntity instance) where TEntity : class;
        void InsertAll<TEntity>(IEnumerable<TEntity> instances) where TEntity : class;
        IList<TEntity> InsertChangeSet<TEntity>() where TEntity : class;
        IList<TEntity> UpdateChangeSet<TEntity>() where TEntity : class;
        void SubmitChanges();
    }
}

using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arac-Takip.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T GetByID(string Id);

        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);

        IEnumerable<T> WhereDynamicLinq(string query);

        IEnumerable<T> WhereDynamicLinqString(string query, string columnName, List<string> filterList, Func<T, bool> where);

        IEnumerable<T> WhereAndDynamicLinqString(Expression<Func<T, bool>> where, string query);

        void Add(T Entity);

        void Update(T Entity);

        void Delete(T Entity);

        void RemoveRange(List<T> Entity);

        void InsertListEntity(List<T> Entity);

        ICollection<T> GetAll();

        T Find(Expression<Func<T, bool>> where);

        T SingleOrDefault(Expression<Func<T, bool>> where);

        T FirstOrDefault(Expression<Func<T, bool>> where = null);

        T LastOrDefault(Expression<Func<T, bool>> where);

        T Single();

        T First();

        bool Any(Expression<Func<T, bool>> where = null);

        List<T> ToList();

        List<T> Where(Expression<Func<T, bool>> where);

        void UpdateRange(List<T> Entities);

        void AddRange(IEnumerable<T> Entities);

        void AddRangeIfNotExist(IEnumerable<T> Entities);

        //void RemoveRange(List<T> Entities);

        IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);

        IMongoCollection<T> TableChanged();

        IMongoCollection<BsonDocument> GetBsonDocumentCollection(string collectionName);

        int Count(Expression<Func<T, bool>> where);

        List<T> AsQueryable(Expression<Func<T, bool>> predicate);

        List<T> Contains(string MongoColumnName, string MongoValue, Expression<Func<T, bool>> Sqlpredicate);

        void EmptyTable();
    }
}

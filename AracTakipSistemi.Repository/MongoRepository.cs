using AracTakipSistemi.DAL.MongoContext;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Eselfware.Repository
{
    public abstract class MongoRepository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<T> DbSet;

        protected MongoRepository(IMongoContext context)
        {
            Context = context;
        }

        public T GetByID(string _id)
        {
            ConfigDbSet();
            var data = DbSet.Find(Builders<T>.Filter.Eq("_id", _id));
            return data != null ? data.SingleOrDefault() : null;
        }

        public void AddRange(IEnumerable<T> Entities)
        {
            var objList = (List<T>)Entities;
            if (objList.Count > 0)
            {
                ConfigDbSet();
                DbSet.InsertMany(Entities);
            }
        }

        public void AddRangeIfNotExist(IEnumerable<T> Entities)
        {
            if (!Entities.Any())
                return;

            ConfigDbSet();

            var ids = Entities.Select(x => x.GetType().GetProperty("_id")?.GetValue(x)).ToList();

            var filter = Builders<T>.Filter.Ne("_id", ids);
            var all = DbSet.Find(filter).ToList();

            var addIddList = ids.Except(all.ToList().Select(x => x.GetType().GetProperty("_id")?.GetValue(x))).ToList();

            var addList = Entities.Where(x => addIddList.Contains(x.GetType().GetProperty("_id")?.GetValue(x))).ToList();
            AddRange(addList);
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();
            return where == null ? DbSet.AsQueryable().Any() : DbSet.AsQueryable().Any(where == null ? null : where);

        }

        public void Delete(T Entity)
        {
            ConfigDbSet();
            object _id = Entity.GetType().GetProperty("_id").GetValue(Entity);
            DbSet.DeleteOne(Builders<T>.Filter.Eq("_id", _id));
        }

        public void RemoveRange(List<T> Entity)
        {
            ConfigDbSet();
            if (Entity != null)
            {
                var filter = Builders<T>.Filter.In("_id", Entity.Select(x => x.GetType().GetProperty("_id")?.GetValue(x)));
                DbSet.DeleteMany(filter);
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();

            return (T)this.Where(where).FirstOrDefault();
        }

        public T First()
        {
            ConfigDbSet();
            var firstOrDefault = DbSet.Find(Builders<T>.Filter.Empty).ToList();
            return (T)firstOrDefault.FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where = null)
        {
            ConfigDbSet();

            if (where == null)
                return DbSet.Find(Builders<T>.Filter.Empty).FirstOrDefault();

            var filter = Builders<T>.Filter.Where(where);

            return DbSet.Find(filter).FirstOrDefault();
        }

        public ICollection<T> GetAll()
        {
            ConfigDbSet();
            var all = DbSet.Find(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public List<T> ToList()
        {
            ConfigDbSet();
            var all = DbSet.Find(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public void Add(T Entity)
        {
            ConfigDbSet();
            DbSet.InsertOne(Entity);
        }

        public void InsertListEntity(List<T> Entity)
        {
            ConfigDbSet();
            for (int i = 0; i < Entity.Count; i++)
            {
                DbSet.InsertOne(Entity[i]);
            }
        }

        public T LastOrDefault(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();
            var firstOrDefault = DbSet.Find(where).ToList();
            return (T)firstOrDefault.LastOrDefault();
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            ConfigDbSet();
            var all = DbSet.Find(Builders<T>.Filter.Empty).ToList();
            throw new NotImplementedException();
        }

        //public void RemoveRange(List<T> Entity)
        //{
        //    ConfigDbSet();
        //    foreach (var item in Entity)
        //    {
        //        if (Entity != null)
        //        {
        //            var filter = Builders<T>.Filter.In("_id", Entity.Select(x => x.GetType().GetProperty("_id")?.GetValue(x)));
        //            DbSet.DeleteMany(filter);
        //        }
        //    }
        //}

        public IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            throw new NotImplementedException();
        }

        public T Single()
        {
            ConfigDbSet();
            var data = DbSet.Find(Builders<T>.Filter.Empty);

            return data.SingleOrDefault();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            ConfigDbSet();
            //Builders<T>.Update.AddToSet("_id", Entity.GetObjectId());
            object _id = Entity.GetType().GetProperty("_id").GetValue(Entity);
            DbSet.ReplaceOne(Builders<T>.Filter.Eq("_id", _id), Entity);
        }

        public void UpdateRange(List<T> Entities)
        {
            ConfigDbSet();

            for (int i = 0; i < Entities.Count; i++)
            {
                object _id = Entities[i].GetType().GetProperty("_id").GetValue(Entities[i]);

                DbSet.ReplaceOne(Builders<T>.Filter.Eq("_id", _id), Entities[i]);
            }
        }

        public List<T> Where(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();
            var all = DbSet.Find(where);
            return all.ToList();
        }

        public IEnumerable<T> WhereAndDynamicLinqString(Expression<Func<T, bool>> where, string query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> WhereDynamicLinq(string query)
        {
            return DbSet.AsQueryable().Where(query).ToList();
        }

        public IEnumerable<T> WhereDynamicLinqString(string query, string columnName, List<string> filterList, Func<T, bool> where)
        {
            ConfigDbSet();
            //var d = DbSet.Find(where);
            //var filter = d.Filter.(columnName, filterList);
            //var all2 = d.ToList().Find(filter);
            //---------------------------------------------
            var filter = Builders<T>.Filter.In(columnName, filterList);
            var all2 = DbSet.Find(filter);
            //---------------------------------------------
            return all2.ToList().Where(where);
            //var all2 = DbSet.Find(query).ToList().Where(where);
            //var all2 = DbSet.Find(where).ToList();
            //var filter = all2.Where(Builders<T>.Filter.In(columnName, filterList)).ToList();
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> TableChanged()
        {
            ConfigDbSet();
            return DbSet;
        }

        [Obsolete]
        public int Count(Expression<Func<T, bool>> where)
        {
            ConfigDbSet();
            var all = DbSet.Find(Builders<T>.Filter.Empty);
            return all.ToList().Count;
        }

        public List<T> AsQueryable(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsQueryable().Where(predicate).ToList();
        }

        public List<T> Contains(string MongoColumnName, string MongoValue, Expression<Func<T, bool>> Sqlpredicate)
        {
            throw new NotImplementedException();
        }

        public void EmptyTable()
        {
            ConfigDbSet();
            DbSet.DeleteMany(Builders<T>.Filter.Empty);
        }

        public IMongoCollection<BsonDocument> GetBsonDocumentCollection(string collectionName)
        {
            ConfigDbSet();
            return Context.GetCollection<BsonDocument>(collectionName);
        }
    }
}
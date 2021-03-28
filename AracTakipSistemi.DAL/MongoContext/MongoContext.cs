using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AracTakipSistemi.DAL.MongoContext
{
    public class MongoContext : IMongoContext
    {
        public static IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;

        public MongoContext()
        {
            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }

        public MongoContext(IMongoDatabase database)
        {
            Database = database;
            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }

        public int SaveChanges()
        {
            ConfigureMongo();

            using (Session = MongoClient.StartSession())
            {
                Session.StartTransaction();
                var commandTasks = _commands.Select(c => c());
                Task.WhenAll(commandTasks);
                Session.CommitTransaction();
            }

            return _commands.Count;
        }
        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            MongoClient = new MongoClient("mongodb://admin:1234@localhost:27017/?authSource=db_AracTakip&readPreference=primary&appname=MongoDB%20Compass&ssl=false");

            Database = MongoClient.GetDatabase("db_AracTakip");
             

        }




        [Obsolete]
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }

}

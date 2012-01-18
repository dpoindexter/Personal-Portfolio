using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Norm;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class mongo
    {
        public List<TCollection> GetCollection<TCollection>()
        {
            var collection = new List<TCollection>();
            using (var db = Mongo.Create("_conn"))
            {
                collection = db.GetCollection<TCollection>().Find().ToList();
            }
            return collection;
        }

        public TItem GetItemById<TItem>(ObjectId id)
            //where TItem : IMongoIdentified
        {
            using (var db = Mongo.Create("_conn"))
            {
                return db.GetCollection<TItem>().FindOne(new { _id = id});
            }
        }

        public void SaveItem<TItem>(TItem item)
        {
            using (var db = Mongo.Create("_conn"))
            {
                db.GetCollection<TItem>().Save(item);
            }
        }

        public TItem SaveAndReturnItem<TItem>(TItem item)
        {
            using (var db = Mongo.Create("_conn"))
            {
                db.GetCollection<TItem>().Save(item);
                return db.GetCollection<TItem>().FindOne(item);
            }
        }

        public TItem FindOne<TItem>(object spec)
        {
            using (var db = Mongo.Create("_conn"))
            {
                return db.GetCollection<TItem>().FindOne(spec);
            }
        }

        public TItem FindOne<TItem>(Func<TItem, bool> func)
        {
            using (var db = Mongo.Create("_conn"))
            {
                return db.GetCollection<TItem>().AsQueryable().Where(func).FirstOrDefault();
            }
        }

        public List<TItem> Find<TItem>(Func<TItem, bool> func)
        {
            using (var db = Mongo.Create("_conn"))
            {
                return db.GetCollection<TItem>().AsQueryable().Where(func).ToList();
            }
        }

        public void Add<T>(IEnumerable<T> items) where T : class, new()
        {
            using (var db = Mongo.Create("_conn"))
            {
                db.GetCollection<T>().Insert(items);
            }
        }

        public void Add<T>(T item) where T : class, new()
        {
            using (var db = Mongo.Create("_conn"))
            {
                db.GetCollection<T>().Insert(item);
            }
        }

        public void Delete<T>(object template) where T : class, new()
        {
            using (var db = Mongo.Create("_conn"))
            {
                db.GetCollection<T>().Delete(template);
            }
        }

        public void Delete<T>(T item) where T : class, new()
        {
            using (var db = Mongo.Create("_conn"))
            {
                db.GetCollection<T>().Delete(item);
            }
        }

        public void UpdateOne<T>(object item, object update)
        {
            using (var db = Mongo.Create("_conn"))
            {
                db.GetCollection<T>().UpdateOne(item, item);
            }
        }

        public int GenerateHiloId<T>()
        {
            using (var db = Mongo.Create("_conn"))
            {
                return (int)db.GetCollection<T>().GenerateId();
            }
        }

        public string _conn { get; set; }
    }
}

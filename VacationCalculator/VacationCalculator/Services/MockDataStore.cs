using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VacationCalculator.Models;

namespace VacationCalculator.Services
{
    public class DataStore : IDataStore<Item>
    {
        public DataStore()
        {
            AsyncDBConnection.DB.CreateTableAsync<Item>().Wait();
        }

        public int ItemCount
        {
            get
            {
                return AsyncDBConnection.DB.Table<Item>().CountAsync().Result;
            }
        }

        public int SetItem(Item item)
        {
            return AsyncDBConnection.DB.InsertOrReplaceAsync(item).Result;
        }

        public int DeleteItem(string id)
        {
            if (HasItem(id))
                return AsyncDBConnection.DB.DeleteAsync<Item>(id).Result;

            return -1;
        }

        public Item GetItem(string id)
        {
            if (HasItem(id))
                return AsyncDBConnection.DB.FindAsync<Item>(id).Result;

            return null;
        }

        public bool HasItem(string id)
        {
            int num = AsyncDBConnection.DB.Table<Item>().Where(x => x.Date == id).CountAsync().Result;
            return (num > 0);
        }

        public IEnumerable<Item> GetItems(bool forceRefresh = false)
        {
            return AsyncDBConnection.DB.Table<Item>().ToListAsync().Result;
        }
    }

    public class SettingParamsStore : IDataStore<SettingItem>
    {
        public SettingParamsStore()
        {   
            AsyncDBConnection.DB.CreateTableAsync<SettingItem>().Wait();
        }

        public int ItemCount
        {
            get
            {
                return AsyncDBConnection.DB.Table<SettingItem>().CountAsync().Result;
            }
        }

        public int SetItem(SettingItem item)
        {
            return AsyncDBConnection.DB.InsertOrReplaceAsync(item).Result;
        }

        public int DeleteItem(string id)
        {
            if (HasItem(id))
                return AsyncDBConnection.DB.DeleteAsync<SettingItem>(id).Result;

            return -1;
        }

        public SettingItem GetItem(string id)
        {
            if(HasItem(id))
            {
                return AsyncDBConnection.DB.FindAsync<SettingItem>(id).Result;
            }

            return null;
        }

        public bool HasItem(string id)
        {
            int num = AsyncDBConnection.DB.Table<SettingItem>().Where(x => x.Id == id).CountAsync().Result;
            return (num > 0);
        }

        public IEnumerable<SettingItem> GetItems(bool forceRefresh = false)
        {
            return AsyncDBConnection.DB.Table<SettingItem>().ToListAsync().Result;
        }
    }
}
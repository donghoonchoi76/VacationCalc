using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VacationCalculator.Models;

namespace VacationCalculator.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly SQLiteAsyncConnection _database;

        public MockDataStore()
        {
            _database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vacation.db3"));
            _database.CreateTableAsync<Item>().Wait();
        }

        public int ItemCount
        {
            get
            {
                return _database.Table<Item>().CountAsync().Result;
            }
        }

        public async Task<int> AddItemAsync(Item item)
        {
            return await _database.InsertOrReplaceAsync(item);
        }

        public async Task<int> UpdateItemAsync(Item item)
        {
            return await _database.InsertOrReplaceAsync(item);
        }

        public async Task<int> DeleteItemAsync(string id)
        {
            return await _database.DeleteAsync<Item>(id);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await _database.FindAsync<Item>(id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await _database.Table<Item>().ToListAsync();
        }
    }
}
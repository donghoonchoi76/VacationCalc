using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace VacationCalculator.Services
{
    public interface IDataStore<T>
    {
        int ItemCount { get; }

        int SetItem(T item);
        int DeleteItem(string id);
        T GetItem(string id);
        IEnumerable<T> GetItems(bool forceRefresh = false);
    }

    public sealed class AsyncDBConnection
    {
        readonly SQLiteAsyncConnection _database;
        private static AsyncDBConnection instance = null;

        private AsyncDBConnection()
        {
            _database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vacation.db3"));
        }
        
        public static SQLiteAsyncConnection DB
        {
            get
            {
                if (instance == null)
                {
                    instance = new AsyncDBConnection();
                }
                return instance._database;
            }
        }
    }
}

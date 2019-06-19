using Achele.Data.Interfaces;
using Achele.Data.Repositories;
using Achele.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achele.Data
{
    public class DataBase
    {
        protected readonly SQLiteAsyncConnection database;

        public DataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }

        public IRepository<User> userService
        {
            get { return new BaseRepository<User>(database); }
        }
    }
}
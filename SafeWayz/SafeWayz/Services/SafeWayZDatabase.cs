﻿using SafeWayz.Model;
using SafeWayz.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SafeWayz.Services
{
    public class SafeWayZDatabase : IDatabase
    {
        private SQLiteAsyncConnection userDatabase;

        public SafeWayZDatabase()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Information.db3");

            userDatabase = new SQLiteAsyncConnection(dbPath);
            userDatabase.CreateTableAsync<UserModel>().Wait();
        }
        public Task<List<UserModel>> GetAllInformationData()
        {
            return userDatabase.Table<UserModel>().ToListAsync();

        }

        public Task<UserModel> GetPeopleByUserName(string username)
        {
            return userDatabase.Table<UserModel>().Where(x => x.UserName == username).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllInformation()
        {
            return userDatabase.DeleteAllAsync<UserModel>();
        }

        public Task<int> SaveItemAsync(UserModel info)
        {
            return userDatabase.InsertAsync(info);
        }

    }
}

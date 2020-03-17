using SafeWayz.Model;
using SafeWayz.Models;
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
            userDatabase.CreateTableAsync<IncidentReport>().Wait();
        }


        //USER MODEL DATABASE STUFF
        /////////////////////////////////////////////////////////////////////////////

        public Task<List<UserModel>> GetAllInformationData()
        {
            return userDatabase.Table<UserModel>().ToListAsync();

        }

        public Task<UserModel> GetPeopleById(int id)
        {
            return userDatabase.Table<UserModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllInformation()
        {
            return userDatabase.DeleteAllAsync<UserModel>();
        }

        public Task<int> SaveItemAsync(UserModel info)
        {
            return userDatabase.InsertAsync(info);
        }

        //INCIDENT REPORTS DATABASE STUFF
        /////////////////////////////////////////////////////////////////////////////
        
        public Task<List<IncidentReport>> GetAllIncidentReportInformationData()
        {
            return userDatabase.Table<IncidentReport>().ToListAsync();
        }

        public Task<IncidentReport> GetIncidentById(int id)
        {
            return userDatabase.Table<IncidentReport>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }
        
        public Task<int> DeleteAllIncidentReportInformation()
        {
            return userDatabase.DeleteAllAsync<IncidentReport>();
        }

        public Task<int> SaveIncidentReportAsync(IncidentReport newReport)
        {
            return userDatabase.InsertAsync(newReport);
        }

        /////////////////////////////////////////////////////////////////////////////

        public void PointAllocation()
        {
            var gamification = new UserModel();
                gamification.Point = 200;
        }

    }
}

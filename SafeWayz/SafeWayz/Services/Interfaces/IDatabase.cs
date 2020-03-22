using SafeWayz.Model;
using SafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeWayz.Services.Interfaces
{
    public interface IDatabase
    {
        Task<int> SaveItemAsync(UserModel info);
        Task<List<UserModel>> GetAllInformationData();
        Task<UserModel> GetPeopleById(int id);

        Task<List<IncidentReport>> GetAllIncidentReportInformationData();
        Task<IncidentReport> GetIncidentById(int id);
        Task<int> DeleteAllIncidentReportInformation();
        Task<int> SaveIncidentReportAsync(IncidentReport newReport);
    }
}

using SafeWayz.Model;
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
        Task<UserModel> GetPeopleByUserName(string username);

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeWayz.Model.Security
{
    public interface ISecurityService
    {
        IList<MenuItem> GetAllowedAccessItems();
        Task<bool> Login(string UserName, string Password);
        void LogOut();
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Model;

namespace Service.User
{
    public interface IUserService
    {
        Task<UserVm> SaveUser(UserVm user);
        Task<List<UserVm>> GetUsers();
        Task<bool> Delete(int userId);
        Task<UserVm> GetById(int userId);
    }
}

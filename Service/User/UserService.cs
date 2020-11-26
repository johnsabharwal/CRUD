using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Service.User
{
    public class UserService : IUserService
    {
        private readonly DBContext _dbContext;
        public UserService(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<UserVm> SaveUser(UserVm user)
        {
            _dbContext.Users.Add(new Data.Entities.User()
            {
                Email = user.Email,
                RoleType = user.RoleType,
                Status = user.Status,
                Name = user.Name
            });
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserVm>> GetUsers()
        {
            return await _dbContext.Users.Select(x => new UserVm() { RoleType = x.RoleType, Email = x.Email, Name = x.Name, Status = x.Status }).ToListAsync();
        }

        public async Task<bool> Delete(int userId)
        {
            Data.Entities.User entityToDelete = _dbContext.Users.Find(userId);
            _dbContext.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UserVm> GetById(int userId)
        {
            return await _dbContext.Users.Where(x => x.Id.Equals(userId))
                .Select(x => new UserVm() { RoleType = x.RoleType, Email = x.Email, Name = x.Name, Status = x.Status })
                .FirstOrDefaultAsync();
        }
    }
}

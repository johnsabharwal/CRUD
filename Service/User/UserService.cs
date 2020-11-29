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
        private const string email = "{name}@locusnine.com";
        public UserService(DBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<UserVm> SaveUser(UserVm user)
        {
            return await (user.Id > 0 ? Update(user) : InsertAsync(user));
        }

        private async Task<UserVm> Update(UserVm user)
        {
            var userData = _dbContext.Users.FirstOrDefault(x => x.Id == user.Id);
            if (userData != null)
            {
                userData.Name = user.Name;
                userData.Email = email.Replace("{name}", user.Name);
                userData.RoleType = user.RoleType;

                await _dbContext.SaveChangesAsync();

            }

            return user;
        }

        private async Task<UserVm> InsertAsync(UserVm user)
        {
            var existingCount = _dbContext.Users.Count(x => x.Name.Equals(user.Name));
            _dbContext.Users.Add(new Data.Entities.User()
            {
                Email = email.Replace("{name}", existingCount > 0 ? user.Name + (existingCount + 1) : user.Name),
                RoleType = user.RoleType,
                Status = Data.Enum.Status.Active.ToString(),
                Name = user.Name
            });
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserVm>> GetUsers()
        {
            return await _dbContext.Users.Select(x => new UserVm() { RoleType = x.RoleType, Email = x.Email, Name = x.Name, Status = x.Status, Id = x.Id }).ToListAsync();
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

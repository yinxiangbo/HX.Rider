using HX.Rider.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HX.Rider.IRepository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<List<UserEntity>> GetUsers();

        Task<UserEntity> GetUser(long userId);

        Task<UserEntity> GetUser(string userName);

        Task<bool> AddUser(UserEntity entity);

        Task<bool> DeleteUser(UserEntity entity);

        Task<bool> DeleteUser(long userId);

        Task<bool> UpdateUser(UserEntity entity);
    }
}

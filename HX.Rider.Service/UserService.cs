using AutoMapper;
using HX.Rider.Common.Helper;
using HX.Rider.Entity;
using HX.Rider.Exception;
using HX.Rider.IRepository;
using HX.Rider.IService;
using HX.Rider.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HX.Rider.Service
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService : BaseService, IUserService
    {

        #region Constructor DI
        /// <summary>
        /// Token服务
        /// </summary>
        private readonly IUserRepository userRepository;
        /// <summary>
        /// 构造器，DI
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository,ILogger<BaseService> logger,IMapper mapper)
            :base(logger,mapper)
        {
            this.userRepository = userRepository;
        } 
        #endregion
        /// <summary>
        /// CheckUserNameAndPwd
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserModel> IsValidUserCredentials(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new HXException(HXExceptionCode.AUTH_FAILED, "用户名或者密码为空", HXExceptionLevel.Warning);
            var user = await userRepository.GetUser(userName);
            if (user == null)
                throw new HXException(HXExceptionCode.USER_NOT_EXISTS,"用户不存在", HXExceptionLevel.Warning);
            string encryptedPassword = SecureHelper.MD5(password);//一次MD5加密
            string encryptedWithSaltPassword = SecureHelper.MD5AddingSalt(password,user.PasswordSalt);//加盐MD5

            if (encryptedWithSaltPassword.ToLower() != user.Password.ToLower())
                throw new HXException(HXExceptionCode.AUTH_FAILED, "密码错误", HXExceptionLevel.Warning);
            return Mapper.Map<UserModel>(user);
        }

        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>

        public async Task<List<UserModel>> GetUserList()
        {
            var userList = new List<UserModel>();
            userList.Add(new UserModel() { Id = 123, UserName = "admin" });
            userList.Add(new UserModel() { Id = 234, UserName = "用户1" });
            userList.Add(new UserModel() { Id = 345, UserName = "用户2" });
            userList.Add(new UserModel() { Id = 456, UserName = "用户3" });
            userList.Add(new UserModel() { Id = 567, UserName = "用户4" });
            return userList;
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> CreateUser(UserDto user)
        {
            if (user == null) return false;
            var entity=Mapper.Map<UserEntity>(user);
            var passwordSalt= GeneratePasswordSalt();
            entity.Password = SecureHelper.MD5AddingSalt(user.Password, passwordSalt);
            entity.PasswordSalt = passwordSalt;
            entity.Status = (int)UserStatus.Normal;
            return await userRepository.AddUser(entity);
        }
        #region Private Method
        /// <summary>
        /// 生成盐值
        /// </summary>
        /// <returns></returns>
        private string GeneratePasswordSalt()
        {
            var payCode = new SnowflakeIdHelper(1, 1).NextId();
            return SecureHelper.Base64Encode(payCode.ToString());
        } 
        #endregion
    }
}

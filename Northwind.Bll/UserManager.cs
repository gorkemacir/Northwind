using Microsoft.AspNetCore.Http;
using Northwind.Dal.Abstract;
using Northwind.Entity.Base;
using Northwind.Entity.Dto;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Northwind.Bll
{
    public class UserManager : GenericManager<User, DtoUser>, IUserService
    {
        public readonly IUserRepository userRepository;
        private IConfiguration configuration;

        public UserManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
            this.configuration = configuration;
        }

        public IResponce<DtoUserToken> Login(DtoLogin login)
        {
            var user = userRepository.Login(ObjectMapper.Mapper.Map<User>(login));

            if(user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLoginUser>(user);

                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);

                var userToken = new DtoUserToken()
                {
                    DtoLoginUser = dtoUser,
                    AccessToken = token
                };

                return new Responce<DtoUserToken>
                {
                    Message = "Token üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Responce<DtoUserToken>
                {
                    Message = "Kullanıcı kodu veya parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }
    }
}

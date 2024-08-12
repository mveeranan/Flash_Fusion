using Flash_Fusion.Application._System._Login.Dto;
using Flash_Fusion.Core._System.Models;
using Flash_Fusion.EntityFrameWorkCore._System.Repository._Users;
using Flash_Fusion.EntityFrameWorkCore._System.Services._Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Fusion.Application._System.Repositories._Login
{
    public class LoginRepository : ILoginRepository
    {

        private readonly ILoginServices _loginServices;
        public LoginRepository(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        public async Task<List<Users>> Login(LoginDto login)
        {
            return await _loginServices.Login(login);
        }
    }
}

using Flash_Fusion.Application._System._Login.Dto;
using Flash_Fusion.Core._System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Fusion.Application._System.Repositories._Login
{
    public interface ILoginRepository
    {
        public Task<List<Users>> Login(LoginDto login);
    }
}

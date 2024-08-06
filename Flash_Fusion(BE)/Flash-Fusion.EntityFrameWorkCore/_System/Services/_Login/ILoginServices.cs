using Flash_Fusion.Application._System._Login.Dto;
using Flash_Fusion.Core._System.Models;
using Flash_Fusion.EntityFrameWorkCore._System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Fusion.EntityFrameWorkCore._System.Services._Login
    {
    public interface ILoginServices
        {
        public Task<List<Users>> Login(LoginDto login);
        }
    }

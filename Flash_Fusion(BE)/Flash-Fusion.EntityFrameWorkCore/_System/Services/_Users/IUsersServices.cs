using Flash_Fusion.Core._System.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Fusion.EntityFrameWorkCore._System.Repository._Users
{
    public interface IUsersServices
        {
        public Task<IEnumerable<Users>> GetAll();
        public Task<List<Users>> Get(int id);
        public Task<string> Create(Users users);
        public Task<string> Update(Users users);
        public Task<string> Delete(int id);

        }
}

using Flash_Fusion.Core._System.Models;
using Flash_Fusion.EntityFrameWorkCore._System.Data;
using Flash_Fusion.EntityFrameWorkCore._System.Repository._Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Fusion.Application._System.Repositories._Users
{
    public class UsersRepository : IUsersRepository
    {
        public readonly IUsersServices _usersServices;
        public UsersRepository(IUsersServices users)
        {
            _usersServices = users;
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _usersServices.GetAll();
        }
        public async Task<List<Users>> Get(int id)
            {
            return await _usersServices.Get(id);
            }

        public async Task<string> Create(Users users)
            {
            return await _usersServices.Create(users);
            }

        public async Task<string> Update(Users users)
            {
            return await _usersServices.Update(users);
            }
        public async Task<string> Delete(int id)
            {
            return await _usersServices.Delete(id);
            }

        }
}

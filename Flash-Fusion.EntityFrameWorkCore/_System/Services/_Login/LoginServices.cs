using Flash_Fusion.Application._System._Login.Dto;
using Flash_Fusion.Core._System.Models;
using Flash_Fusion.EntityFrameWorkCore._System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Fusion.EntityFrameWorkCore._System.Services._Login
    {
    public class LoginServices : ILoginServices
        {

        private readonly ApplicationDbContext _db;
        public LoginServices(ApplicationDbContext dbContext)
            {
            _db = dbContext;
            }
        public async Task<List<Users>> Login(LoginDto login)
            {
            string query = $"Exec UserLogin @email='{login.email}',@password='{login.password}'";
            var data = await _db.users.FromSqlRaw(query).ToListAsync();
            return data;
            }
        }
    }

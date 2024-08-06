using Azure;
using Flash_Fusion.Core._System.Models;
using Flash_Fusion.EntityFrameWorkCore._System.Data;
using JWT_Authentication_Web_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Flash_Fusion.EntityFrameWorkCore._System.Repository._Users
    {
    public class UsersServices : IUsersServices
        {

        private readonly ApplicationDbContext _db;
        public UsersServices(ApplicationDbContext dbContext)
            {
            _db = dbContext;
            }
        public async Task<IEnumerable<Users>> GetAll()
            {
            string query = $"EXEC GetAllUsers";
            var data = await _db.users.FromSqlRaw(query).ToListAsync();
            return data;
            }
        public async Task<List<Users>> Get(int id)
            {
            string query = $"EXEC GetByUserId {id}";
            var data = await _db.users.FromSqlRaw(query).ToListAsync();
            return data;
            }
        public async Task<string> Create(Users model)
            {
            string query = $"EXEC InsertUsers @Name='{model.Name}',@Email='{model.Email}',@Password='{model.Password}',@phone='{model.Phone}',@Gender='{model.Gender}',@Address='{model.Address}'";
            var data = await _db.Database.ExecuteSqlRawAsync(query);
            if (data != null)
                {
                return "User Inserted Successfully";
                }
            else
                return "";
            }

        public async Task<string> Update(Users model)
            {
            var result = await _db.users.Where(x=>x.Id == model.Id).FirstOrDefaultAsync();
            if (result != null)
                {
                string query = $"EXEC UpdateUsers @id={model.Id},@Name='{model.Name}',@Email='{model.Email}',@phone='{model.Phone}',@Gender='{model.Gender}',@Address='{model.Address}'";
                var data = await _db.Database.ExecuteSqlRawAsync(query);
                return "User Updated Successfully";
                }
            else
                {
                return "";
                }
            }

        public async Task<string> Delete(int id)
            {
            var result = await _db.users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result != null)
                {
                string query = $"EXEC DeleteUsers {id}";
                var data = await _db.Database.ExecuteSqlRawAsync(query);
                return "User Deleted Successfully";
                }
            else
                {
                return "";
                }
            }
        }
    }

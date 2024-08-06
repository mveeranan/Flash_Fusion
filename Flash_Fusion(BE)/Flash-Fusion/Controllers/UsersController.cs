using Flash_Fusion.Application._System.Repositories._Users;
using Flash_Fusion.Core._System.Models;
using Flash_Fusion.EntityFrameWorkCore._System.Data;
using JWT_Authentication_Web_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace JWT_Authentication_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
        {
        ResponseDto response = new ResponseDto();
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository=usersRepository;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
            {
            try
                {
                var data = await _usersRepository.GetAll();
                if (data != null)
                    {
                    response.StatusCode = 200;
                    response.Message = "Success";
                    response.Result = data;
                    return Ok(response);
                    }
                else
                    {
                    response.StatusCode = 404;
                    response.Message = "Success";
                    return NotFound(response);
                    }
                }
            catch
                {
                response.StatusCode = 500;
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            {
            try
                {
                var data = await _usersRepository.Get(id);
                if (data.Count > 0)
                    {
                    response.StatusCode = 200;
                    response.Message = "Success";
                    response.Result = data;
                    return Ok(response);
                    }
                else
                    {
                    response.StatusCode = 404;
                    response.Message = "Not Found";
                    return NotFound(response);
                    }
                }
            catch
                {
                response.StatusCode = 500;
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Users model)
            {
            try
                {
                var data = await _usersRepository.Create(model);
                if (data == null || data == "")
                    {
                    response.StatusCode = 400;
                    response.Message = "Bad Request";
                    return BadRequest(response);
                    }
                else
                    {
                    response.StatusCode = 201;
                    response.Message = "Success";
                    return Ok(response);
                    }
                }
            catch
                {
                response.StatusCode = 500;
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        //[Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Users model)
            {
            try
                {
                var data = await _usersRepository.Update(model);
                if (data == null || data =="")
                    {
                    response.StatusCode = 400;
                    response.Message = "Bad Request";
                    return BadRequest(response);
                    }
                else
                    {
                    response.StatusCode = 200;
                    response.Message = "Success";
                    return Ok(response);
                    }
                }
            catch
                {
                response.StatusCode = 500;
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        //[Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromHeader] int id)
            {
            try
                {
                var data = await _usersRepository.Delete(id);
                if (data == null || data == "")
                    {
                    response.StatusCode = 404;
                    response.Message = "Not Found";
                    return NotFound(response);
                    }
                else
                    {
                    response.StatusCode = 200;
                    response.Message = "Success";
                    return Ok();
                    }
                }
            catch
                {
                response.StatusCode = 500;
                response.Message = "Internal Server Error";
                return Ok(response);
                }
            }
        }
    }

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Dtos.User;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.ViewModels;

namespace ToDo.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service) 
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UserEntity>> Insert(UserInsertDto user)
        {
            try
            {
                return Ok(await _service.Post(user));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenViewModel>> Login(UserLoginDto user)
        {
            try
            {
                return Ok(await _service.FindByLogin(user));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<ActionResult<IList<UserEntity>>> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route ("{id}", Name = "GetWithId")]
        [Authorize("Bearer")]
        public async Task<ActionResult<UserEntity>> Get(int id)
        {
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<ActionResult<UserEntity>> Put(UserEntity user)
        {
            try
            {
                return Ok(await _service.Put(user));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route ("{id}", Name = "DeleteWithId")]
        [Authorize("Bearer")]
        public async Task<ActionResult<UserEntity>> Delete(int id)
        {
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
    }
}
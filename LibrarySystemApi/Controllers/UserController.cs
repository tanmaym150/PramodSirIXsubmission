using LibrarySystem.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.ViewModel;
using LibrarySystem.DAL.Data.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibrarySystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllUser());
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userService.GetUserById(id);
        }
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
        [HttpPost]
        public async void Post([FromBody] User user)
        {
            await _userService.CreateUser(user);
        }
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async void Put([FromBody] User user)
        {
            await _userService.UpdateUser(user);
        }
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var user = await _userService.GetUserById(id);
            await _userService.DeleteUser(id);
        } 
        //public void Delete(int id)
        //{
        //}
    }
}

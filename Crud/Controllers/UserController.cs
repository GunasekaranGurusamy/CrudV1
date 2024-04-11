using AutoMapper;
using Crud.API.DTO.Student;
using Crud.Data;
using Crud.DTO.Student;
using Crud.Interface;
using Crud.Model;
using Crud.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IMapper mapper, IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _user.Get());

        [HttpGet("{Id:int:min(1)}")]
        public async Task<IActionResult> Edit(int Id) => Ok(await _user.Edit(Id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UsersDTO user) => Ok(await _user.Add(user));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDTO user) => Ok(await _user.Update(user));

        [HttpDelete("{Id:int:min(0)}")]
        public async Task<IActionResult> Delete(int Id) => Ok(await _user.Delete(Id));


    }
}

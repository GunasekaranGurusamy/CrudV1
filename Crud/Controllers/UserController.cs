using AutoMapper;
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]UsersDTO user) => Ok(await _user.Add(user));
    }
}

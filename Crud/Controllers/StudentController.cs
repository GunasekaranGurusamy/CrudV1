using AutoMapper;
using Crud.Data;
using Crud.DTO.Student;
using Crud.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,Student")]
    public class StudentController : ControllerBase
    {
        IMapper _mapper;
        private readonly CrudDBContext _db;
        public StudentController(IMapper mapper,CrudDBContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet,AllowAnonymous]
        public IActionResult Get()
        {
            List<Student> students = new List<Student>();
            students= _db.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{Id:int:min(1)}",Name ="Edit")]
        public IActionResult Get(int Id)
        {
            Student student=_db.Students.Where(item=>item.Id==Id).FirstOrDefault();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentDTO Request)
        {
            Student student = _mapper.Map<Student>(Request);
            _db.Students.Add(student);
            _db.SaveChanges();
            return Ok(Request);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateStudentDTO Request)
        {
            if(Request == null)
            {
                return BadRequest(ModelState);
            }
            Student student=_mapper.Map<Student>(Request);
            _db.Students.Update(student);
            _db.SaveChanges();
            return Ok(student);
        }
    }
}

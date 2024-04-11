using AutoMapper;
using Crud.API.DTO.Student;
using Crud.DTO.Student;
using Crud.Model;

namespace Crud.AutoMapping
{
    public class CRUD_AutoMapper:Profile
    {
        public CRUD_AutoMapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
            CreateMap<UsersDTO, tblUsers>();
            CreateMap<UpdateUserDTO, tblUsers>();
        }
    }
}

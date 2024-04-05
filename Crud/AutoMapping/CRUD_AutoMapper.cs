using AutoMapper;
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
        }
    }
}

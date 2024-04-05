using AutoMapper;
using Crud.Data;
using Crud.DTO.Student;
using Crud.Interface;
using Crud.Model;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Repository
{
    public class User:IUser
    {
        IMapper _mapper;
        private readonly CrudDBContext _db;
        public User(IMapper mapper, CrudDBContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<tblUsers> Add(UsersDTO user)
        {
            tblUsers _newUser = _mapper.Map<tblUsers>(user);
            _db.Users.Add(_newUser);
            _db.SaveChanges();
            return _newUser;
        }
    }
}

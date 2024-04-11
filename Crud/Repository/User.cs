using AutoMapper;
using Crud.API.DTO;
using Crud.API.DTO.Student;
using Crud.Data;
using Crud.DTO.Student;
using Crud.Interface;
using Crud.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<tblUsers>> Get()
        {
            return await _db.Users.Where(user => user.Usr_isActive).ToListAsync();
        }

        public async Task<tblUsers>Edit(int Id)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Usr_isActive && user.Usr_Id == Id);
        }

        public async Task<tblUsers> Add(UsersDTO user)
        {
            tblUsers _newUser = _mapper.Map<tblUsers>(user);
            _db.Users.Add(_newUser);
            _db.SaveChanges();
            return _newUser;
        }

        public async Task<tblUsers> Update(UpdateUserDTO user)
        {
            tblUsers _newUser = _mapper.Map<tblUsers>(user);
            _db.Users.Update(_newUser);
            _db.SaveChanges();
            return _newUser;
        }

        public async Task<ResultDTO>Delete(int Id)
        {
            tblUsers _user=await _db.Users.FirstOrDefaultAsync(user=>user.Usr_Id == Id);
            _user.Usr_isActive=false;
            _db.Users.Update(_user);
            _db.SaveChanges();
            return new ResultDTO { Message = "USer was deleted...", Status = StatusCodes.Status200OK };
        }
    }
}

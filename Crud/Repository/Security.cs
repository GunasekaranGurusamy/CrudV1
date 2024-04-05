using Crud.Data;
using Crud.DTO.Security;
using Crud.Interface;
using Crud.Model;
using Microsoft.EntityFrameworkCore;

namespace Crud.Repository
{
    public class Security:ISecurity
    {
        private readonly CrudDBContext _db;
        public Security(CrudDBContext db)
        {
            this._db = db;
        }
        public async Task<tblUsers> Login(LoginRequestDTO request)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Usr_Name == request.UserName && user.Usr_Password == request.Password);
        }
    }
}

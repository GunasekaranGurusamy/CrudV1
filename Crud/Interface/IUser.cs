using Crud.DTO.Student;
using Crud.Model;

namespace Crud.Interface
{
    public interface IUser
    {
        Task<tblUsers> Add(UsersDTO user);
    }
}

using Crud.API.DTO;
using Crud.API.DTO.Student;
using Crud.DTO.Student;
using Crud.Model;

namespace Crud.Interface
{
    public interface IUser
    {
        Task<List<tblUsers>> Get();
        Task<tblUsers> Edit(int Id);
        Task<tblUsers> Add(UsersDTO user);
        Task<tblUsers> Update(UpdateUserDTO user);
        Task<ResultDTO> Delete(int Id);
    }
}

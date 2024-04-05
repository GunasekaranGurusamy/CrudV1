using Crud.DTO.Security;
using Crud.Model;
using Crud.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Interface
{
    public interface ISecurity
    {
        Task<tblUsers> Login(LoginRequestDTO request);
    }
}

using Crud.API.Model;
using Crud.Model;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class CrudDBContext:DbContext
    {
        public CrudDBContext(DbContextOptions<CrudDBContext>option):base(option)
        {
                
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<tblUsers> Users { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
        public DbSet<tblMasters> tblMasters { get; set; }
    }
}

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
    }
}

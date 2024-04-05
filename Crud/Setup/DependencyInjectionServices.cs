using Crud.AutoMapping;
using Crud.Data;
using Crud.Interface;
using Crud.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

namespace Crud.Setup;

public static class DependencyInjectionServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(CRUD_AutoMapper));
        builder.Services.AddDbContext<CrudDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
        
        builder.Services.AddTransient<ISecurity, Security>();
        builder.Services.AddTransient<IUser, User>();

        var _seriLog = new LoggerConfiguration()
            .MinimumLevel.Error()
            .MinimumLevel.Debug()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                   .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error)
                   .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
            .WriteTo.File("..\\log\\log-.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        builder.Logging.AddSerilog(_seriLog);

        return builder;
    }
}

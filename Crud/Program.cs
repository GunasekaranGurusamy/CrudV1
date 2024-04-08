using Crud.Setup;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .RegisterServices()
    .ConfigureAuthentication()
    .ConfigureSwagger()
    .Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CRUDCors");

app.Run();

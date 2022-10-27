using ControlApp.Application.Customer.Commands.CreateCustomer;
using ControlApp.Application.DataBase;
using ControlApp.Application.Goald.Commands.CreateGoald;
using ControlApp.Application.Goald.Queries.GetAllGoald;
using ControlApp.Application.Period.Queries.GetAllPeriod;
using ControlApp.Application.Product.Queries.GetAllProduct;
using ControlApp.Application.User.Queries.GetAllUser;
using ControlApp.Application.User.Queries.GetUserByCode;
using ControlApp.Application.User.Queries.GetUserByRole;
using ControlApp.Persistence.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<IGetAllUserQuery, GetAllUserQuery>();
builder.Services.AddScoped<IGetAllProductQuery, GetAllProductQuery>();
builder.Services.AddScoped<ICreateCustomerCommand, CreateCustomerCommand>();
builder.Services.AddScoped<ICreateGoaldCommand, CreateGoaldCommand>();
builder.Services.AddScoped<IGetAllPeriodQuery, GetAllPeriodQuery>();
builder.Services.AddScoped<IGetAllGoaldQuery, GetAllGoaldQuery>();
builder.Services.AddScoped<IGetUserByCodeQuery, GetUserByCodeQuery>();
builder.Services.AddScoped<IGetUserByRoleQuery, GetUserByRoleQuery>();

builder.Services.AddCors();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors(option =>
{
    option.WithOrigins("http://localhost:4200").AllowAnyMethod();
    option.AllowAnyHeader();
    option.AllowAnyMethod();
    option.AllowAnyOrigin();
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

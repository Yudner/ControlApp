using ControlApp.Application.Customer.Commands.CreateCustomer;
using ControlApp.Application.DataBase;
using ControlApp.Application.Product.Queries.GetAllProduct;
using ControlApp.Application.User.Queries.GetAllUser;
using ControlApp.Persistence.DataBase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<IGetAllUserQuery, GetAllUserQuery>();
builder.Services.AddScoped<IGetAllProductQuery, GetAllProductQuery>();
builder.Services.AddScoped<ICreateCustomerCommand, CreateCustomerCommand>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

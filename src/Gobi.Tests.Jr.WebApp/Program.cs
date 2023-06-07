using Gobi.Test.Jr.Application;
using Gobi.Test.Jr.Domain.Interfaces;
using Gobi.Test.Jr.Domain.Interfaces.Generics;
using Gobi.Test.Jr.Domain.Interfaces.Services;
using Gobi.Test.Jr.Infra;
using Gobi.Test.Jr.Infra.Data;
using Gobi.Test.Jr.Infra.Repositories;
using Gobi.Test.Jr.Infra.Repositories.Generics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
.Services
.AddControllersWithViews()
.AddRazorRuntimeCompilation();

builder.Services.AddDbContext<Context>();

//INTERFACE E REPOSITORIO
builder.Services.AddScoped(typeof(InterfaceGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

//SERVIÇO
builder.Services.AddScoped<ITodoItemService, TodoItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

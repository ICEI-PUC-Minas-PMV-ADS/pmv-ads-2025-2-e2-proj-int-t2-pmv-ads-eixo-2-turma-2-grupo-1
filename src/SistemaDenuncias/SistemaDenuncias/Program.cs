using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SistemaDenuncias.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao contêiner
builder.Services.AddControllersWithViews();

// Atualização em tempo real do Razor ('Tarefa implementada por Henrique Alves')
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Configuração do banco de dados SQL Server local ('Tarefa implementada por Henrique Alves')
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração de autenticação com Cookies ('Tarefa implementada por Henrique Alves')
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // ('Tarefa implementada por Henrique Alves')
        options.LoginPath = "/Usuario/Login";   // rota de login
        options.LogoutPath = "/Usuario/Logout"; // rota de logout
        options.ExpireTimeSpan = TimeSpan.FromHours(8); // duração do cookie
        options.AccessDeniedPath = "/Usuario/AcessoNegado"; // opcional (caso crie esta view futuramente)
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();

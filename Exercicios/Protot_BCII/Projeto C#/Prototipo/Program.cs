using Competicao.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Outros serviços
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurações adicionais...

// Configurar o pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())  // Caso não esteja no ambiente de desenvolvimento
{
    app.UseExceptionHandler("/Home/Error");  // Usar uma página de erro padrão.
    app.UseHsts();  // Ativa a Política de Segurança de Transporte Estrito HTTP (HSTS).
}

app.UseHttpsRedirection();  // Redireciona HTTP para HTTPS.
app.UseStaticFiles();  // Ativa o uso de arquivos estáticos (CSS, JS, imagens).

app.UseRouting();  // Ativa o roteamento.

app.UseAuthorization();  // Ativa a autorização (pode ser personalizado mais tarde).

// Mapeia as rotas dos controladores.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();  // Inicia o servidor web e aguarda as requisições.



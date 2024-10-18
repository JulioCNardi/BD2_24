var builder = WebApplication.CreateBuilder(args);


// Adicionar serviços ao contêiner de injeção de dependências (DI).
builder.Services.AddControllersWithViews();  // Ativa o MVC com suporte para controllers e views.

var app = builder.Build();  // Constrói a aplicação usando as configurações.

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



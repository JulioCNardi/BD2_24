using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Competicao.Data;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Conexão com o banco de dados
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Outros serviços
        services.AddControllersWithViews();
    }



    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Exibe páginas de erro detalhadas em desenvolvimento
        }
        else
        {
            app.UseExceptionHandler("/Home/Error"); // Página de erro para produção
            app.UseHsts(); // HSTS (HTTP Strict Transport Security)
        }

        app.UseHttpsRedirection(); // Redireciona HTTP para HTTPS
        app.UseStaticFiles(); // Habilita arquivos estáticos (CSS, JS, imagens)

        app.UseRouting(); // Habilita roteamento

        app.UseAuthorization(); // Habilita a autorização

        app.UseEndpoints(endpoints =>
        {
            // Define as rotas padrão
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Rota padrão para controlador e ação
        });
    }
}

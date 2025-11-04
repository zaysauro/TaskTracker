using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;

namespace TaskTracker
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlite("Data Source=tasks.db"));

            services.AddRazorPages()
                    .AddRazorRuntimeCompilation();

            services.AddControllers();
        }

        // injeta AppDbContext para garantir o banco
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext db)
        {
            db.Database.EnsureCreated(); // cria tasks.db se não existir

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}

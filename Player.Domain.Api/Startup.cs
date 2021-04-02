using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Player.Domain.Handlers;
using Player.Domain.Infra.Contexts;
using Player.Domain.Infra.Repositories;
using Player.Domain.Repositories;

namespace Player.Domain.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //injenção de depêndencia 
        {
            services.AddControllers();

           // services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database")); bom pra trabalhar em tempo de desenvolvimento
            services.AddDbContext<DataContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<PlayerHandler, PlayerHandler>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
            AddJwtBearer(options =>{
                options.Authority ="https://securetoken.google.com/playersapi-3b692";
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer ="https://securetoken.google.com/playersapi-3b692",
                    ValidateAudience = true,
                    ValidAudience ="playersapi-3b692",
                    ValidateLifetime = true
                    };
                }
            );
            
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().
            AllowAnyMethod().AllowAnyHeader());
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
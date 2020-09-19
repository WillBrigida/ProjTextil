using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PocIndustriaTextil.Core.Model;
using PocIndustriaTextil.Servidor.Repository;
using PocIndustriaTextil.Servidor.Utils;
using System.Text;

namespace PocIndustriaTextil.Servidor
{
    public class Startup
    {
        readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<Data.AppDbContext>(options => options
            //.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            .UseMySql(_configuration.GetConnectionString("DefaultConnection"), mySqlOptions => mySqlOptions
           .ServerVersion("10.2.11-mariadb")));

            //Identity
            services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>()
             .AddEntityFrameworkStores<Data.AppDbContext>()
             .AddDefaultTokenProviders();

            //Bearer
            services
                .AddAuthorization(auth =>
                {
                    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                                   .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                                   .RequireAuthenticatedUser().Build());
                });


            //.AddAuthentication("Bearer")
            //.AddJwtBearer("Bearer", options => options.SaveToken = true);

            //JWT
            var appSettinsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettinsSection);

            var appSettings = appSettinsSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(key),
                 ValidateIssuer = true,
                 ValidateAudience = true,
                 ValidAudience = appSettings.ValidoEm,
                 ValidIssuer = appSettings.Emissor
             });

            //Inject
            services.AddScoped<IAcessoRepository, AcessoRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}

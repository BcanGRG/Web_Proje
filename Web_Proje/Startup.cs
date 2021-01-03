using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web_Proje.Contexts;
using Web_Proje.Entities;
using Web_Proje.Interfaces;
using Web_Proje.Repositories;

namespace Web_Proje
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();

            // İstek yapıldığı zaman ilgili kişiye bir nesne döndürülmesini sağlıyor
            // Yapı constructor da Interface i gördüğü zaman class dan nesne döndürüyor. Dependecy Injection
            // Projeyi değiştireceğim zaman buradaki 2. kısmı değiştirmek yeterli Interface i görfüğü anda gideceği kısmı gösteriyor
            services.AddScoped<IKategoriRepository , KategoriRepository>();
            services.AddScoped<IUrunRepository , UrunRepository>();
            services.AddScoped<IUrunKategoriRepository , UrunKategoriRepository>();
            services.AddControllersWithViews();

            

            // Identity kısmını ekleyip yeni bir mıgration oluşturmak için gerekli kısımlar 
            services.AddIdentity<AppUser, IdentityRole>(opt=> {
                opt.Password.RequireDigit = false; // Sayı içermeli mi
                opt.Password.RequireLowercase = false; // Küçük harf içermeli mi
                opt.Password.RequiredLength = 3; // Gerekli uzunluk
                opt.Password.RequireUppercase = false; // Büyük harf
                opt.Password.RequireNonAlphanumeric = false; // Diğer karakterler
            }).AddEntityFrameworkStores<Context0>();
            services.AddDbContext<Context0>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Home/GirisYap");
                opt.Cookie.Name = "WebProje";
                opt.Cookie.HttpOnly = true; // Javascript tarafından çekilemez true iken
                opt.Cookie.SameSite = SameSiteMode.Strict; // Ayni domaini başka sitelerde de kullanabilmeyi kısıtlar Lax olsaydı izin verirdi
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Coooki nin tarayıcı da saklanma süresi
            });

            services.AddRazorPages()
        .AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
               

                app.UseDeveloperExceptionPage();
            }
            // Bir kereye mahsus admin i oluşturacak
            IdentityInitializer.AdminOlustur(userManager, roleManager);

            
            
            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication(); // Giriş yapılıp yapılamdığını kontrol eder
            app.UseAuthorization(); // Yetkiyi karşılama durumunu denetler

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern : "{controller=Home}/{action=Index}/{id?}"
                    );
              
            });
        }
    }
}

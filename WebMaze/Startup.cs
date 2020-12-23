using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebMazeKZ.DBStuff;
using Microsoft.EntityFrameworkCore;
using WebMazeKZ.DBStuff.Repository;
using AutoMapper;
using AutoMapper.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using WebMazeKZ.DBStuff.Model;
using WebMazeKZ.Models.Account;

namespace WebMaze
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=WebMazeKz;Trusted_Connection=True;";
            services.AddDbContext<WebMazeContext>(option => option.UseSqlServer(connectionString));

            RegistrationMapper(services);

            RegistrationRepository(services);

            services.AddControllersWithViews();
        }

        private void RegistrationMapper(IServiceCollection services)
        {
            var configurationExpression = new MapperConfigurationExpression();

            configurationExpression.CreateMap<CitizenUser, ProfileViewModel>();
            configurationExpression.CreateMap<ProfileViewModel, CitizenUser>();

            configurationExpression.CreateMap<CitizenUser, LoginViewModel>();
            // можно прописывать сложкую логику
            // configurationExpression.CreateMap<CitizenUser, LoginViewModel>()
            //  .ForMember(nameof(LoginViewModel.Login), opt => opt.MapFrom(x => x.AvatarUrl + x.Password));

            configurationExpression.CreateMap<LoginViewModel, CitizenUser>();

            var mapperConfiguration = new MapperConfiguration(configurationExpression);
            var mapper = new Mapper(mapperConfiguration);
            services.AddScoped<IMapper>(s => mapper);
        }

        private void RegistrationRepository(IServiceCollection services)
        {
            services.AddScoped<CitizenUserRepository>(serviceProvider =>
                new CitizenUserRepository(serviceProvider.GetService<WebMazeContext>()));

            /*
             * Аналогично:
             * 
             * services.AddScoped<CitizenUserRepository>(serviceProvider => 
             *  {
             *      var webContext = serviceProvider.GetService<WebMazeContext>();
             *      return new CitizenUserRepository(webContext);
             *  });
             * 
             */

            services.AddScoped(s => new AddressRepository(s.GetService<WebMazeContext>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QLNS.API.Application.DTOs.NhanVien;
using QLNS.API.Application.DTOs.User;
using QLNS.API.Application.Filters;
using QLNS.API.Application.Interfaces;
using QLNS.API.Application.Services;
using QLNS.API.Application.Validators;
using QLNS.Application.Mapping;
using QLNS.Domain.Repositories;
using QLNS.Infrastructure.Context;
using QLNS.Infrastructure.Repositories;

namespace QLNS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            //DbContext setting
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QLNS")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<INhanVienRepository, NhanVienRepository>();
            services.AddScoped<INhanVienService, NhanVienService>();

            services.AddScoped<IQueQuanRepository, QueQuanRepository>();
            services.AddScoped<IQueQuanService, QueQuanService>();

            services.AddScoped<IPhongBanRepository, PhongBanRepository>();
            services.AddScoped<IPhongBanService, PhongBanService>();

            services.AddScoped<IChucVuRepository, ChucVuRepository>();
            services.AddScoped<IChucVuService, ChucVuService>();

            services.AddScoped<IHopDongLaoDongRepository, HopDongLaoDongRepository>();
            services.AddScoped<IHopDongLaoDongService, HopDongLaoDongService>();

            // AutoMapper settings
            services.AddAutoMapper(typeof(MappingProfile));

            //WebApi Configuration
            services
                .AddControllers( ops =>
                    {
                        ops.EnableEndpointRouting = false;
                        ops.Filters.Add<ValidationFilter>();
                    })
                .AddNewtonsoftJson(ops =>
                {
                    //ops.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    ops.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation( fv =>
                    {
                        fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                        fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                    }); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QLNS.API", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QLNS.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

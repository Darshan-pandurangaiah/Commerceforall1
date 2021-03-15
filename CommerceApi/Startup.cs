using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer;


namespace CommerceApi
{
    public class Startup
    {
        IMapper iMapper;

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://farmtesting.stackblitz.io",
                                          "http://farmtesting.stackblitz.io", "http://localhost:51202")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials();
                                  });
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, Models.Product>();
                cfg.CreateMap<Role, Models.Role>();
                cfg.CreateMap<User, Models.User>();
                cfg.CreateMap<Category , Models.Category>();
                cfg.CreateMap<Orderdetail, Models.Orderdetail>();
            });
            iMapper = config.CreateMapper();
            services.AddSingleton(iMapper); 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddNewtonsoftJson();
        }
        //public void ConfigureService(IServiceCollection services)
        //{
        //    var mappingconfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
        //    IMapper mapper = mappingconfig.CreateMapper();
        //    services.AddSingleton(mapper);
        //    //services.AddSingleton<EFCore_DataAccessLayer>(new EFCore_DataAccessLayer(new DataContext ))

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class MappingProfile : Profile
    { 
        public MappingProfile()
        {
            CreateMap<Product, Models.Product>();
        }
    }
}

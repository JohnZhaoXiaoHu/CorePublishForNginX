using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePublishForNginX.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CorePublishForNginX
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
            services.AddControllers();
            services.AddTransient<IKiba, Kiba>(); //依赖注入 每一次都会创建一个新的实例。
            services.AddTransient<IKiba2, Kiba2>(); //依赖注入
            /*services.AddScoped<IKiba, Kiba>(); //依赖注入 在同一个Scope内只初始化一个实例
            services.AddSingleton<IKiba, Kiba>(); //依赖注入 整个应用程序生命周期以内只创建一个实例，相当于一个静态类。*/
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
                app.UseHsts();
                app.UseHttpsRedirection();
            } 

            app.UseRouting(); 
         
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

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
            services.AddTransient<IKiba, Kiba>(); //����ע�� ÿһ�ζ��ᴴ��һ���µ�ʵ����
            services.AddTransient<IKiba2, Kiba2>(); //����ע��
            /*services.AddScoped<IKiba, Kiba>(); //����ע�� ��ͬһ��Scope��ֻ��ʼ��һ��ʵ��
            services.AddSingleton<IKiba, Kiba>(); //����ע�� ����Ӧ�ó���������������ֻ����һ��ʵ�����൱��һ����̬�ࡣ*/
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

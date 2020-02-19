using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CorePublishForNginX
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                 webBuilder =>
                 {
                     //������Ŀ�������ļ�
                     webBuilder.UseStartup<Startup>();
                     //Kestrel��Ĭ�ϼ����˿���http5000��https5001�� 
                     webBuilder.ConfigureKestrel(options =>
                     {
                         options.ListenAnyIP(5180);//������������ip��5180�˿ڣ��൱������ip0.0.0.0
                                                   //options.Listen(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5180));//����ָ��ip��ָ���˿�
                     }); ;
                 });
        }
    }
}

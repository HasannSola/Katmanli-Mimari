using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAP.BLL.Abstract;
using LAP.BLL.Concrete;
using LAP.DAL.Concrete;
using LAP.DAL.Redis;
using LAP.ENTITIES;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LAP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDistributedRedisCache(options =>
            //{
            //    options.InstanceName = "Blog";
            //    options.Configuration = "127.0.0.1";
            //    //options.Configuration = "localhost";             
            //});
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "127.0.0.1:6379";//"localhost";
                option.InstanceName = "mks";
            });
            services.AddSession(options =>
            {
                // 10 dakikalı Redis Timeout Süresi.
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.CookieHttpOnly = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<ICustomerManager>(c => new CustomerManager(new Repository<Customer>()));
            services.AddSingleton<IRedisContext<Customer>>(c => new RedisContext<Customer>());

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseMvc();
        }
    }
}

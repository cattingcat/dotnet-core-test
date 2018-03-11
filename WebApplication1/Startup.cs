using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApplication1.Infrastructure;

namespace WebApplication1
{
    
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvcCore();
            builder.AddJsonFormatters();
            //services.AddMvc();

            services.AddSingleton<MiddlewareInterfaceTest>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
            app.UseMiddleware<MiddlewareTest>();
            app.UseMiddleware<MiddlewareInterfaceTest>();
            app.UseMvc();
            
        }
    }
}
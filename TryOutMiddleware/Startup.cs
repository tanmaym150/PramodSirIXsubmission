using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryOutMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\nhello from 1st middleware ");//hello from 1st middleware
                await next();
                await context.Response.WriteAsync("\nhello again from 1st middleware");
            });
            app.Use(async (context, next) =>
            {

                await context.Response.WriteAsync("\nhello from 2nd middleware ");//hello from 2nd middleware
                await next();
            });
            app.Use(async (context, next) =>
            {

                await context.Response.WriteAsync("\nhello from 3nd middleware ");//hello from 2nd middleware
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("\nhello from 1st middleware ");//hello from 1st middleware

                await context.Response.WriteAsync("\nhello again from 1st middleware");//hello again from 1st middleware
            });
            app.Run(async (context) =>
            {

                await context.Response.WriteAsync("\nhello from 2nd middleware ");//will not get call.
                
            });
           



            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //       // await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}

//TRY1:
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("\nhello from 1st middleware ");//hello from 1st middleware

//    await context.Response.WriteAsync("\nhello again from 1st middleware");//hello again from 1st middleware
//});
//app.Run(async (context) =>
//{

//    await context.Response.WriteAsync("\nhello from 2nd middleware ");//will not get call.

//});
//OUTPUT :hello from 1st middleware
//hello again from 1st middleware
//do not gets call to the 2nd run method

//TRY2
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("\nhello from 1st middleware ");//hello from 1st middleware
//    await context.Response.WriteAsync("\nhello again from 1st middleware");
//});
//OUTPUT:
//hello from 1st middleware
//hello again from 1st middleware

//TRY3
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("\nhello from 1st middleware ");//hello from 1st middleware
//    await next();
//    await context.Response.WriteAsync("\nhello again from 1st middleware");
//});
//app.Use(async (context, next) =>
//{

//    await context.Response.WriteAsync("\nhello from 2nd middleware ");//hello from 2nd middleware
//    await next();
//});
//app.Use(async (context, next) =>
//{

//    await context.Response.WriteAsync("\nhello from 3nd middleware ");//hello from 2nd middleware
//    await next();
//});
//OUTPUT:
//hello from 1st middleware
//hello from 2nd middleware
//hello from 3rd middleware
//hello again from 1st middleware
//
//TRY4
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("\nhello from 1st middleware ");//hello from 1st middleware
//    await next();
//    await context.Response.WriteAsync("\nhello again from 1st middleware");
//});
//app.Use(async (context, next) =>
//{

//    await context.Response.WriteAsync("\nhello from 2nd middleware ");//hello from 2nd middleware
//    await next();
//});
//app.Use(async (context, next) =>
//{

//    await context.Response.WriteAsync("\nhello from 3nd middleware ");//hello from 2nd middleware
//    await next();
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("\nhello from 1st middleware ");//hello from 1st middleware

//    await context.Response.WriteAsync("\nhello again from 1st middleware");//hello again from 1st middleware
//});
//OUTPUT:
//hello from 1st middleware 
//hello from 2nd middleware 
//hello from 3nd middleware 
//hello from 1st middleware 
//hello again from 1st middleware
//hello again from 1st middleware

//TRY5
//webBuilder.UseStartup<Startup>();
//app.UseStaticFiles();
//OUTPUT:
//image gets displayed from the default folder wwwroot i.e n2.jpeg  https://localhost:44391/n2.jpeg

//TRY6
// webBuilder.UseStartup<Startup>().UseWebRoot("mystaticfiles");
//OUTPUT:
//n3.jpeg from the folder mystaticfiles gets called https://localhost:44391/n3.jpeg




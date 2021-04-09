using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces;
using MISA.Core.Services;
using MISA.Infrastructure.Repository;
using Newtonsoft.Json;

namespace MISA.CukCuk.Api
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
            services.AddCors();
            services.AddControllers();

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerGroupRepository, CustomerGroupRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //CORS
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetPreflightMaxAge(TimeSpan.FromMinutes(10)));

            // Xử lý Exception
            //app.UseExceptionHandler(c => c.Run(async context =>
            //{
            //    var exception = context.Features
            //        .Get<IExceptionHandlerPathFeature>()
            //        .Error;

            //    if (exception is ValidateExceptions)
            //    {
            //        var responseBadRequest = new
            //        {
            //            devMsg = exception.Message,
            //            userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp!",
            //            errorCode = "misa-400",
            //            moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
            //            traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
            //        };
            //        context.Response.StatusCode = StatusCodes.Status400BadRequest;

            //    string responseBadRequestConvert = JsonConvert.SerializeObject(responseBadRequest);
            //        await context.Response.WriteAsync(responseBadRequestConvert);
            //    }

            //    var response = new
            //    {
            //        devMsg = exception.Message,
            //        userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp!",
            //        errorCode = "misa-005",
            //        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
            //        traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
            //    };

            //    string responseConvert = JsonConvert.SerializeObject(response);
            //    await context.Response.WriteAsync(responseConvert);
            //}));

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

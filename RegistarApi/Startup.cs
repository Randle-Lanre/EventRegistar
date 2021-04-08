using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using RegistarApi.Model;


namespace RegistarApi
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
          //  services.AddDbContext<ApplicationDbContext>(dbToUse => dbToUse.UseSqlServer(Configuration.GetConnectionString("EventRegistarDbContext")));
          services.AddDbContext<ApplicationDbContext>(db =>
              db.UseSqlServer(Configuration.GetConnectionString("EventRegistarDbContext")));
            
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://www.localhost:4200").AllowAnyHeader()
                            .WithMethods("GET", "POST", "DELETE", "PUT");
                    }
                    );
            }
                
               );
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:5001";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api11");
                });

            });
            

            services.AddAntiforgery(options =>
            {

                options.HeaderName = null; //consider only form data 
                options.SuppressXFrameOptionsHeader = false;

            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RegistarApi", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RegistarApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
           

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //setting up policy for all API endpoints 
                endpoints.MapControllers().RequireAuthorization("ApiScope");
            });
        }
    }
}

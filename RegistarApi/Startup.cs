using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Microsoft.AspNetCore.Authorization;

using RegistarApi.Model;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RegistarApi.Entities;
using RegistarApi.Helpers;

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

          services.AddCors();
          
            
            
            // services.AddCors(options =>
            // {
            //    // options.DefaultPolicyName = "ApiPolicy";
            //     
            //     options.AddPolicy("ApiPolicy",
            //
            //
            //
            //         builder =>
            //         {
            //             builder.WithOrigins("http://localhost:4200", "http://www.localhost:4200").AllowAnyHeader()
            //                 .WithMethods("GET", "POST", "DELETE", "PUT");
            //             
            //         }
            //         );
            // }
            //     
            //    );
            // services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme).AddIdentityServerAuthentication(
            //
            //     options =>
            //     {
            //         options.Authority = "https://localhost:5001";
            //         options.ApiName = "RegistarApi";
            //         options.ApiSecret = "secret";
            //     }
            //     );
            //services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            //{
                
            //    options.Authority = "https://localhost:5001";
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = false
            //    };
            //});

            //services.AddAuthorization(options =>
            //{
              
            //    options.AddPolicy("ApiPolicy",  policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.RequireClaim("scope", "api11");
                    
                   
            //    });

            //});
            
            //strongly typed app settings 
            var appSettingsSection = Configuration.GetSection("AppSettings");
            
            //jwt config
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                };
            });
            

            services.AddAntiforgery(options =>
            {

                options.HeaderName = null; //consider only form data 
                options.SuppressXFrameOptionsHeader = false;

            });

            services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.IgnoreNullValues=true);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RegistarApi", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            //TODO: remove context in prod env and test user account, also harsh passwords 
            context.Users.Add(new User { FirstName = "Test", LastName = "User", Username = "test", Password = "test" });
            context.SaveChanges();
            

          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RegistarApi v1"));
            }

           

            app.UseRouting();
            app.UseCors(x => x.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            // app.UseCors("ApiPolicy");
            // app.UseHttpsRedirection();
            // app.UseAuthentication();
            


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //setting up policy for all API endpoints 
                endpoints.MapControllers();
            });
        }
    }
}

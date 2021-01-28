using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIMDb
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
            //services.AddDbContext<dbContext>(options => options
            //                                     .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            //                                     );


            // Config-Swagger
            services.AddSwaggerGen();

            //Jwt for requests Validations
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                                    options.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = false,
                                        ValidateAudience = false,
                                        ValidateLifetime = true,
                                        ValidateIssuerSigningKey = true,
                                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["CtsAcs:scKey"])),
                                        ClockSkew = TimeSpan.Zero
                                    }
                                 );


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("https://localhost:64582");
                builder.AllowAnyHeader();
                builder.WithExposedHeaders("Token-Expired");
                builder.AllowAnyMethod();
                builder.AllowCredentials();
                builder.Build();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMDb Rest API V1");
                //  c.RoutePrefix = string.Empty;
            });

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

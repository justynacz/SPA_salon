using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SPA.Server.Models;
using SPA.Server.Services;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPA.API
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
            var key = Encoding.ASCII.GetBytes("Some secret key for authentication");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var loginService = context.HttpContext.RequestServices.GetRequiredService<ILoginService>();
                        var loginId = int.Parse(context.Principal.Identity.Name);
                        var login = loginService.GetLoginAsync(loginId).Result;
                        if (login == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<SPAContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("database")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SPA API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IGlobalTermService, GlobalTermService>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<ITermService, TermService>();
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration["AppSettings:VirtualDirectory"] + "/swagger/v1/swagger.json", "SPA SALOON API");
            });
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}

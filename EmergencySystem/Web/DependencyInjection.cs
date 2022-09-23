using Domain.Entities.AppUSerModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Service;
using Service.Mapping;
using Service.Services.Interfaces;
using System;
using System.Reflection;
using System.Text;
using Web.Services.CurrentUserService;
using Web.Services.FileService;

namespace Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebLayer(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ICurrentUserService, CurrentUser>();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {

            });
            services.AddSwaggerGen(opt =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { In = ParameterLocation.Header, Description = "Please insert JWT with Bearer into field", Name = "Authorization", Scheme = "bearer", BearerFormat = "JWT", Type = SecuritySchemeType.ApiKey });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, Array.Empty<string>() } });


            });


            services.AddControllers();


            services.AddEndpointsApiExplorer();


            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

        public static void AddAuth(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentity<AppUser, IdentityRole>(
                options =>
                {
                    options.Stores.MaxLengthForKeys = 128;
                    options.User.RequireUniqueEmail = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            var tk = Configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tk));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt =>
                    {
                        opt.RequireHttpsMetadata = false;
                        opt.SaveToken = true;
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = key,
                            ValidateAudience = false,
                            ValidateIssuer = false,
                        };
                    });

            services.ConfigureApplicationCookie(
                      options =>
                      {

                          options.Cookie.Name = "User";
                          options.LoginPath = new PathString("/admin/Account/Login");
                          options.AccessDeniedPath = new PathString("/admin/Account/AccessDenied");
                      });
        }
    }
}

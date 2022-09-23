using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Service;
using System.Text;
using Web;
using Web.Exceptions;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddServiceLayer()
    .AddDomainLayer(builder.Configuration)
    .AddWebLayer().AddAuth(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());


app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

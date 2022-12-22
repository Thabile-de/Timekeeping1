
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TimeKeeping1.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TimeKeeping1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TimeKeeping1Context") ?? throw new InvalidOperationException("Connection string 'TimeKeeping1Context' not found.")));

builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3000")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
           .WithMethods("GET", "POST", "DELETE", "PUT")
           .AllowAnyHeader()
           .AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 
    

app.Run();

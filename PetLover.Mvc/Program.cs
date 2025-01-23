using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetLover.Bl.Dtos;
using PetLover.Bl.Profiles;
using PetLover.Bl.Services.Abstraction;
using PetLover.Bl.Services.Implementation;
using PetLover.Core;
using PetLover.Data.Context;
using PetLover.Data.Repositories.Implementation;
using PetLover.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Acer"));

});
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
  
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddAutoMapper(typeof(MemberProfile));
builder.Services.AddAutoMapper(typeof(AppUserProfile));
builder.Services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<CreateMemberValidator>());
builder.Services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<UpdateMemberValidator>());
builder.Services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<CreateAppUserValidator>());
builder.Services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<LoginUserValidator>());
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Member}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

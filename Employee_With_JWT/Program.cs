using Employee_With_JWT.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string cs = builder.Configuration.GetConnectionString("conStr");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(cs, b => b.MigrationsAssembly("Employee_With_JWT")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//****
builder.Services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
builder.Services.AddTransient<UserManager<ApplicationUser>, ApplicationUserManager>();
builder.Services.AddTransient<SignInManager<ApplicationUser>, ApplicationSignInManager>();
builder.Services.AddTransient<RoleManager<ApplicationRole>, ApplicationRoleManager>();
builder.Services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
//builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddUserStore<ApplicationUserStore>()
.AddUserManager<ApplicationUserManager>()
.AddRoleManager<ApplicationRoleManager>()
.AddSignInManager<ApplicationSignInManager>()
.AddRoleStore<ApplicationRoleStore>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<ApplicationRoleStore>();
builder.Services.AddScoped<ApplicationUserStore>();
//****


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

/*IServiceScopeFactory serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (IServiceScope scope=serviceScopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    //Role
    if(! await roleManager.RoleExistsAsync("Admin"))
    {
        var role = new ApplicationRole();
        role.Name = "Admin";
        await roleManager.CreateAsync(role);
    }
    if(! await roleManager.RoleExistsAsync("Employee"))
    {
        var role = new ApplicationRole();
        role.Name = "Employee";
        await roleManager.CreateAsync(role);
    }

    //user
    if(await userManager.FindByNameAsync("admin") == null)
    {
        var user = new ApplicationUser();
        user.UserName = "admin";
        user.Email = "admin@gmail.com";
        var cheackUser = await userManager.CreateAsync(user, "Admin123#");
        if (cheackUser.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
    if(await userManager.FindByNameAsync("employee") == null)
    {
        var user = new ApplicationUser();
        user.UserName = "employee";
        user.Email = "employee@gmail.com";
        var cheackUser = await userManager.CreateAsync(user, "Admin123#");
        if (cheackUser.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Employee");
        }
    }


}*/


    app.MapControllers();

app.Run();

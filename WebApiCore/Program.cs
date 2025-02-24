
// app.UseHttpsRedirection();



using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using WebApiCore;
using Database;
using Database.Lib.Interfaces;
using Database.Lib.Repositories;

using Common.Interfaces;
using Common.Repositories;
using UserAdmin.Interfaces;
using UserAdmin.Repositories;
using Masters.Interfaces;
using Masters.Repositories;
using Accounts.Interfaces;
using Accounts.Repositories;

using TnT.Interfaces;
using TnT.Repositories;
using Marketing.Interfaces;
using Marketing.Repositories;
using AirExport.Interfaces;



//Program.cs version 6.0


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); //new
builder.Services.AddSwaggerGen();  //new

builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDbConnection"));
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Other Services

// Common
builder.Services.AddScoped<ITableRepository, TableRepository>();

//User Admin
builder.Services.AddSingleton<IHeaderRepository, HeaderRepository>();
builder.Services.AddScoped<ITokenHandler, UserAdmin.Repositories.TokenHandler>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IAuditLog, AuditLog>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IRightsRepository, RightsRepository>();
builder.Services.AddScoped<ISettingsRepository, SettingsRepository>();
builder.Services.AddScoped<IMailServermRepository, MailServermRepository>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();

//Masters
builder.Services.AddScoped<IParamRepository, ParamRepository>();
builder.Services.AddScoped<ICustomermRepository, CustomermRepository>();
builder.Services.AddScoped<IRemarkmRepository, RemarkmRepository>();
builder.Services.AddScoped<IWiretransmRepository, WiretransmRepository>();

//Marketing

builder.Services.AddScoped<IQtnmFclRepository, QtnmFclRepository>();
builder.Services.AddScoped<IQtnmLclRepository, QtnmLclRepository>();
builder.Services.AddScoped<IQtnmAirRepository, QtnmAirRepository>();


//Accounts
builder.Services.AddScoped<IAccGroupRepository, AccGroupRepository>();
builder.Services.AddScoped<IAcctmRepository, AcctmRepository>();

//Tnt
builder.Services.AddScoped<IAirExportRepository, AirExportRepository>();

//AirExport
builder.Services.AddScoped<ITrackingRepository, TrackingRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    });


builder.Services.AddCors();

var app = builder.Build();


if (app.Environment.IsDevelopment()) // New
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CustomHeaderMiddleware>();

app.MapControllers();

app.Run();

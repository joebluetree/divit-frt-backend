
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

using SeaExport.Interfaces;
using SeaExport.Repositories;
using SeaImport.Interfaces;
using SeaImport.Repositories;

using AirExport.Interfaces;
using AirExport.Repositories;
using AirImport.Interfaces;
using AirImport.Repositories;
using CommonShipment.Interfaces;
using CommonShipment.Repositories;
using OtherOp.Interfaces;
using OtherOp.Repositories;
using Cargo.Interfaces;




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
builder.Services.AddScoped<ICommonProcessRepository, CommonProcessRepository>();

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
builder.Services.AddScoped<IFileUploadmRepository, FileUploadmRepository>();
builder.Services.AddScoped<IGenRemarkmRepository, GenRemarkmRepository>();

//Masters
builder.Services.AddScoped<IParamRepository, ParamRepository>();
builder.Services.AddScoped<ICustomermRepository, CustomermRepository>();
builder.Services.AddScoped<IRemarkmRepository, RemarkmRepository>();
builder.Services.AddScoped<IWiretransmRepository, WiretransmRepository>();

//Marketing

builder.Services.AddScoped<IQtnmFclRepository, QtnmFclRepository>();
builder.Services.AddScoped<IQtnmLclRepository, QtnmLclRepository>();
builder.Services.AddScoped<IQtnmAirRepository, QtnmAirRepository>();

//Cargo
builder.Services.AddScoped<ISeaExportmRepository, SeaExportmRepository>();
builder.Services.AddScoped<ISeaExporthRepository, SeaExporthRepository>();
builder.Services.AddScoped<ICargoCooRepository, CargoCooRepository>();

//SeaImport
builder.Services.AddScoped<ISeaImportmRepository, SeaImportmRepository>();
builder.Services.AddScoped<ISeaImporthRepository, SeaImporthRepository>();

//Accounts
builder.Services.AddScoped<IAccGroupRepository, AccGroupRepository>();
builder.Services.AddScoped<IAcctmRepository, AcctmRepository>();

//AirExport
builder.Services.AddScoped<IAirExportRepository, AirExportRepository>();
builder.Services.AddScoped<IAirExportHRepository, AirExportHRepository>();

//AirImport
builder.Services.AddScoped<IAirImportRepository, AirImportRepository>();
builder.Services.AddScoped<IAirImportHRepository, AirImportHRepository>();

//Other
builder.Services.AddScoped<IOtherOpRepository, OtherOpRepository>();

//CommonShipment
builder.Services.AddScoped<IFollowUpRepository, FollowUpRepository>();
builder.Services.AddScoped<IMemoRepository, MemoRepository>();
builder.Services.AddScoped<IDeliveryOrderRepository, DeliveryOrderRepository>();
builder.Services.AddScoped<IMessengerSlipRepository, MessengerSlipRepository>();
builder.Services.AddScoped<IDevanInstRepository, DevanInstRepository>();
builder.Services.AddScoped<ICustomHoldRepository, CustomHoldRepository>();




//Tnt
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

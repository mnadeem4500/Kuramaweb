using ExtremeClassified.Core;
using ExtremeClassified.WebApi.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ExtremeClassified.WebApi.Services;
using ExtremeClassified.WebApi.Utils;
using Microsoft.AspNetCore.Identity;
using ExtremeClassified.DataAccess;
using Microsoft.EntityFrameworkCore;
using ExtremeClassified.WebApi.Functions;
using ExtremeClassified.WebApi.Functions.Identity;
using ExtremeClassified.WebApi.Functions.Listing;
using ExtremeClassified.WebApi.Functions.Portal;
using Microsoft.AspNetCore.Http.Features;

const string ConName = "LocalConnection";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILoggerProvider, PortalLoggerProvider>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddCors(c =>
{
    c.AddPolicy("_myAllowAllOrigins", opt =>
    {
        opt.AllowAnyOrigin();
        opt.AllowAnyMethod();
        opt.AllowAnyHeader();
    });
});

//Below Code is only for migration
builder.Services.AddDbContext<PortalDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString(ConName));
});

Action<ApplicationSettings> appSettings = (x =>
{
    x.ConnectionString = builder.Configuration.GetConnectionString(ConName);
});
builder.Services.Configure<ApplicationSettings>(appSettings);


Action<PortalLoggerOptions> loggerSettings = (x =>
{
    x.FilePath = builder.Configuration.GetSection("Logging").GetSection("PortalLogger").GetSection("Options")["FilePath"];
    x.FolderPath = builder.Configuration.GetSection("Logging").GetSection("PortalLogger").GetSection("Options")["FolderPath"];
});
builder.Services.Configure<PortalLoggerOptions>(loggerSettings);

//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        };
    });

builder.Services.AddSingleton<AuthenticationManager>();
builder.Services.AddSingleton<ActiveDirectoryAuthentication>();

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.ValueCountLimit = 30;
    options.MultipartBodyLengthLimit = int.MaxValue; // if don't set 
    //default value is: 128 MB
    options.MultipartHeadersLengthLimit = int.MaxValue;
    options.BufferBodyLengthLimit = int.MaxValue;
});

#region Functions
//Identity

builder.Services.AddSingleton<GroupFunctions>();
builder.Services.AddSingleton<RoleFunction>();
builder.Services.AddSingleton<UserAccessFunction>();
builder.Services.AddSingleton<UserActivityFunction>();
builder.Services.AddSingleton<UserAddressFunction>();
builder.Services.AddSingleton<UserDeviceFunction>();
builder.Services.AddSingleton<UserGroupFunction>();
builder.Services.AddSingleton<UserPwdHistoryFunction>();
builder.Services.AddSingleton<UserRegionFuncion>();
builder.Services.AddSingleton<UserTokenFunction>();

//#Listing
builder.Services.AddSingleton<CategoryFunction>();
builder.Services.AddSingleton<CategoryPropertyFunction>();
builder.Services.AddSingleton<ListingAlertFunction>();
builder.Services.AddSingleton<ListingAttachmentFuntion>();
builder.Services.AddSingleton<ListingFavoriteFunction>();
builder.Services.AddSingleton<ListingFunction>();
builder.Services.AddSingleton<ListingPropertyFunction>();
builder.Services.AddSingleton<ListingVersionFunctions>();

// Portal
builder.Services.AddSingleton<UserFunctions>();
builder.Services.AddSingleton<CatalogueFunctions>();
builder.Services.AddSingleton<PortalFunction>();
builder.Services.AddSingleton<UserRegionFuncion>();
builder.Services.AddSingleton <ScreenControlFunction>();
#endregion

// Password Hashing configuration
builder.Services.Configure<PasswordHasherOptions>(o =>
{
    o.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
    o.IterationCount = 1;
});
builder.Services.AddSingleton<AvPasswordHasher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseCors("_myAllowAllOrigins");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseStaticFiles();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();

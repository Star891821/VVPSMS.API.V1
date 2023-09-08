using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using VVPSMS.Api.Models.ModelsDto;
using VVPSMS.API.AutoMapper;
using VVPSMS.Domain.Models;
using VVPSMS.Service.Business;
using VVPSMS.Service.DataManagers;
using VVPSMS.Service.DataManagers.AdmissionDataManagers;
using VVPSMS.Service.DataManagers.MasterDataManagers;
using VVPSMS.Service.DataManagers.ParentDataManagers;
using VVPSMS.Service.DataManagers.StudentDataManagers;
using VVPSMS.Service.DataManagers.TeacherDataManagers;
using VVPSMS.Service.Repository;
using VVPSMS.Service.Repository.Admissions;
using VVPSMS.Service.Repository.Parents;
using VVPSMS.Service.Repository.Students;
using VVPSMS.Service.Repository.Teachers;
using VVPSMS.Service.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//JWT Tocken region

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// End region

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<VvpsmsdbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("VVPSMS")));
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddScoped<IAdmissionUnitOfWork, AdmissionUnitOfWork>();
builder.Services.AddScoped<IStudentUnitOfWork, StudentUnitOfWork>();
builder.Services.AddScoped<ITeacherUnitOfWork, TeacherUnitOfWork>();
builder.Services.AddScoped<IParentUnitOfWork, ParentUnitOfWork>();
builder.Services.AddTransient<IGenericService<MstSchoolGradeDto>, MstSchoolGradeService>();
builder.Services.AddTransient<IGenericService<MstSchoolDto>, MstSchoolService>();
builder.Services.AddTransient<IGenericService<MstClassDto>, MstClassService>();
builder.Services.AddTransient<IGenericService<MstAcademicYearDto>, MstAcademicYearService>();
builder.Services.AddTransient<IGenericService<MstSchoolStreamDto>, MstSchoolStreamService>();
builder.Services.AddTransient<IGenericService<MstUserRoleDto>, MstUserRoleService>();
builder.Services.AddTransient<IGenericService<MstUserDto>, UserService>();
builder.Services.AddTransient<IExternalLoginAppService,ExternalLoginAppService>();
builder.Services.AddTransient<IJwtAuthManager,JwtAuthManager>();
builder.Services.AddTransient<IStorageService, StorageService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var mappingConfiguration = new MapperConfiguration(config => config.AddProfile(new AutoMapperProfile()));
IMapper mapper = mappingConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder =>
    {
        builder.WithOrigins("https://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});
var prodCorsPolicy = "prodCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder =>
    {
        builder.WithOrigins("https://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(devCorsPolicy);
    app.UseSwagger();
    app.UseSwaggerUI();
}
else if (app.Environment.IsProduction())
{
    app.UseCors(prodCorsPolicy);
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;
app.MapControllers();
app.Run();

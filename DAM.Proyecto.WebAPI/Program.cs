using AutoMapper;
using DAM.Proyecto.SL.Automapping;
using DAM.Proyecto.SL.Services;
using DAM.Proyecto.WebAPI.Config;
using DAM.Proyecto.WebAPI.DAL;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IRepositories;
using DAM.Proyecto.WebAPI.DAL.Interfaces.IServiceProvider;
using DAM.Proyecto.WebAPI.DAL.Repositories;
using DAM.Proyecto.WebAPI.DAL.ServiceProvider;
using DAM.Proyecto.WebAPI.SL.Interfaces;
using DAM.Proyecto.WebAPI.SL.Interfaces.IHelpers;
using DAM.Proyecto.WebAPI.SL.Services;

using Microsoft.AspNetCore.Mvc;

using DAM.Proyecto.WebAPI.SL.Services.Helpers;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAM.Proyecto.WebAPI.Domain.Entities.DB;

// -------------------------------------------------------------------------------------------------------
// ------------------------------------   Contenedor de Dependencias  ------------------------------------
// -------------------------------------------------------------------------------------------------------

var builder = WebApplication.CreateBuilder(args);

// Agregar los servicios al contenedor.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();

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
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()


    //==================================================
    //                SQL config
    //--------------------------------------------------

    //Carol Alef - Praga
    //.AddDbContext<DamDbContext>(options => options.UseSqlServer(@"Data source=sql.develop.local;initial catalog=Alef_AppXite_Carolina;integrated security=false;persist security info=false;User ID=dam_user;Password=dam_user"))
    //.AddDbContext<DamDbContext>(options => options.UseSqlServer(@"Data Source = (localdb)\ProjectModels; Initial Catalog = DAM.Proyecto; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))

    // Birt
    //.AddDbContext<DamDbContext>(options => options.UseSqlServer(@"Data Source = 10.2.84.34:8084\BBDD;initial catalog=DAM; Integrated Security = True; Encrypt = False"))
    .AddDbContext<DamDbContext>(options => options.UseSqlServer(@"Data Source = 10.2.84.34\BBDD;initial catalog=DAM; Integrated Security=False; Encrypt=False; User ID=cmendez; Password=cmendez"))
    // ================================================
    //              InMemoryDatabase
    //-------------------------------------------------


    //.AddDbContext<DamDbContext>(options => options.UseInMemoryDatabase(@"InMemoryConnection"))

    //.AddDbContext<DamDbContext>(options => options.UseSqlServer(@"Data Source = WIN-E417NEMCOJG\BBDD;Initial Catalog=DAM; Integrated Security = false; User ID=cmendez ;Password=cmendez; Encrypt = False"))
    //.AddDbContext<DamDbContext>(options => options.UseInMemoryDatabase(@"InMemoryConnection"))
    //.AddDbContext<DamDbContext>(options => options.UseSqlServer(@"Data Source = 10.2.84.34\BBDD;Initial Catalog=DAM; Integrated Security = false; User ID=cmendez ;Password=cmendez; Encrypt = False"))


    // DAM.Proyecto.WebAPI.DAL
    .AddScoped<INotificacionProvider, NotificationProvider>()
    .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
    .AddTransient<IUnitOfWork, UnitOfWork>()
    .AddTransient<DamDbContext>()

// DAM.Proyecto.SL
    .AddScoped<IEnviarEmailService, EnviarEmailService>()
    .AddScoped<ILoginService, LoginService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IReservaService, ReservaService>()
    .AddScoped<IFavoritosService, FavoritosService>()
    .AddScoped<ILoginService, LoginService>()
    //.AddScoped<IJwtAuthenticationService, JwtAuthenticationService>()

    //CORS
    .AddCors(options =>
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
            policy =>
            {
                policy
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .SetIsOriginAllowed(origin => new Uri(origin).Host == "10.2.84.34")
                    .SetIsOriginAllowed(origin => new Uri(origin).Host == "10.0.0.132")
                    .SetIsOriginAllowed(origin => new Uri(origin).Host == "10.0.0.130")
                    .SetIsOriginAllowed(origin => new Uri(origin).Host == "10.0.0.131")
                    /*.WithHeaders(HeaderNames.Authorization)
                    .WithHeaders(HeaderNames.Accept)
                    .WithHeaders(HeaderNames.ContentType)
                    .WithHeaders(HeaderNames.Origin)*/
                    .AllowAnyHeader();
            });
    })


    .AddScoped<IGenerarDTOsBasica, GenerarDTOsBasica>()
    .AddScoped<IActividadQueryIDService, ActividadQueryIDService>()
    .AddScoped<IActividadQueryGralService, ActividadQueryGralService>()
    .AddScoped<IActividadesQueryReservasService, ActividadesQueryReservasService>()
    .AddScoped<IGeneradorQR, GeneradorQR>()
    .AddScoped<IGeneradorPDF, GeneradorPDF>()
    .AddScoped<ITramitarReservaService, TramitarReservaService>();




// Mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapping());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();      // modificado recien
}

SwaggerConfig.AddRegistration(app);


app.UseHttpsRedirection();

//app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();



app.Run();

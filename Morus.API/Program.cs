using Application;
using Application.Interfaces;
using Application.NovaPasta1;
using AutoMapper;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Morus.API.Models;
using Morus.API.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Morus.API", Version = "v1.0" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        });

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                                    {
                                        {
                                            new OpenApiSecurityScheme
                                            {
                                                Reference = new OpenApiReference
                                                {
                                                    Type = ReferenceType.SecurityScheme,
                                                    Id = "Bearer"
                                                }
                                            },
                                            new string[] {}
                                        }
                                    });
    });


// Config Services

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ContextBase>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ContextBase>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});


//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContextBase>();

// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IMessage, RepositoryMessage>();
builder.Services.AddSingleton<ICondominio, CondominioRepositorio>();
builder.Services.AddSingleton<IUsuario, UsuarioRepositorio>();
builder.Services.AddSingleton<IInformacaoRepositorio, InformacaoRepositorio>();
builder.Services.AddSingleton<IMulta, MultaRepositorio>();
builder.Services.AddSingleton<IOcorrencia, OcorrenciaRepositorio>();
builder.Services.AddSingleton<ILivroCaixaRepositorio, LivroCaixaRepositorio>();
builder.Services.AddSingleton<IAreaComumRepositorio, AreaComumRepositorio>();
builder.Services.AddSingleton<ITaxaMensalRepositorio, TaxaMensalRepositorio>();

builder.Services.AddScoped<CondominioRepositorio, CondominioRepositorio>();
builder.Services.AddScoped<UsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<InformacaoRepositorio, InformacaoRepositorio>();
builder.Services.AddScoped<MultaRepositorio, MultaRepositorio>();
builder.Services.AddScoped<OcorrenciaRepositorio, OcorrenciaRepositorio>();
builder.Services.AddScoped<AreaComumRepositorio, AreaComumRepositorio>();

builder.Services.AddScoped<IOcorrenciaApplication, OcorrenciaApplication>();
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();

builder.Services.AddScoped<INotificador, Notificador>();

builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()));

// SERVIÇO DOMINIO
builder.Services.AddSingleton<IServiceMessage, ServiceMessage>();
builder.Services.AddSingleton<ICondominioService, CondominioService>();
builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<IInformacaoService, InformacaoService>();
builder.Services.AddSingleton<IMultaService, MultaService>();
builder.Services.AddSingleton<IOcorrenciaService, OcorrenciaService>();
builder.Services.AddSingleton<ILivroCaixaService, LivroCaixaService>();
builder.Services.AddSingleton<ITaxaMensalService, TaxaMensalService>();
builder.Services.AddSingleton<IAreaComumService, AreaComumService>();

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "Morus.Securiry.Bearer",
              ValidAudience = "Morus.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
      });


var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<MessageViewModel, Message>();
    cfg.CreateMap<Message, MessageViewModel>();
    cfg.CreateMap<CondominioRequest, Condominio>();
    cfg.CreateMap<Condominio, CondominioRequest>();
    cfg.CreateMap<UsuarioRequest, Usuario>();
    cfg.CreateMap<Usuario, UsuarioRequest>();
    cfg.CreateMap<Informacao, InformacaoRequest>();
    cfg.CreateMap<InformacaoRequest, Informacao>();
    cfg.CreateMap<Multa, MultaRequest>();
    cfg.CreateMap<MultaRequest, Multa>();
    cfg.CreateMap<Ocorrencia, OcorrenciaRequest>();
    cfg.CreateMap<OcorrenciaRequest, Ocorrencia>();
    cfg.CreateMap<LivroCaixa, LivroCaixaRequest>();
    cfg.CreateMap<LivroCaixaRequest, LivroCaixa>();
    cfg.CreateMap<TaxaMensal, TaxaMensalRequest>();
    cfg.CreateMap<TaxaMensalRequest, TaxaMensal>();
    cfg.CreateMap<AreaComum, AreaComumRequest>();
    cfg.CreateMap<AreaComumRequest, AreaComum>();
    cfg.CreateMap<CadastrarMoradorRequest, Usuario>();
    cfg.CreateMap<Usuario, UsuarioLogadoResponse>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devClient = "http://localhost:4200";
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader().WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();
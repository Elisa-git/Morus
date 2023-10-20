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
builder.Services.AddTransient<ICondominio, CondominioRepositorio>();
builder.Services.AddTransient<IUsuario, UsuarioRepositorio>();
builder.Services.AddTransient<IInformacaoRepositorio, InformacaoRepositorio>();
builder.Services.AddTransient<IMulta, MultaRepositorio>();
builder.Services.AddTransient<IOcorrencia, OcorrenciaRepositorio>();
builder.Services.AddTransient<ILivroCaixaRepositorio, LivroCaixaRepositorio>();
builder.Services.AddTransient<IAreaComumRepositorio, AreaComumRepositorio>();
builder.Services.AddTransient<ITaxaMensalRepositorio, TaxaMensalRepositorio>();
builder.Services.AddTransient<IReservaRepositorio, ReservaRepositorio>();
builder.Services.AddTransient<IVotacaoRepositorio, VotacaoRepositorio>();
builder.Services.AddTransient<IVotoRepositorio, VotoRepositorio>();
builder.Services.AddSingleton<IArquivoRepositorio, ArquivoRepositorio>();

builder.Services.AddScoped<CondominioRepositorio, CondominioRepositorio>();
builder.Services.AddScoped<UsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<InformacaoRepositorio, InformacaoRepositorio>();
builder.Services.AddScoped<MultaRepositorio, MultaRepositorio>();
builder.Services.AddScoped<OcorrenciaRepositorio, OcorrenciaRepositorio>();
builder.Services.AddScoped<AreaComumRepositorio, AreaComumRepositorio>();
builder.Services.AddScoped<ReservaRepositorio, ReservaRepositorio>();
builder.Services.AddScoped<ArquivoRepositorio, ArquivoRepositorio>();

builder.Services.AddScoped<IOcorrenciaApplication, OcorrenciaApplication>();
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();
builder.Services.AddScoped<IUserLogadoApplication, UserLogadoApplication>();
builder.Services.AddScoped<IInformacaoApplication, InformacaoApplication>();
builder.Services.AddScoped<IVotacaoApplication, VotacaoApplication>();
builder.Services.AddScoped<ILivroCaixaApplication, LivroCaixaApplication>();

builder.Services.AddScoped<INotificador, Notificador>();

builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()));

// SERVIÇO DOMINIO
builder.Services.AddScoped<IServiceMessage, ServiceMessage>();
builder.Services.AddScoped<ICondominioService, CondominioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IInformacaoService, InformacaoService>();
builder.Services.AddScoped<IMultaService, MultaService>();
builder.Services.AddScoped<IOcorrenciaService, OcorrenciaService>();
builder.Services.AddScoped<ILivroCaixaService, LivroCaixaService>();
builder.Services.AddScoped<ITaxaMensalService, TaxaMensalService>();
builder.Services.AddScoped<IVotacaoService, VotacaoService>();
builder.Services.AddScoped<IAreaComumService, AreaComumService>();
builder.Services.AddScoped<IVotacaoService, VotacaoService>();
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<IArquivoService, ArquivoService>();

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
    cfg.CreateMap<TaxaMensal, TaxaMensalRequest>();
    cfg.CreateMap<TaxaMensalRequest, TaxaMensal>();
    cfg.CreateMap<Votacao, VotacaoRequest>();
    cfg.CreateMap<VotacaoRequest, Votacao>();
    cfg.CreateMap<AreaComum, AreaComumRequest>();
    cfg.CreateMap<AreaComumRequest, AreaComum>();
    cfg.CreateMap<CadastrarMoradorRequest, Usuario>();
    cfg.CreateMap<Usuario, UsuarioLogadoResponse>();
    cfg.CreateMap<Votacao, CadastrarVotacaoRequest>().ReverseMap();
    cfg.CreateMap<Voto, RegistrarVotoRequest>().ReverseMap();
    cfg.CreateMap<Reserva, ReservaRequest>();
    cfg.CreateMap<ReservaRequest, Reserva>();
    cfg.CreateMap<Arquivo, ArquivoRequest>();
    cfg.CreateMap<ArquivoRequest, Arquivo>();
    cfg.CreateMap<LivroCaixa, LivroCaixaRequest>().ReverseMap();
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

//var devClient = "http://localhost:5173";
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());//.WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();
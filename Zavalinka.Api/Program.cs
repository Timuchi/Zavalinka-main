using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zavalinka.BL.Authentication.Hashing;
using Zavalinka.BL.Authentication.Options;
using Zavalinka.BL.Authentication.RestoringPassword;
using Zavalinka.BL.Authentication.Services;
using Zavalinka.BL.Services;
using Zavalinka.DB;
using Zavalinka.DB.Repository.AnswerRepository;
using Zavalinka.DB.Repository.Game;
using Zavalinka.DB.Repository.RestoringCode;
using Zavalinka.DB.Repository.Round;
using Zavalinka.DB.Repository.Team;
using Zavalinka.DB.Repository.Theme;
using Zavalinka.DB.Repository.ThemeRound;
using Zavalinka.DB.Repository.User;
using Zavalinka.Domain.Interfaces;
using Zavalinka.Domain.Profiles;
using ServiceCollectionExtensions = Zavalinka.Api.Extension.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Configure App Options
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection(AppOptions.App));
var appOptions = builder.Configuration.GetSection(AppOptions.App).Get<AppOptions>();
builder.Services.AddSingleton(appOptions);
            
// Configure SmtpClient Options
builder.Services.Configure<SmtpClientOptions>(builder.Configuration.GetSection(SmtpClientOptions.SmtpClient));
var smtpClientOptions = builder.Configuration.GetSection(SmtpClientOptions.SmtpClient).Get<SmtpClientOptions>();
builder.Services.AddSingleton(smtpClientOptions);

builder.Services.AddCors(options =>
{ 
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Configure Authentication
ServiceCollectionExtensions.ConfigureAuthentication(builder.Services, builder.Configuration);
            
// Configure Swagger
ServiceCollectionExtensions.ConfigureSwagger(builder.Services);

// Configure Repositories & Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRestoringCodeRepository, RestoringCodeRepository>();

builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IRoundRepository, RoundRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();
builder.Services.AddScoped<IThemeRoundRepository, ThemeRoundRepository>();


builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IRestorePasswordService, RestorePasswordService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IRoundService, RoundService>();
builder.Services.AddScoped<ITeamsService, TeamsService>();
builder.Services.AddScoped<IThemeService, ThemeService>();

            
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
//services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(connection));
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection,  
    x => x.MigrationsAssembly("Zavalinka.DB")));
            
//Configure AutoMapper Profile
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AppProfile());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
            
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers();});

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
    await context.Database.MigrateAsync();
}

app.Run();
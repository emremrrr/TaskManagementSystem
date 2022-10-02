using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TaskManagementSystem.Business.Managers;
using TaskManagementSystem.Data.DBAccess;
using Microsoft.Extensions.Configuration;
using TaskManagementSystem.Business.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
     options.AddDefaultPolicy(builder =>
     builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddScoped<ITaskDataAccess, TaskDataAccess>();
builder.Services.AddScoped<IUserManager,UserManager>();
builder.Services.AddScoped<ITaskManager, TaskManager>();
builder.Services.AddScoped<ICommentManager, CommentManager>();
builder.Services.AddScoped<IJwt, Jwt>();
var secret = Convert.FromBase64String(builder.Configuration["Keys:Secret"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(token =>
{
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKeys = new List<SecurityKey>{
                                   new SymmetricSecurityKey(secret),
       },
        ClockSkew = TimeSpan.Zero

    };

    token.Events = new JwtBearerEvents
    {

        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using movies_api;
using movies_api.APIBehavior;
using movies_api.Filters;
using movies_api.Helpers;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); //pt a avea emailul frumos in claim


builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(MyExceptionFilter));
    options.Filters.Add(typeof(ParseBadRequest));
}).ConfigureApiBehaviorOptions(BadRequestBehavior.Parse);

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddSingleton(provider => new MapperConfiguration(config =>
{
    var geometryFactory = provider.GetRequiredService<GeometryFactory>();
    config.AddProfile(new AutoMapperProfiles(geometryFactory));
}
).CreateMapper());

builder.Services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.
    CreateGeometryFactory(srid: 4326)); //pt distante

builder.Services.AddScoped<IFileStorageService, AzureStorageService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching(); //pt sistem de cache

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
sqlOptions => sqlOptions.UseNetTopologySuite()));

builder.Services.AddCors(options =>   //pt a putea face call-uri
{
    var frontentURL = builder.Configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontentURL).AllowAnyMethod().AllowAnyHeader()
        .WithExposedHeaders(new string[] { "totalAmountOfRecords" });

    });
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()  //pt identity
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //pt autentificare
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["keyjwt"])),
            ClockSkew = TimeSpan.Zero,
        };
    });
//policy for admins:
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAdmin", policy => policy.RequireClaim("role", "admin"));
});

builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);

var app = builder.Build();


// Configure the HTTP request pipeline.
/*//logging everything in logger from the pipeline 
app.Use(async (context, next) =>
{

    using (var swapStream=new MemoryStream())
    {
        var originalResponseBody = context.Response.Body;
        context.Response.Body = swapStream;
        await next.Invoke(); //continua executia pipelineului

        swapStream.Seek(0,SeekOrigin.Begin);
        string responseBody = new StreamReader(swapStream).ReadToEnd();
        
        swapStream.Seek(0,SeekOrigin.Begin);
        await swapStream.CopyToAsync(originalResponseBody);
        context.Response.Body = originalResponseBody;
        app.Logger.LogInformation(responseBody);
    }
});
//custom middleware:
app.Map("/map1", (app) => app.Run(async contxt =>
{
    await contxt.Response.WriteAsync("I am short-circuiting the pipeline");
})); 
*/

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseResponseCaching();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

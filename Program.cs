using ani_server.DataAccess;
using ani_server.DataBaseContext;
using ani_server.GraphQl;
using ani_server.Heplers;
using ani_server.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAnime, AnimeDataAccessLayer>();
builder.Services.AddTransient<ICharacter,CharacterDataAccessLayer>();

// var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
// var dbName =  Environment.GetEnvironmentVariable("DB_NAME");
// var dbPassword =  Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
// var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword}";

builder.Services.AddEntityFrameworkNpgsql().AddDbContextFactory<AniSaveDbContext>(options =>
{
    
    //  SqlAuthenticationProvider.SetProvider(
    //     SqlAuthenticationMethod.ActiveDirectoryDeviceCodeFlow,
    //     new CustomAzureSqlAuthProvider());
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString);

    options.LogTo(Console.WriteLine); 
});
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddGraphQLServer()
        .AddQueryType<AnimeQueryResolver>()
        .AddMutationType<AnimeMutationResolver>()
        .AddTypeExtension<CharacterMutationResolver>()
        .AddFiltering();

    
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               .WithOrigins("http://localhost:4200","https://anisaveclient.vercel.app");
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/graphql");
        return;
    }
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
var FileProviderPath = app.Environment.WebRootPath + "/Poster";
if(!Directory.Exists(FileProviderPath)){
    Directory.CreateDirectory(FileProviderPath);
}
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(FileProviderPath),
    RequestPath = "/Poster",
    EnableDirectoryBrowsing = true
});

app.MapGraphQL();



app.Run();


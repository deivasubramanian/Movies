using AutoMapper;
using DataLibrary;
using DataLibrary.DataRepository;
using Microsoft.EntityFrameworkCore;
using Movies.DTOMapper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//make this singleton as its an in-memory database (by default it is a scoped service)
builder.Services.AddDbContext<MovieDataContext>(options => options.UseInMemoryDatabase("Movies"), ServiceLifetime.Singleton, ServiceLifetime.Singleton);
builder.Services.AddControllersWithViews();

//these are transient as they only need to be used within the scope of a single request
builder.Services.AddTransient<IMovieRepository, MovieRepository>(p => new MovieRepository(p.GetRequiredService<MovieDataContext>()));

builder.Services.AddAutoMapper(typeof(MovieMapperProile));
builder.Services.AddTransient<IMapper, Mapper>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MovieDataContext>();

    //smple data
    DataGenerator.Initialize(services);
}
  


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

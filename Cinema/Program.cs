

using Cinema.DataManager;
using Cinema.DataManager.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IFilmDataManager, SqlFilmManager>(_=> new SqlFilmManager(builder.Configuration.GetConnectionString("SQLDb")));
builder.Services.AddSingleton<ISpectatorDataManager, SqlSpectatorManager>(_=> new SqlSpectatorManager(builder.Configuration.GetConnectionString("SQLDb")));
builder.Services.AddSingleton<ITicketDataManager, SqlTicketManager>(_=> new SqlTicketDataManager(builder.Configuration.GetConnectionString("SQLDb")));
builder.Services.AddSingleton<IMovieRoomsDataManager, SqlMovieRoomsManager>(_=> new SqlMovieRoomsManager(builder.Configuration.GetConnectionString("SQLDb")));

var app = builder.Build();

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

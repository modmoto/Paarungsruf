using MongoDB.Driver;
using Paarungsruf.Server.Matrixes;
using Paarungsruf.Server.NewRecruit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<MatrixRepository>();
builder.Services.AddHttpClient<TournamentRepository>(c => c.BaseAddress = new Uri("https://www.newrecruit.eu/"));

builder.Services.AddSingleton(_ =>
{
    var mongoConnectionString = "mongodb://localhost:27017";
    // var mongoConnectionString = "mongodb://admin:JzZxkHsmL2f62PEX@65.21.139.246:1001";
    return new MongoClient(mongoConnectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
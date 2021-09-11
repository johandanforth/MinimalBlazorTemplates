
var builder = WebApplication.CreateBuilder(args);

var isDevelopment = builder.Environment.IsDevelopment();

// Add services to the container.
var services = builder.Services;
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddMvc();

if (!isDevelopment)
    services.AddWebOptimizer(pipeline =>
    {
        pipeline.MinifyJsFiles("~/js/**/*.js");
        pipeline.MinifyCssFiles("~/css/**/*.css");
        pipeline.AddCssBundle("/css/bundle.css", "wwwroot/css/**/*.css").UseContentRoot();
        pipeline.AddJavaScriptBundle("/js/bundle.js", "js/**/*.js");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (isDevelopment)
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseWebOptimizer();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using qr.Services.Qr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews(); // MVC Controller desteði eklendi

// QR Service Registration
builder.Services.AddScoped<IQrService, QrService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// MVC routing - Varsayýlan sayfa QR Generator olarak ayarlandý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Qr}/{action=Index}/{id?}"); // Home yerine Qr Controller

app.MapRazorPages();

app.Run();
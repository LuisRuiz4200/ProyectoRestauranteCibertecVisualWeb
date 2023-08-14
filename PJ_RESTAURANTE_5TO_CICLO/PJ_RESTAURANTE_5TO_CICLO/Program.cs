
using PJ_RESTAURANTE_5TO_CICLO.Interface;
using PJ_RESTAURANTE_5TO_CICLO.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUsuario,UsuarioRepository>();
builder.Services.AddSingleton<ITipoUsuario,TipoUsuarioRepository>();
builder.Services.AddSingleton<IPedido, PedidoRepository>(); 
builder.Services.AddSingleton<IColaborador,ColaboradorRepository>();
builder.Services.AddSingleton<ITipoColaborador,TipoColaboradorRepository>();
builder.Services.AddSingleton<IProducto, ProductoDao>();
builder.Services.AddSingleton<ICategoria,CategoriaDao>();

builder.Services.AddSession();

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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

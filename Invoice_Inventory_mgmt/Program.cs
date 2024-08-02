using Invoice_Inventory_mgmt.Common;
using Invoice_Inventory_mgmt.Data;
using Invoice_Inventory_mgmt.Repository;
using Invoice_Inventory_mgmt.Service;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "AllowOrigin";

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//    });
//});

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))) ;

builder.Services.AddScoped<IProductCategoryRL, ProductCategoryRL>();
builder.Services.AddScoped<IProductCategorySL, ProductCategorySL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()|| app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

//app.UseCors(builder => builder.AllowAnyOrigin()); // Allow requests from any origin
//app.UseCors(builder => builder.AllowAnyHeader()); // Allow any header in the request
//app.UseCors(builder => builder.AllowAnyMethod()); // Allow any HTTP method in the request


//app.UseCors(x => x
//                .AllowAnyMethod()
//                .AllowAnyHeader()
//                .SetIsOriginAllowed(origin => true) // allow any origin
//                .AllowCredentials());

//app.UseCorsMiddleware();
//app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();

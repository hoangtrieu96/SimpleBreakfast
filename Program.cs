using System.Reflection;
using Microsoft.OpenApi.Models;
using SimpleBreakfast.Mapper;
using SimpleBreakfast.Models;
using SimpleBreakfast.Services.BreakfastService;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<BreakfastContext>();
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    builder.Services.AddScoped<IBreakfastRepository, BreakfastRepository>();
    builder.Services.AddSwaggerGen(o =>
    {
        o.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Simple Breakfast API",
            Version = "v1",
            Description = "API documentation for Simple Breakfast.",
            Contact = new OpenApiContact
             {
                 Name = "Trieu",
                 Email = string.Empty,
                 Url = new Uri("http://localhost")
             }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        o.IncludeXmlComments(xmlPath);
    });
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Breakfast API V1");
    });
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();
}

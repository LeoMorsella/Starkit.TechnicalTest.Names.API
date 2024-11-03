using Persistence;
using Persistence.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddSingleton<PersonRepository>();
builder.Services.AddTransient<PersonService>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarkIT People API v1"));

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
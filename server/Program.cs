using sever.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("https://meetme-arqsoft.herokuapp.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

builder.Services.AddControllers()
                .AddNewtonsoftJson();;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();


var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MessageHub>("/MessageHub");
    endpoints.MapHub<MatchesHub>("/MatchesHub");
});


app.UseHttpsRedirection();


app.MapControllers();

app.Run();

using RequestService.Policies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());

builder.Services.AddHttpClient("HttpClient").ConfigureHttpMessageHandlerBuilder(builder =>
    {
        builder.PrimaryHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (m, c, ch, e) => true //disable ssl for testing
        };
    }).AddPolicyHandler( 
        request => request.Method == HttpMethod.Get ? new ClientPolicy().ExponentialHttpRetry : new  ClientPolicy().LinearHttpRetry
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

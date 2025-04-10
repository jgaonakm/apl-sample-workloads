var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.
services.AddControllers()
        .AddXmlDataContractSerializerFormatters();
services.Scan(selector =>
    selector.FromAssemblyOf<Program>()
    .AddClasses()
    .AsImplementedInterfaces()
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine("Running on Development mode!");
    builder.WebHost.UseUrls("http://localhost:5050", "https://localhost:5151");
    //NOTE: Use dotnet dev-certs https --trust to run HTTPS locally
}

app.MapGet("/", () => "Animal API");


new DummyAnimalStore().Populate();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();



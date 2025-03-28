var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine("Running on Development mode!");
    builder.WebHost.UseUrls("http://localhost:5050", "https://localhost:5151");
    //NOTE: Use dotnet dev-certs https --trust to run HTTPS locally
}

app.MapGet("/", () => "Secret reader running as Knative Service");

app.MapGet("/read", async (HttpContext context) =>
{
    // Required
    string? secret = context.Request.Query["secret"];
    if (string.IsNullOrEmpty(secret))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Please provide the name of the secret.");
        return;
    }

    string? value = Environment.GetEnvironmentVariable(secret);

    if (!string.IsNullOrEmpty(value))
    {
        await context.Response.WriteAsync($"I know your secret is {value}.");
    }
    else
    {
        await context.Response.WriteAsync("Empty secret or non existing");
    }


});

app.Run();

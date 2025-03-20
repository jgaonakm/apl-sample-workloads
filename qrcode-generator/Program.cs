using QRCoder;
using static QRCoder.QRCodeGenerator;
using static Microsoft.AspNetCore.Http.StatusCodes;


// Configuring application
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine("Running on Development mode!");
    builder.WebHost.UseUrls("http://localhost:5050", "https://localhost:5151");
    //NOTE: Use dotnet dev-certs https --trust to run HTTPS locally
}

// Routes
app.MapGet("/", () => "QR Code Generator running as Knative Service");

app.MapGet("/generate", async (HttpContext context) =>
{
    // Required
    string? text = context.Request.Query["text"];
    if (string.IsNullOrEmpty(text))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Please provide a text query parameter.");
        return;
    }

    // Optional parameters
    string? requestedVersion = context.Request.Query["version"];
    string? level = context.Request.Query["level"].FirstOrDefault();
    if (string.IsNullOrEmpty(level))
    {
        level = "M"; // Default: 15% of loss
    }

    ECCLevel eccLevel;
    switch (level)
    {

        case "L":
            eccLevel = ECCLevel.L;
            break;
        case "M":
            eccLevel = ECCLevel.M;
            break;
        case "Q":
            eccLevel = ECCLevel.Q;
            break;
        case "H":
            eccLevel = ECCLevel.H;
            break;
        default:
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Please L, M, Q, or H as the ECC Level");
            return;
    }


    int version = -1; // Default: let the library decide the best algorithm
    if (!string.IsNullOrEmpty(requestedVersion))
    {
        int.TryParse(requestedVersion, out version);
    }

    // Code generation
    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(
    text,
    eccLevel,
    forceUtf8: true,
    utf8BOM: true,
    eciMode: EciMode.Utf8,
    requestedVersion: version))
    using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
    {
        byte[] imageBytes = qrCode.GetGraphic(20);
        using (var ms = new MemoryStream())
        {
            context.Response.ContentType = "image/png";
            await context.Response.Body.WriteAsync(imageBytes, 0, imageBytes.Length);
        }
    }
});

app.Run();


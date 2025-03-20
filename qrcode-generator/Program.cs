using QRCoder;
using static QRCoder.QRCodeGenerator;
using static Microsoft.AspNetCore.Http.StatusCodes;


// Configuring application
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.RedirectStatusCode = Status308PermanentRedirect;
        options.HttpsPort = 8081;
    });
}

// Routes
app.MapGet("/", () => "QR Code Generator running as Knative Service");

app.MapGet("/generate", async (HttpContext context) =>
{
    string? text = context.Request.Query["text"]; // Required
    // Optional parameters
    string? requestedVersion = context.Request.Query["version"];
    string level = context.Request.Query["level"].First() ?? "M";

    if (string.IsNullOrEmpty(text))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Please provide a text query parameter.");
        return;
    }


    int version = -1;
    int.TryParse(requestedVersion, out version);


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

    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(
    text,
    eccLevel,
    forceUtf8: true,
    utf8BOM: true,
    eciMode: EciMode.Utf8,
    requestedVersion: version))

    //v6-M 2017
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


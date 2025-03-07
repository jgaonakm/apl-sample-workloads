using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "QR Code Generator running as Knative Service");

app.MapGet("/generate", async (HttpContext context) =>
{
    string? text = context.Request.Query["text"];
    if (string.IsNullOrEmpty(text))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Please provide a text query parameter.");
        return;
    }

    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
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


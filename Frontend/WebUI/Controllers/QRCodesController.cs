using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;

namespace WebUI.Controllers;

public class QRCodesController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string qrCodeValue)
    {
        QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
        QRCodeData data = qRCodeGenerator.CreateQrCode(qrCodeValue, QRCodeGenerator.ECCLevel.Q);
        BitmapByteQRCode bitmapByteQRCode = new BitmapByteQRCode(data);
        byte[] qrCodeByte = bitmapByteQRCode.GetGraphic(10);

        Bitmap bitmap;
        using (MemoryStream memoryStream = new MemoryStream(qrCodeByte))
        {
            bitmap = new Bitmap(memoryStream);
            ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
        }

        return View();
    }
}
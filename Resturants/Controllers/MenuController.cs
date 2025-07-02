
using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Resturants.DAL;
using Resturants.ViewModels;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;





namespace Resturants.Controllers
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Take(4).ToListAsync();

            var viewModel = new HomeVM
            {
                Menus = menus
            };

            return View(viewModel);
        }
        public IActionResult GenerateQr()
        {
            string qrText = Url.Action("Index", "Menu", null, Request.Scheme);

            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 300,
                    Width = 300,
                    Margin = 1
                }
            };

            var pixelData = writer.Write(qrText);

            // Bitmap yarat
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            {
                var bitmapData = bitmap.LockBits(
                    new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppRgb
                );

                System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                bitmap.UnlockBits(bitmapData);

                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return File(ms.ToArray(), "image/png");
                }
            }
        }
    }
}
  



     

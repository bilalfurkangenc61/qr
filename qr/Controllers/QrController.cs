using Microsoft.AspNetCore.Mvc;
using qr.Models;
using qr.Services.Qr;
using System.ComponentModel.DataAnnotations;

namespace qr.Controllers
{
    public class QrController : Controller
    {
        private readonly IQrService _qrService;

        public QrController(IQrService qrService)
        {
            _qrService = qrService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ContactInfo();
            return View(model);
        }

        [HttpPost]
        public IActionResult Generate(ContactInfo model)
        {
           
            ModelState.Clear();

            if (string.IsNullOrEmpty(model.FirstName))
            {
                ModelState.AddModelError("FirstName", "İsim gereklidir");
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                ModelState.AddModelError("LastName", "Soyisim gereklidir");
            }

           
            if (!string.IsNullOrEmpty(model.MobilePhone) &&
                !System.Text.RegularExpressions.Regex.IsMatch(model.MobilePhone, @"^(\+90|0)?5\d{9}$"))
            {
                ModelState.AddModelError("MobilePhone", "Geçerli bir cep telefonu giriniz (5xx xxx xxxx)");
            }

            if (!string.IsNullOrEmpty(model.LandlinePhone) &&
                !System.Text.RegularExpressions.Regex.IsMatch(model.LandlinePhone, @"^(\+90|0)?216\d{7}$"))
            {
                ModelState.AddModelError("LandlinePhone", "Geçerli bir sabit telefon giriniz (216 xxx xxxx)");
            }

           
            if (!string.IsNullOrEmpty(model.Email))
            {
                var emailAttribute = new EmailAddressAttribute();
                if (!emailAttribute.IsValid(model.Email))
                {
                    ModelState.AddModelError("Email", "Geçerli bir e-posta adresi giriniz");
                }
            }

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
              
                string content = _qrService.BuildVCardWithAllFields(
                    model.FirstName,
                    model.LastName,
                    model.Title,
                    model.Department,
                    model.MobilePhone,
                    model.LandlinePhone,
                    model.Email);

                
                if (model.OutputType == "PNG")
                {
                    var pngBytes = _qrService.GeneratePng(content);
                    ViewBag.QrImageData = $"data:image/png;base64,{Convert.ToBase64String(pngBytes)}";
                }
                else
                {
                    ViewBag.QrImageData = _qrService.GenerateSvg(content);
                }

                ViewBag.GeneratedContent = content;
                ViewBag.IsGenerated = true;

                return View("Index", model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"QR Code oluşturulurken hata: {ex.Message}");
                return View("Index", model);
            }
        }
    }
}
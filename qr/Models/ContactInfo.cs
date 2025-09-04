using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator.SwissQrCode;

namespace qr.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "İsim gereklidir")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyisim gereklidir")]
        public string LastName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string MobilePhone { get; set; } = string.Empty;

        public string LandlinePhone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string Email { get; set; } = string.Empty;

        public string OutputType { get; set; } = "PNG";

        public string Phone
        {
            get
            {
                if (!string.IsNullOrEmpty(MobilePhone))
                    return MobilePhone;
                if (!string.IsNullOrEmpty(LandlinePhone))
                    return LandlinePhone;
                return string.Empty;
            }
        }

     
        public static List<string> Departments { get; } = new List<string>
        {
            "BT Operasyon Yönetimi BM ",
            "Altyapı Yönetimi BM",
            "Bilgi Güvenliği ve Uyum BM",
            "Bilgi Teknolojileri Genel Müdür Yardımcılığı",
            "BT Operasyon Yönetimi BM",
            "BT Proje Yönetimi ve Koordinasyon BM",
            "Finansal İtiraz ve İşlem Güvenliği Yönetimi BM",
            "Finansal Muhasebe ve Vergi Yönetimi Md. Finansal Muhasebe ve Bütçe Yönetimi",
            "Finansal Muhasebe ve Vergi Yönetimi BM",
            "Finansal Yönetim İnsan Kaynakları ve İdari İşler Genel Müdür Yardımcılığı",
            "İç Kontrol ve Denetim BM",
            "İnsan Kaynakları Organizasyon ve Performans Yönetimi Md. İdari İşler",
            "İnsan Kaynakları Organizasyon ve Performans Yönetimi BM",
            "İşyeri ve Müşteri Operasyonları BM",
            "Operasyon Yönetimi Genel Müdür Yardımcılığı",
            "Pazarlama Satış ve Ürün Yönetimi Genel Müdür Yardımcılığı",
            "Pazarlama ve İş Geliştirme BM",
            "Proje ve Yazılım Uygulama Yönetimi Md. İş Analizi ve Yazılım",
            "Proje ve Yazılım Uygulama Yönetimi Md. Proje ve Süreç Yönetimi",
            "Risk Yönetimi ve Uyum BM",
            "Saha Satış Yönetimi BM",
            "Takas ve Mutabakat BM",
            "Uygulama Geliştirme BM",
            "Kurumsal Satış BM"
        };

        public static List<string> Titles { get; } = new List<string>
        {
          "Bölüm Müdürü",
          "BT Bölüm Müdürü",
          "BT Teknik Yönetici",
          "Destek Personeli",
          "Genel Müdür",
          "Genel Müdür Ve Yön. Krl. Üyesi",
          "Genel Müdür Yardımcısı",
          "Kıdemli Uzman",
          "Servis Asistanı",
          "Uzman",
          "Uzman Yardımcısı",
          "Yönetim Kurulu Üyesi",
          "Yönetmen"
        };
    }
}
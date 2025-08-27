using QRCoder;
using System.Text;

namespace qr.Services.Qr
{
    public class QrService : IQrService
    {
        private const string COMPANY_NAME = "Halk Elektronik Para ve Ödeme Hizmetleri Anonim Şirketi";
        private const string WEBSITE_URL = "https://www.parao.com.tr/";
        private const string Adress = "Barbaros Mah. Mor Sümbül Sk. WBC İş Merkezi, Blok No: 9 İç Kapı No: 9;Ataşehir;İstanbul;;Türkiye";

        public byte[] GeneratePng(string content)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }

        public string GenerateSvg(string content)
        {
           
            var pngBytes = GeneratePng(content);
            var base64 = Convert.ToBase64String(pngBytes);
            return $"data:image/png;base64,{base64}";
        }

        public string BuildVCard(string firstName, string lastName, string phone, string email)
        {
            var vCard = new StringBuilder();
            vCard.AppendLine("BEGIN:VCARD");
            vCard.AppendLine("VERSION:3.0");
            vCard.AppendLine($"FN:{firstName} {lastName}");
            vCard.AppendLine($"N:{lastName};{firstName};;;");

            
            vCard.AppendLine($"ORG:{COMPANY_NAME}");

            if (!string.IsNullOrWhiteSpace(phone))
                vCard.AppendLine($"TEL:{phone}");

            if (!string.IsNullOrWhiteSpace(email))
                vCard.AppendLine($"EMAIL:{email}");

            
            vCard.AppendLine($"URL;TYPE=WORK:{WEBSITE_URL}");

            
            vCard.AppendLine($"ADR;TYPE=WORK:;;Barbaros Mah. Mor Sümbül Sk. WBC İş Merkezi, Blok No: 9 İç Kapı No: 9;Ataşehir;İstanbul;;Türkiye");

            vCard.AppendLine("END:VCARD");
            return vCard.ToString();
        }

        public string BuildVCardWithMultiplePhones(string firstName, string lastName, string mobilePhone, string landlinePhone, string email)
        {
            var vCard = new StringBuilder();
            vCard.AppendLine("BEGIN:VCARD");
            vCard.AppendLine("VERSION:3.0");
            vCard.AppendLine($"FN:{firstName} {lastName}");
            vCard.AppendLine($"N:{lastName};{firstName};;;");

           
            vCard.AppendLine($"ORG:{COMPANY_NAME}");

            if (!string.IsNullOrWhiteSpace(mobilePhone))
                vCard.AppendLine($"TEL;TYPE=CELL:{mobilePhone}");

            if (!string.IsNullOrWhiteSpace(landlinePhone))
                vCard.AppendLine($"TEL;TYPE=HOME:{landlinePhone}");

            if (!string.IsNullOrWhiteSpace(email))
                vCard.AppendLine($"EMAIL:{email}");

           
            vCard.AppendLine($"URL;TYPE=WORK:{WEBSITE_URL}");

            
            vCard.AppendLine($"ADR;TYPE=WORK:;;Barbaros Mah. Mor Sümbül Sk. WBC İş Merkezi, Blok No: 9 İç Kapı No: 9;Ataşehir;İstanbul;;Türkiye");

            vCard.AppendLine("END:VCARD");
            return vCard.ToString();
        }

        public string BuildVCardWithAllFields(string firstName, string lastName, string department, string title, string mobilePhone, string landlinePhone, string email)
        {
            var vCard = new StringBuilder();
            vCard.AppendLine("BEGIN:VCARD");
            vCard.AppendLine("VERSION:3.0");

            
            vCard.AppendLine($"FN:{firstName} {lastName}");
            vCard.AppendLine($"N:{lastName};{firstName};;;");

            
            if (!string.IsNullOrWhiteSpace(title))
                vCard.AppendLine($"TITLE:{title}");

            
            var organization = !string.IsNullOrWhiteSpace(department)
                ? $"{COMPANY_NAME};{department}"
                : COMPANY_NAME;
            vCard.AppendLine($"ORG:{organization}");

            
            if (!string.IsNullOrWhiteSpace(landlinePhone))
                vCard.AppendLine($"TEL;TYPE=WORK:{landlinePhone}");

            if (!string.IsNullOrWhiteSpace(mobilePhone))
                vCard.AppendLine($"TEL;TYPE=CELL:{mobilePhone}");

          
            if (!string.IsNullOrWhiteSpace(email))
                vCard.AppendLine($"EMAIL;TYPE=INTERNET:{email}");

          
            vCard.AppendLine($"URL;TYPE=WORK:{WEBSITE_URL}");

            
            vCard.AppendLine($"ADR;TYPE=WORK:;;Barbaros Mah. Mor Sümbül Sk. WBC İş Merkezi, Blok No: 9 İç Kapı No: 9;Ataşehir;İstanbul;;Türkiye");

            vCard.AppendLine("END:VCARD");
            return vCard.ToString();
        }

        public string BuildPlainText(string firstName, string lastName, string phone, string email)
        {
            var text = new StringBuilder();
            text.AppendLine($"Ad Soyad: {firstName} {lastName}");
            text.AppendLine($"Şirket: {COMPANY_NAME}");

            if (!string.IsNullOrWhiteSpace(phone))
                text.AppendLine($"Telefon: {phone}");

            if (!string.IsNullOrWhiteSpace(email))
                text.AppendLine($"E-posta: {email}");

            text.AppendLine($"Ana Sayfa: {WEBSITE_URL}");

            text.AppendLine("Adres: Barbaros Mah. Mor Sümbül Sk. WBC İş Merkezi, Blok No: 9 İç Kapı No: 9 Ataşehir/İstanbul");

            return text.ToString().Trim();
        }

        public string BuildPlainTextWithMultiplePhones(string firstName, string lastName, string mobilePhone, string landlinePhone, string email)
        {
            var text = new StringBuilder();
            text.AppendLine($"Ad Soyad: {firstName} {lastName}");
            text.AppendLine($"Şirket: {COMPANY_NAME}");

            if (!string.IsNullOrWhiteSpace(mobilePhone))
                text.AppendLine($"Cep Telefonu: {mobilePhone}");

            if (!string.IsNullOrWhiteSpace(landlinePhone))
                text.AppendLine($"Sabit Telefon: {landlinePhone}");

            if (!string.IsNullOrWhiteSpace(email))
                text.AppendLine($"E-posta: {email}");

            text.AppendLine($"Ana Sayfa: {WEBSITE_URL}");

            text.AppendLine("Adres: Barbaros Mah. Mor Sümbül Sk. WBC İş Merkezi, Blok No: 9 İç Kapı No: 9 Ataşehir/İstanbul");

            return text.ToString().Trim();
        }
    }
}
using System.ComponentModel.DataAnnotations;

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
    }
}
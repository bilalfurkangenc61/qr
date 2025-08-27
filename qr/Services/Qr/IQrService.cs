namespace qr.Services.Qr
{
    public interface IQrService
    {
        byte[] GeneratePng(string content);
        string GenerateSvg(string content);
        string BuildVCard(string firstName, string lastName, string phone, string email);
        string BuildPlainText(string firstName, string lastName, string phone, string email);
        string BuildVCardWithMultiplePhones(string firstName, string lastName, string mobilePhone, string landlinePhone, string email);
        string BuildPlainTextWithMultiplePhones(string firstName, string lastName, string mobilePhone, string landlinePhone, string email);
        string BuildVCardWithAllFields(string firstName, string lastName, string title, string department, string mobilePhone, string landlinePhone, string email);
    }
}
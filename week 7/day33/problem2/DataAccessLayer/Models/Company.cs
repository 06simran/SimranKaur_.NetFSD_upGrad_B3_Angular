namespace DataAccessLayer.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        // Navigation Property
        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
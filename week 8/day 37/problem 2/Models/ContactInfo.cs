namespace WebApplication2.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public long MobileNo { get; set; }
        public string Designation { get; set; } = string.Empty;
        public int CompanyId { get; set; }      // FK
        public int DepartmentId { get; set; }   // FK
    }
}

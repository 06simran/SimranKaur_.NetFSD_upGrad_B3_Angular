namespace ContactManagement.DAL.Models;

public class ContactInfo
{
    public int ContactId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailId { get; set; } = string.Empty;
    public long MobileNo { get; set; }
    public string Designation { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public int DepartmentId { get; set; }

    // Navigation Properties
    public Company? Company { get; set; }
    public Department? Department { get; set; }
}

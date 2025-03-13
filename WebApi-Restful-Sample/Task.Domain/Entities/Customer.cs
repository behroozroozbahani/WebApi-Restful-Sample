namespace Task.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public long BirthCertificateNumber { get; set; }
        public long NationalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
    }
}

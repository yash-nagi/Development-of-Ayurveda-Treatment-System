using System.Drawing;

namespace Development_of_Ayurveda_Treatment_System.Models
{
    public class Users
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string DOB{ get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public Bitmap ProfilePhoto { get; set; }
    }
}

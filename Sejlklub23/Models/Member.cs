using System.ComponentModel.DataAnnotations;

namespace Sejlklub23.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public bool IsAdmin { get; set; }

        public Member(int id, string name, string password, string email, string phoneNumber, string address) 
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            IsAdmin = false;
        }
    }
}

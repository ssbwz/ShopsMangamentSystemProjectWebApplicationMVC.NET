using Logic.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MediaBazaar.Logic.Models
{
    public partial class Employee
    {
        // properties
     
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        public DateOnly Birthday { get; set; }
        [Required]
        public int PhoneNum { get; set; }
        [Required]
        public int? SpousePhoneNum { get; set; }

        public int BSN { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }


        public Employee(int id, string firstName, string lastName, string address, DateOnly birthday, int phoneNum, int? spousePhoneNum, int BSN, bool isActive, string username, string email, string password,ISettingsRepository settingRepository)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.Birthday = birthday;
            this.PhoneNum = phoneNum;
            this.SpousePhoneNum = spousePhoneNum;
            this.BSN = BSN;
            this.IsActive = isActive;
            this.Username = username;
            this.Email = email;
            this.Password = password;

            //Manager
            this.settingRepository = settingRepository;
        }

        public Employee() 
        { }
    }
}
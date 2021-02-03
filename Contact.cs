using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApplication.Models
{
    /// <summary>
    /// Contact Class with all Contact details
    /// </summary>
    public class Contact
    {
        [Required]
        public int ContactId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(20,ErrorMessage ="First Name should be 20 Characters")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email should be in proper format")]
        public string EmailId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
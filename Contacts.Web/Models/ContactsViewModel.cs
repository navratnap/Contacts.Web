using System.ComponentModel.DataAnnotations;

namespace Contacts.Web.Models
{
    /// <summary>
    /// ContactsViewModel class contains the contact properties with proper validations
    /// </summary>
    public class ContactsViewModel
    {
        /// <summary>
        /// Contact Id property
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// First Name property
        /// </summary>
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required!")]
        [MaxLength(50, ErrorMessage = "First Name must be less than 50 characters!")]
        [MinLength(2, ErrorMessage = "First Name must be greater than 2 characters!")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name property
        /// </summary>
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required!")]
        [MaxLength(50, ErrorMessage = "Last Name must be less than 50 characters!")]
        [MinLength(2, ErrorMessage = "Last Name must be greater than 2 characters!")]
        public string LastName { get; set; }

        /// <summary>
        /// Email Address property
        /// </summary>
        [Display(Name = "Email Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is required!")]
        [EmailAddress(ErrorMessage = "Email Address is Invalid!")]
        [MaxLength(50, ErrorMessage = "Email Address must be less than 50 characters!")]
        public string EmailID { get; set; }

        /// <summary>
        /// Phone Number property
        /// </summary>
        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is required!")]
        [Phone(ErrorMessage = "Phone Number is Invalid")]
        [MinLength(10, ErrorMessage = "Phone Number must be of 10 digits only!")]
        [MaxLength(10, ErrorMessage = "Phone Number must be of 10 digits only!")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Status property
        /// </summary>
        public bool Status { get; set; }

    }
}
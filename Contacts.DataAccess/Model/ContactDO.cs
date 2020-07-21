namespace Contacts.DataAccess.Model
{
    /// <summary>
    /// ContactDO class in Data Access
    /// </summary>
    public class ContactDO
    {
        /// <summary>
        /// Contact Id Property
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// First Name Property
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name Property
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email ID Property
        /// </summary>
        public string EmailID { get; set; }

        /// <summary>
        /// Phone Number Property
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Status Property
        /// </summary>
        public bool Status { get; set; }
    }
}

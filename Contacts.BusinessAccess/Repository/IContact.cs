using System.Collections.Generic;
using Contacts.BusinessAccess.Model;

namespace Contacts.BusinessAccess.Repository
{
    /// <summary>
    /// An IContact interface in Business Access for performing operations on contacts
    /// </summary>
    public interface IContact
    {
        /// <summary>
        /// An interface method to be implemented in BA for fetching the list of all contacts
        /// </summary>
        /// <returns>List<ContactModel></returns>
        List<ContactModel> GetAllContacts();

        /// <summary>
        /// An interface method to be implemented in BA for fetching a particular contact information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ContactModel</returns>
        ContactModel GetContact(int id);

        /// <summary>
        /// An interface method to be implemented in BA for adding a new contact
        /// </summary>
        /// <param name="item"></param>
        /// <returns>int</returns>
        int AddContact(ContactModel item);

        /// <summary>
        /// An interface method to be implemented in BA for updating the existing contact
        /// </summary>
        /// <param name="item"></param>
        /// <returns>int</returns>
        int UpdateContact(ContactModel item);

        /// <summary>
        /// An interface method to be implemented in BA for deleting the existing contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        int DeleteContact(int id);
    }
}

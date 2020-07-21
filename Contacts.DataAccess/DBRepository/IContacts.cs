using System.Collections.Generic;
using Contacts.DataAccess.Model;

namespace Contacts.DataAccess.DBRepository
{
    /// <summary>
    /// An IContacts interface in Data Access for performing operations on contacts
    /// </summary>
    public interface IContacts
    {
        /// <summary>
        /// An interface method to be implemented for fetching the list of all contacts
        /// </summary>
        /// <returns>List<ContactDO></returns>
        List<ContactDO> GetAllContacts();

        /// <summary>
        /// An interface method to be implemented in DA for fetching a particular contact information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ContactDO</returns>
        ContactDO GetContact(int id);

        /// <summary>
        /// An interface method to be implemented in DA for adding a new contact
        /// </summary>
        /// <param name="item"></param>
        /// <returns>int</returns>
        int AddContact(ContactDO item);

        /// <summary>
        /// An interface method to be implemented in DA for updating the existing contact
        /// </summary>
        /// <param name="item"></param>
        /// <returns>int</returns>
        int UpdateContact(ContactDO item);

        /// <summary>
        /// An interface method to be implemented in DA for deleting the existing contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        int DeleteContact(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool CheckIfContactAlreadyExist(ContactDO item);
    }
}

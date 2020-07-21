using Contacts.BusinessAccess.Model;
using Contacts.BusinessAccess.Repository;
using Contacts.DataAccess.DBRepository;
using Contacts.DataAccess.Model;
using System.Collections.Generic;

namespace Contacts.BusinessAccess.Services
{
    /// <summary>
    /// Implements the IContact interface in BA to perform operations on contacts
    /// </summary>
    public class Contacts : IContact
    {
        private IContacts _iContacts;

        /// <summary>
        /// Injects the dependency of IContacts interface in DA
        /// </summary>
        /// <param name="iContact"></param>
        public Contacts(DataAccess.DBRepository.IContacts iContacts)
        {
            _iContacts = iContacts;
        }

        /// <summary>
        /// Fetch Contact information for particular contact Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ContactModel</returns>
        public ContactModel GetContact(int id)
        {
            ContactDO contactDetailsDO = _iContacts.GetContact(id);

            return Mapper.Mapper.MapToContactModel(contactDetailsDO);
        }

        /// <summary>
        /// Fetch the list of all the Contacts
        /// </summary>
        /// <returns>List<ContactModel></returns>
        public List<ContactModel> GetAllContacts()
        {
            List<ContactDO> contactDetailsDOList = _iContacts.GetAllContacts();

            return Mapper.Mapper.MapToContactModelList(contactDetailsDOList);
        }

        /// <summary>
        /// Add the new contact information to the database
        /// </summary>
        /// <param name="contactDetailsModel"></param>
        /// <returns>int</returns>
        public int AddContact(ContactModel contactDetailsModel)
        {
            ContactDO contactDetailsDO = Mapper.Mapper.MapToContactDO(contactDetailsModel);
            if (CheckIfContactAlreadyExist(contactDetailsDO))
            {
                return 2; //2 for contact is already exist in DB
            }
            return _iContacts.AddContact(contactDetailsDO);
        }

        /// <summary>
        /// Updates the existing contact information
        /// </summary>
        /// <param name="contactDetailsModel"></param>
        /// <returns>int</returns>
        public int UpdateContact(ContactModel contactDetailsModel)
        {
            ContactDO contactDetailsDO = Mapper.Mapper.MapToContactDO(contactDetailsModel);
            if (!CheckIfContactAlreadyExist(contactDetailsDO))
            {
                return 2; //2 for contact is not exist in DB
            }
            return _iContacts.UpdateContact(contactDetailsDO);
        }

        /// <summary>
        /// Deletes the existing contact information
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns>int</returns>
        public int DeleteContact(int contactId)
        {
            return _iContacts.DeleteContact(contactId);
        }

        /// <summary>
        /// Checks if contact is already exists or not
        /// </summary>
        /// <param name="contactDetailsDO"></param>
        /// <returns></returns>
        private bool CheckIfContactAlreadyExist(ContactDO contactDetailsDO)
        {
            return _iContacts.CheckIfContactAlreadyExist(contactDetailsDO);
        }
    }
}
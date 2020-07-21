using Contacts.BusinessAccess.Repository;
using Contacts.Web.Automapper;
using Contacts.Web.Models;
using System;
using System.Web.Mvc;
using Contacts.Web.Common;

namespace Contacts.Web.Controllers
{
    /// <summary>
    /// Contact Controller to perform Fetch/Add/Update/Delete operations on contact
    /// </summary>
    [HandleError(View = "Error")]
    public class ContactController : BaseController
    {
        private IContact IContactRepository;

        /// <summary>
        /// Injects all dependencies in the contact constructor
        /// </summary>
        /// <param name="_iContact"></param>
        public ContactController(IContact _iContact)
        {
            IContactRepository = _iContact;
        }

        #region -- Get Contact --

        /// <summary>
        /// Fetches the list of all contacts in the database.
        /// </summary>
        /// <returns>Contact View</returns>
        public ActionResult Contact()
        {
            var allContactList = Mapper.MapToContactModelList(IContactRepository.GetAllContacts());

            return View("Contact", allContactList);
        }

        #endregion -- Get Contact --

        #region -- Add Contact --

        /// <summary>
        /// Displays the Add Contact page to add the new contact
        /// </summary>
        /// <returns>AddContact View</returns>
        [HttpGet]
        public ActionResult AddContact()
        {            
            return View("AddContact");
        }

        /// <summary>
        /// Adds the new contact into the database with the provided information
        /// </summary>
        /// <param name="contactViewModel"></param>
        /// <returns>ActionResult</returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddContact(ContactsViewModel contactViewModel)
        {
            int rowAffected = 0;
            if (ModelState.IsValid)
            {
                rowAffected = IContactRepository.AddContact(Mapper.MapToContactModelBO(contactViewModel));

                if (rowAffected == 2) //contact is already exist
                {
                    ModelState.AddModelError(string.Empty, "This Contact is already Exist!");
                    return View("AddContact", contactViewModel);
                }
                else if (rowAffected != 1)
                {
                    return View("Error");
                }
            }
            else
            {
                return View("AddContact", contactViewModel);
            }

            return RedirectToAction("Contact", "Contact");
        }

        #endregion -- Add Contact --

        #region -- Update Contact --

        /// <summary>
        /// Displays the Update Contact page to update the existing contact information
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>UpdateContact view</returns>
        [HttpGet]
        public ActionResult UpdateContact(string contact)
        {
            ContactsViewModel contactDetails = null;
            int contactID = Convert.ToInt32(Common.Encryption.Decrypt(contact));

            if (contactID != 0)
            {
                contactDetails = Mapper.MapToContactsViewModel(IContactRepository.GetContact(contactID));
            }

            return View("UpdateContact", contactDetails);
        }

        /// <summary>
        /// Updates the existing contact information into the database with the updated details
        /// </summary>
        /// <param name="contactViewModel"></param>
        /// <returns>ActionResult</returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateContact(ContactsViewModel contactViewModel)
        {            
            int rowAffected = 0;
            if (ModelState.IsValid)
            {
                rowAffected = IContactRepository.UpdateContact(Mapper.MapToContactModelBO(contactViewModel));
                if (rowAffected == 2) //contact is not exist
                {
                    ModelState.AddModelError(string.Empty, "This Contact is not Exist anymore!");
                    return View("UpdateContact", contactViewModel);
                }
                else if (rowAffected != 1)
                {
                    return View("Error");
                }
            }
            else
            {
                return View("UpdateContact", contactViewModel);
            }

            return RedirectToAction("Contact", "Contact");
        }

        #endregion -- Update Contact --

        #region -- Delete Contact --

        /// <summary>
        /// Displays the Delete Contact page to delete the existing contact information
        /// </summary>
        /// <param name="contactDetails"></param>
        /// <returns>DeleteContact</returns>
        [HttpGet]
        public ActionResult DeleteContact(string contact)
        {
            ContactsViewModel contactDetails = null;
            int contactID = Convert.ToInt32(Common.Encryption.Decrypt(contact));

            if (contactID != 0)
            {
                contactDetails = Mapper.MapToContactsViewModel(IContactRepository.GetContact(contactID));
            }

            return View("DeleteContact", contactDetails);
        }

        /// <summary>
        /// Deletes the existing contact information from the database
        /// </summary>
        /// <param name="contactViewModel"></param>
        /// <returns>ActionResult</returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteContact(int contactId)
        {
            int rowAffected = 0;
            if (contactId != 0)
            {
                rowAffected = IContactRepository.DeleteContact(contactId);
            }

            if (rowAffected == 1)
            {
                return RedirectToAction("Contact", "Contact");
            }
            else
            {
                return View("Error");
            }
        }

        #endregion -- Delete Contact --
    }
}
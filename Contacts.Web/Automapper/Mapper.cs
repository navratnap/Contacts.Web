using AutoMapper;
using Contacts.BusinessAccess.Model;
using Contacts.Web.Models;
using System.Collections.Generic;

namespace Contacts.Web.Automapper
{
    /// <summary>
    /// An Automapper Class to map the Contact BO model to Contact View Model and vice versa
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Maps the Contact View Model with the Contact Model in Business Access
        /// </summary>
        /// <param name="contactViewModel"></param>
        /// <returns>ContactModel</returns>
        public static ContactModel MapToContactModelBO(ContactsViewModel contactViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactsViewModel, ContactModel>();
            });

            IMapper iMapper = config.CreateMapper();
            ContactModel contactModelBO = iMapper.Map<ContactsViewModel, ContactModel>(contactViewModel);

            return contactModelBO;
        }

        /// <summary>
        /// Maps the Contact Model in Business Access with the Contact View Model
        /// </summary>
        /// <param name="contactModelBO"></param>
        /// <returns>ContactsViewModel</returns>
        public static ContactsViewModel MapToContactsViewModel(ContactModel contactModelBO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactModel, ContactsViewModel>();
            });

            IMapper iMapper = config.CreateMapper();

            ContactsViewModel contactViewModel = iMapper.Map<ContactModel, ContactsViewModel>(contactModelBO);

            return contactViewModel;
        }

        /// <summary>
        /// Maps the list of Contact Model in Business Access with the list of Contact View Model
        /// </summary>
        /// <param name="contactModelBOList"></param>
        /// <returns>List<ContactsViewModel></returns>
        public static List<ContactsViewModel> MapToContactModelList(List<ContactModel> contactModelBOList)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactModel, ContactsViewModel>();
            });

            IMapper iMapper = config.CreateMapper();
            List<ContactsViewModel> contactViewModelList = iMapper.Map<List<ContactModel>, List<ContactsViewModel>>(contactModelBOList);

            return contactViewModelList;
        }
    }
}
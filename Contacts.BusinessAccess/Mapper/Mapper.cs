using AutoMapper;
using Contacts.BusinessAccess.Model;
using Contacts.DataAccess.Model;
using System.Collections.Generic;

namespace Contacts.BusinessAccess.Mapper
{
    /// <summary>
    /// An Automapper Class to map the Contact BO model to Conatact DO Model and vice versa
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Maps the Contact DO model in the Data Access with the Contact Model in Business Access
        /// </summary>
        /// <param name="contactDetailsDO"></param>
        /// <returns>ContactModel</returns>
        public static ContactModel MapToContactModel(ContactDO contactDetailsDO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactDO, ContactModel>();
            });

            IMapper iMapper = config.CreateMapper();
            ContactModel contactDetailsModel = iMapper.Map<ContactDO, ContactModel>(contactDetailsDO);

            return contactDetailsModel;
        }

        /// <summary>
        /// Maps the Contact Model in Business Access with the Contact DO model in Data Access
        /// </summary>
        /// <param name="contactDetailsModel"></param>
        /// <returns>ContactDO</returns>
        public static ContactDO MapToContactDO(ContactModel contactDetailsModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactModel, ContactDO>();
            });

            IMapper iMapper = config.CreateMapper();

            ContactDO contactDetailsDO = iMapper.Map<ContactModel, ContactDO>(contactDetailsModel);

            return contactDetailsDO;
        }

        /// <summary>
        /// Maps the list of Contact DO model in the Data Access with the list of Contact Model in Business Access
        /// </summary>
        /// <param name="contactDetailsDOList"></param>
        /// <returns>List<ContactModel></returns>
        public static List<ContactModel> MapToContactModelList(List<ContactDO> contactDetailsDOList)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<ContactDO, ContactModel>();
            });

            IMapper iMapper = config.CreateMapper();
            List<ContactModel> contactDetailsModelList = iMapper.Map<List<ContactDO>, List<ContactModel>>(contactDetailsDOList);

            return contactDetailsModelList;
        }
    }
}

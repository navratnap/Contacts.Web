using Microsoft.Practices.Unity;
using Contacts.DataAccess.DBRepository;

namespace Contacts.BusinessAccess
{
    /// <summary>
    /// A Class for adding an extension in Unity Container
    /// </summary>
    public class DependencyExtension : UnityContainerExtension
    {
        /// <summary>
        /// Overriden the Initialize method to inject the DA dependency
        /// </summary>
        protected override void Initialize()
        {
            Container.RegisterType<IContacts, DataAccess.DBService.Contacts>();
        }
    }
}

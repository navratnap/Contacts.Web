using Contacts.BusinessAccess.Repository;
using System.Web.Mvc;

namespace Contacts.Web.Controllers
{
    /// <summary>
    /// HomeController Class
    /// </summary>
    public class HomeController : Controller
    {
        private IContact IContactRepository;

        /// <summary>
        /// HomeController Constructor to inject dependency
        /// </summary>
        /// <param name="_iContact"></param>
        public HomeController(IContact _iContact)
        {
            IContactRepository = _iContact;
        }

        /// <summary>
        /// Index Action Result method
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// About Action Result method
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Contact description page.";

            return View();
        }
    }
}
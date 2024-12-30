using System.Threading.Tasks;
using System.Web.Mvc;
using MVC.SPEND.Models;
using MVC.SPEND.Services;

namespace MVC.SPEND.Controllers
{
    public class ROTController : Controller
    {
        private IService_API _repository;
        public ROTController()
        {
            _repository = new Service_API();
        }
        // GET: ROT
        public async Task <ActionResult> Index()
        {
            ROT oMenus = new ROT();
            string WIDUsr = Request.Cookies["IDUsr"].Value;
            var oMenuXUser = await _repository.LLenaMenus(WIDUsr);
            oMenus.NombreUsuario = oMenuXUser.NombreUsuario;
            oMenus.IEnumMenus = oMenuXUser.IEnumMenus;
            oMenuXUser = null;
            return View(oMenus);
        }
    }
}
using System.Web.Mvc;
using MVC.SPEND.Models;
using MVC.SPEND.Services;
using System.Threading.Tasks;
namespace MVC.SPEND.Controllers
{
    public class AccController : Controller
    {
        private IService_API _repository;
        public AccController()
        {
            _repository = new Service_API();
        }
        // GET: Acc
        public ActionResult Index()
        {
            Usuario oUser = new Usuario();
            oUser.nPaso = 0; oUser.User = "";
            return View(oUser);
        }
        [HttpPost]
        public async Task<ActionResult> Valida(FormCollection oCollec)
        {
            string WUser = oCollec["txtUsr"].ToString(); string WContra = oCollec["txtContra"].ToString();
            int nValida = await _repository.Validar(WUser, WContra); 
            Response.Cookies["IDUsr"].Value = nValida.ToString(); oCollec = null;
            if (nValida == 0)
            {
                Usuario oValida = new Usuario(); 
                oValida.nPaso = 1; oValida.User = WUser; oValida.Password = WContra;
                return View("Index", oValida);
            }
            else
            {
                return RedirectToAction("Index", "ROT");
            }
        }
    }
}
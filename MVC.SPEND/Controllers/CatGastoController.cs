using MVC.SPEND.Models;
using MVC.SPEND.Services;
using MVC.SPEND.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.SPEND.Controllers
{
    public class CatGastoController : Controller
    {
        private ICatGastosService _repository;
        public CatGastoController()
        {
            _repository = new CatGastosService();
        }
        // GET: CatGasto
        public async Task<ActionResult> Index()
        {
            CatGastosRes oCatGasto = new CatGastosRes();
            var WIDUsr = Request.Cookies["IDUsr"].Value;
            var oCbxGastos = await _repository.LLenaGastos(WIDUsr.ToString(), "0");
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(oCbxGastos.LCBXGastos, "IDGastos", "Gastos");
            oCatGasto.LCBGastos = CbxItems;
            return View(oCatGasto);
        }
        [HttpPost]
        public async Task<ActionResult> ConsCatGas(FormCollection oForm)
        {
            string WIDGas = oForm["HDcbxGas"].ToString();
            if (WIDGas == "") WIDGas = "0";
            CatGastosRes oGastos = new CatGastosRes();
            var WIDUsr = Request.Cookies["IDUsr"].Value;
            var oCbxGastos = await _repository.LLenaGastos(WIDUsr.ToString(), WIDGas);
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(oCbxGastos.LCBXGastos, "IDGastos", "Gastos");
            oGastos.LCBGastos = CbxItems;
            oGastos.Gastos = oCbxGastos.Gastos;
            oGastos.IDGastos = oCbxGastos.IDGastos;
            return View("Index", oGastos);
        }
        [HttpPost]
        public async Task<ActionResult> Guardar(FormCollection oForm)
        {
            CatGastos oCatGastos = new CatGastos();
            oCatGastos.IDGastos = int.Parse(oForm["HDcbxGas"].ToString());
            oCatGastos.Gastos = oForm["txtGas"].ToString();
            oCatGastos.IDUsr = int.Parse(Request.Cookies["IDUsr"].Value);
            var Res = await _repository.Guardar(oCatGastos);
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(Res.LCBXGastos, "IDGastos", "Gastos");
            Res.LCBGastos = CbxItems;
            return RedirectToAction("Index", "CatGasto");
        }
        [HttpPost]
        public async Task<ActionResult> Borrar(FormCollection oForm)
        {
            CatGastos oCatGastos = new CatGastos();
            oCatGastos.IDGastos = int.Parse(oForm["HDcbxGas"].ToString());
            oCatGastos.IDUsr = int.Parse(Request.Cookies["IDUsr"].Value);
            var Res = await _repository.Borrar(oCatGastos);
            Combo cbx = new Combo();
            var CbxItems = await cbx.FNLLenaCombo(Res.LCBXGastos, "IDGastos", "Gastos");
            Res.LCBGastos = CbxItems;
            return RedirectToAction("Index", "CatGasto");
        }
    }
}
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.SPEND.Models
{
    public class CatGastosRes: CatGastos
    {
        public List<CatGastos> LCBXGastos { get; set; }
        public List<SelectListItem> LCBGastos { get; set; }
    }
}
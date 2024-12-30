using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.SPEND.Models
{
    public class ROT
    {
        public string Ruta { get; set; }
        public string Img { get; set; }
        public IEnumerable<ROT> IEnumMenus { get; set; }
        public string NombreUsuario { get; set; }

    }
}
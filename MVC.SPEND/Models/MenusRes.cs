using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.SPEND.Models;
namespace MVC.SPEND.Models
{
    public class MenusRes
    {
        public string mensaje { get; set; }
        public List<ROT> Menus { get; set; }
        public string NombreUsuario { get; set; }

    }
}
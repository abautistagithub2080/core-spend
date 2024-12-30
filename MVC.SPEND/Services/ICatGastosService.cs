using MVC.SPEND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.SPEND.Services
{
    public interface ICatGastosService
    {
        Task<ROT> LLenaMenus(string IDUser);
        Task<CatGastosRes> LLenaGastos(string IDUser, string IDGastos);
        Task<CatGastosRes> Guardar(CatGastos oSpend);
        Task<CatGastosRes> Borrar(CatGastos oSpend);
    }
}

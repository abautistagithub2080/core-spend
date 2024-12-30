using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MVC.SPEND.Models;

namespace MVC.SPEND.Services
{
    public interface IService_API
    {
        Task<int> Validar(string WUser, string WContra);
        Task<ROT> LLenaMenus(string IDUser);
        Task<HttpClient> TfnClientApi();
    }
}

using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using MVC.SPEND.Models;
using System.Text;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace MVC.SPEND.Services
{
    public class Service_API: IService_API
    {
        public async Task<int> Validar(string WUser, string WContra)
        {
            string esUsuarios = "";
            var Client = await TfnClientApi();
            var queryParams = new StringBuilder();
            queryParams.Append("?User="+ WUser);
            queryParams.Append("&Contra="+ WContra); 
            var response = await Client.GetAsync($"api/Spend/Validar{queryParams}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ValidarRes>(json_respuesta);
                esUsuarios = resultado.EsUsuario;
            }
            return int.Parse(esUsuarios);
        }
        public async Task<ROT> LLenaMenus(string IDUser)
        {
            ROT oMenu = new ROT();
            var Client = await TfnClientApi();
            var response = await Client.GetAsync($"api/ROT?IDUser={IDUser}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<MenusRes>(json_respuesta);
                oMenu.IEnumMenus = resultado.Menus;
                oMenu.NombreUsuario = resultado.NombreUsuario;
            }
            return oMenu;
        }
        public async Task<HttpClient> TfnClientApi()
        {
            string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            var Client = new HttpClient();
            Client.BaseAddress = new Uri(baseUrl);
            return Client;
        }
    }
}
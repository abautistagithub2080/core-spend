using MVC.SPEND.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace MVC.SPEND.Services
{
    public class CatGastosService: ICatGastosService
    {
        private IService_API _ServiceAPI;
        public CatGastosService()
        {
            _ServiceAPI = new Service_API();
        }
        public async Task<ROT> LLenaMenus(string IDUser)
        {
            var Client = await _ServiceAPI.TfnClientApi();
            ROT oMenu = new ROT();
            var response = await Client.GetAsync($"/api/ROT/FillMenu/{IDUser}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<MenusRes>(json_respuesta);
                oMenu.IEnumMenus = oRes.Menus;
                oMenu.NombreUsuario = oRes.NombreUsuario;
            }
            return oMenu;
        }
        public async Task<CatGastosRes> LLenaGastos(string IDUser, string IDGastos)
        {
            var Client = await _ServiceAPI.TfnClientApi();
            CatGastosRes oCatGastos = new CatGastosRes();
            var response = await Client.GetAsync($"api/CatGastos/GetCatSpend/{IDUser}/{IDGastos}");
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<CatGastosRes>(json_respuesta);
                oCatGastos.IDGastos = oRes.IDGastos;
                oCatGastos.LCBXGastos = oRes.LCBXGastos;
                oCatGastos.Gastos = oRes.Gastos;
            }
            return oCatGastos;
        }
        public async Task<CatGastosRes> Guardar(CatGastos oSpend)
        {
            var client = await _ServiceAPI.TfnClientApi();
            CatGastosRes oCatGastos = new CatGastosRes();
            var content = new StringContent(JsonConvert.SerializeObject(oSpend), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/CatGastos/Guardar/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<CatGastosRes>(json_respuesta);
                oCatGastos.IDGastos = oRes.IDGastos;
                oCatGastos.LCBXGastos = oRes.LCBXGastos;
                oCatGastos.Gastos = oRes.Gastos;
            }
            return oCatGastos;
        }
        public async Task<CatGastosRes> Borrar(CatGastos oSpend)
        {
            var client = await _ServiceAPI.TfnClientApi();
            CatGastosRes oCatGastos = new CatGastosRes();
            var content = new StringContent(JsonConvert.SerializeObject(oSpend), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/CatGastos/Borrar", content);
            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var oRes = JsonConvert.DeserializeObject<CatGastosRes>(json_respuesta);
                oCatGastos.IDGastos = oRes.IDGastos;
                oCatGastos.LCBXGastos = oRes.LCBXGastos;
                oCatGastos.Gastos = oRes.Gastos;
            }
            return oCatGastos;
        }
    }
}
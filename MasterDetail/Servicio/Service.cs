using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MasterDetail.Servicio
{
    public class Service
    {
        private const string BASE = "https://miturno.azurewebsites.net";

        public static async Task<EmpaqueModel> Login(string path)
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"{BASE}/{path}");
                var json = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<EmpaqueModel>(json);
            }
        }
    }
}

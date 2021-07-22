using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CallApi.Services
{
    class ApiServices
    {
        String _UrlBase = "";
        String token = "";

        public String UrlBase { get => _UrlBase; }

        HttpClient client = new HttpClient();

        public ApiServices(String UrlBase)
        {
            //Capturo la Url pasada
            _UrlBase = UrlBase;
        }

        public ApiServices(String UrlBase, String token)
        {
            //Capturo la Url pasada
            _UrlBase = UrlBase;
        }

        public async Task<HttpResponseMessage> GET(String recurso)
        {

            var uri = new Uri(_UrlBase + recurso);
            HttpResponseMessage response;

            //Realiza la llamada a obtener datos
            try
            {
                response = await client.GetAsync(uri);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<HttpResponseMessage> GET(String recurso, String token)
        {
            client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("BEARER", token);

            var uri = new Uri(_UrlBase + recurso);
            HttpResponseMessage response;

            //Realiza la llamada a obtener datos
            try
            {
                response = await client.GetAsync(uri);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

    }
}

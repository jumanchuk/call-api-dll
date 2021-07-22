using CallApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text; 
using System.Threading.Tasks;
using CallApi.Services;

namespace CallApi
{
    class GestorApi
    {
        public String Get(String Url, String Mascara)
        {
            String result = null;
            ApiServices ss = new ApiServices(Url);

            if (!String.IsNullOrEmpty(Mascara))
            {
                // Obtiene resultado de la consulta
                var response = ss.GET(Mascara).GetAwaiter().GetResult();

                // Si la respuesta es satisfactoria
                if (response.IsSuccessStatusCode)
                {
                    //Lee el contenido de la respuesta
                    var content = response.Content;
                    String responseString = content.ReadAsStringAsync().GetAwaiter().GetResult();

                    result = responseString;
                }
                else
                {
                    throw new Exception("404:" + response.StatusCode.ToString());
                }
            }
            else
            {
                throw new Exception("400: Bad Request");
            }

            return result;
        }

        public String Get(String Url, String Mascara, String token)
        {
            String result = null;
            ApiServices ss = new ApiServices(Url);

            if (!String.IsNullOrEmpty(Mascara) & !String.IsNullOrEmpty(token))
            {
                // Obtiene resultado de la consulta
                var response = ss.GET(Mascara, token).GetAwaiter().GetResult();

                // Si la respuesta es satisfactoria
                if (response.IsSuccessStatusCode)
                {
                    //Lee el contenido de la respuesta
                    var content = response.Content;
                    String responseString = content.ReadAsStringAsync().GetAwaiter().GetResult();

                    result = responseString;
                }
                else
                {
                    throw new Exception("404:" + response.StatusCode.ToString());
                }
            }
            else
            {
                throw new Exception("400: Bad Request");
            }

            return result;
        }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoRest
{
    public static class Service
    {


        public static async Task<ResponseRest> GetService(string url, HttpMethod method , string JWT = "" )
        {
            ResponseRest resp = new ResponseRest();
            try
            {

                HttpClient Client = new HttpClient();
                var request = new HttpRequestMessage(method, url);
                //request.Headers.Add("Accept", "application/json");  
                if (JWT != "")
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",JWT);
                HttpResponseMessage RespRest = await Client.SendAsync(request);
                HttpContent content = RespRest.Content;

                string data = await content.ReadAsStringAsync();

                if(data != null)
                {
                    var datajson = JsonConvert.DeserializeObject<Contactos>(data);
                    resp.Data = datajson.response;
                }
                resp.StatusCode = RespRest.StatusCode.ToString();

            }
            catch (Exception)
            {

                throw;
            }

            return resp;
            
        }




        public static async Task<ResponseRest> PostService<T>(string url, HttpMethod method, T objResquest, string JWT = ""  )
        {
            ResponseRest resp = new ResponseRest();
            try
            {

                HttpClient Client = new HttpClient();


                var Body = JsonConvert.SerializeObject(objResquest);
                var byteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(Body));
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                var request = new HttpRequestMessage(method, url);
                request.Content = byteContent;
                //request.Headers.Add("Accept", "application/json");  
                if (JWT != "")
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", JWT);
                HttpResponseMessage RespRest = await Client.SendAsync(request);
                HttpContent content = RespRest.Content;
                string data = await content.ReadAsStringAsync();
                resp.StatusCode = RespRest.StatusCode.ToString();

            }
            catch (Exception)
            {

                throw;
            }

            return resp;

        }




    }
}

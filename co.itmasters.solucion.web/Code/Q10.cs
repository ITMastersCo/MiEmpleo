using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web;





namespace co.itmasters.solucion.web.Code
{
    public class Q10 : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }
        public dynamic Post(string url, string json, string autorizacion)
        {
            dynamic datos = JsonConvert.DeserializeObject("");
            try
            {
                var client = new RestClient(url);
                var pedido = new RestRequest("", Method.Post);
                pedido.AddHeader("","json");
                pedido.AddParameter("jsAplicactions", json, ParameterType.RequestBody);

                if (autorizacion != "")
                {
                    pedido.AddHeader("Autorization", autorizacion);
                }

                RestResponse respúesta  = client.Execute(pedido);

                return datos;
            }
            catch
            {
                return null;
            }
            
        }
        public dynamic Get(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
            client.DefaultRequestHeaders.Add("Api-Key", "49f3506830ff423aa64a8b28aa43eb55");
            HttpWebRequest miSitio = (HttpWebRequest)WebRequest.Create(url);
            miSitio.UserAgent = "";
            miSitio.Credentials =  CredentialCache.DefaultCredentials;
            miSitio.Proxy = null;
            HttpWebResponse mihttpSitio = (HttpWebResponse)miSitio.GetResponse();
            Stream myEstream = mihttpSitio.GetResponseStream();
            StreamReader myEstreamlectura = new StreamReader(myEstream);
            //leemeo datos
            string Datos = HttpUtility.HtmlDecode(myEstreamlectura.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);

            return data;
        }           
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


    }
}
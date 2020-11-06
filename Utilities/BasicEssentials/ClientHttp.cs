using BasicEssentials.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace BasicEssentials
{
    public class ClientHttp
    {
        public static string GET(string url)
        {
            try
            {
                HttpClient client = new HttpClient {Timeout = TimeSpan.FromSeconds(20)};

                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Timeout = 80000;

                string result = "";

                using WebResponse svcResponse = (HttpWebResponse)request.GetResponse();
                using var sr = new StreamReader(svcResponse.GetResponseStream());
                result = sr.ReadToEnd();

                return result;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                    return new System.IO.StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                else
                    throw e;
            }
        }

        public void GetRestSharp()
        {
            const string limit = "10";
            const string offset = "20";
            
            // string url = $"https://pokeapi.co/api/v2/pokemon?limit=10&offset=20";

            var client = new RestClient("https://pokeapi.co/api/v2");

            var request = new RestRequest("pokemon", Method.GET)
                .AddParameter("limit", limit)
                .AddParameter("offset", offset);
            // request.AddParameter("foo", "bar", RequestType.QueryString); // => ?foo=bar
            var response = client.Execute<ResponsePoke>(request);
            
            var data = response.Data;
            data.results.ForEach(pok=> Console.WriteLine(pok.name));
        }

        public IEnumerable<State> GetSmp()
        {
            // https://raw.githubusercontent.com/juniorricardo/sucursal-bancario/master/src/json/usuarios.json
            // http://localhost:3000/api/v2/smp
            var client = new RestClient("http://localhost:3000/api/smp");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request).Content;
            JObject jFoo = JObject.Parse(response);

            var stateList = new List<State>();

            foreach (JToken child in jFoo.Children())
            {
                foreach (JToken grandChild in child)
                {
                    var elemento = new State();
                    foreach (JToken grandGrandChild in grandChild)
                    {
                        if (grandGrandChild is JProperty property)
                        {
                            switch (property.Name.ToUpper())
                            {
                                case "MAP":
                                    elemento.Map = JsonConvert.DeserializeObject<Map>(property.Value.ToString());
                                    break;
                                case "ITEMS":
                                    elemento.Items =
                                        JsonConvert.DeserializeObject<List<Item>>(property.Value.ToString());
                                    break;
                                case "EXTENSION":
                                    elemento.Extension =
                                        JsonConvert.DeserializeObject<Extension>(property.Value.ToString());
                                    break;
                            }

                            Console.WriteLine(property.Name + ":" + property.Value);
                        }
                    }

                    stateList.Add(elemento);
                }
            }

            return stateList;

        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace BasicEssentials
{
    class ClientHttp
    {
        public static string GET(string url)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.Timeout = TimeSpan.FromSeconds(20);

                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => true;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Timeout = 80000;

                string result = "";

                using (WebResponse svcResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(svcResponse.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }
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
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace Poke.API.Helpers
{
    public class HttpClientHelper
    {
        static HttpClient _clientInstance;
        //public static HttpClient GetHttpClient()
        //{
        //    var MyHttpClient = new HttpClient();
        //    //dynamic _token = HttpContext.Current.Session["token"];
        //    if (_token == null) throw new ArgumentNullException(nameof(_token));
        //    MyHttpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _token.AccessToken));
        //    return MyHttpClient;

        //}
        //public static HttpClient GenerateClient()
        //{
        //    if (_clientInstance == null)
        //    {
        //        _clientInstance.BaseAddress = new Uri("http://0.0.0.0:0000/");
        //        _clientInstance.DefaultRequestHeaders.Accept.Clear();
        //        _clientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        //        _clientInstance.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(string.IsNullOrEmpty(token));
        //    }
        //    return _clientInstance;
        //}
    }
}

﻿using System;
using System.Threading.Tasks;
using RestSharp;

namespace Poke.API.Provider
{
    public class ClientBase : RestSharp.RestClient
    {
        protected ClientBase(string baseUrl) => BaseUrl = new Uri(baseUrl);

        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            var response = base.Execute<T>(request);
            TimeoutCheck(request, response);
            return response;
        }

        public override async Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
        {
            var response = await base.ExecuteTaskAsync(request);
            TimeoutCheck(request, response);
            return response;
        }

        public override async Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
        {
            var response = await base.ExecuteTaskAsync<T>(request);
            TimeoutCheck(request, response);
            return response;
        }

        private void TimeoutCheck(IRestRequest request, IRestResponse response)
        {
            if (response.StatusCode == 0)
            {
                //Uncomment the line below to throw a real exception.
                //throw new TimeoutException("The request timed out!");
            }
        }
    }
}

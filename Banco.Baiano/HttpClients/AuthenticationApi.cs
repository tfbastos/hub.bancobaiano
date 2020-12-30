using Banco.Baiano.Interface;
using Banco.Baiano.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Baiano.HttpClients
{
    public class AuthenticationApi
    {
        public string GetToken(ILogin model)
        {
            var client = new RestClient("https://localhost:4000/api/Token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(model);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}

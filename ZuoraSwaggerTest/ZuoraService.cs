using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZuoraSwaggerTest
{
    public class ZuoraService
    {
        private string username;
        private string password;
        private string serviceURL;

        private AccountsApi accountsAPI;
        private ActionsApi actionsAPI;

        public ZuoraService(string username, string password, string serviceURL)
        {
            this.username = username;
            this.password = password;
            this.serviceURL = serviceURL;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            this.accountsAPI = new AccountsApi(this.serviceURL);
            this.accountsAPI.Configuration.ApiClient.RestClient.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(this.username, this.password);

            this.actionsAPI = new ActionsApi(this.serviceURL);
            this.actionsAPI.Configuration.ApiClient.RestClient.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(this.username, this.password);
        }

        public GETAccountType GetAccount(string id)
        {
            var account = this.accountsAPI.GETAccount(id);
            return account;
        }

        public ProxyActionqueryResponse Query(string queryString)
        {
            ProxyActionqueryRequest request = new ProxyActionqueryRequest(queryString);
            var response = this.actionsAPI.ProxyActionPOSTquery(request);
            return response;
        }
    }
}

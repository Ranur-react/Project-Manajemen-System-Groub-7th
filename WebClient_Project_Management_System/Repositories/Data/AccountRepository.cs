using API.Models;
using API.Models.ViewModel;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebClient_Project_Management_System.Base;

namespace WebClient_Project_Management_System.Repositories.Data
{
    public class AccountRepository :  GeneralRepository<Account, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public AccountRepository(Address address, string request = "Accounts/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };

        }
        public RequestLoginsForms AuthJson(LoginForm login)
        {
            RequestLoginsForms token = new RequestLoginsForms();
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            using (var response = httpClient.PostAsync(address.link + request + "Login", content).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                token = JsonConvert.DeserializeObject<RequestLoginsForms>(apiResponse);
            }

            return token;
        }
        public Object Register(RegisterForm entity)
        {
            Object entities = new Object();
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");


            using (var response = httpClient.PostAsync(address.link + "Accounts/Register", content).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                entities = JsonConvert.DeserializeObject<Object>(apiResponse);
            }

            return entities;


        }
    }
}

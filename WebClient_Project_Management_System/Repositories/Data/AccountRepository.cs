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
    public class AccountRepository : GeneralRepository<Account, string>
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

        public async Task<JWTTokenVM> Auth(LoginVM login)
        {
            JWTTokenVM token = null;

            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(request + "Login", content);

            string apiResponse = await result.Content.ReadAsStringAsync();
            token = JsonConvert.DeserializeObject<JWTTokenVM>(apiResponse);

            return token;
        }


        public RequestLoginsForms AuthJson(LoginVM login)
        {
            RequestLoginsForms token = new RequestLoginsForms();
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            using (var response = httpClient.PostAsync(address.link + request + "Logins", content).Result)
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


            using (var response = httpClient.PostAsync(address.link + "Employees/Register", content).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                entities = JsonConvert.DeserializeObject<Object>(apiResponse);
            }

            return entities;


        }
    }
}

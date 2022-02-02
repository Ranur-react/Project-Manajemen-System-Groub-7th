using API.Models;
using API.Models.FormModel;
using API.Models.ViewModel;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebClient_Project_Management_System.Base;
using WebClient_Project_Management_System.Models;

namespace WebClient_Project_Management_System.Repositories.Data
{
    public class ProjectRepository :  GeneralRepository<Project, String>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public ProjectRepository(Address address, string request = "Projects/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };

        }

        public async Task<Project> GetById(KeyForm entity)
        {
            Project entities = new Project();
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync(address.link + request + "GetById", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<Project>(apiResponse);
            }

            return entities;
        }

        

    }
}

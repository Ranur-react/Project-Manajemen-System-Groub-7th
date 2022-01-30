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
    public class ProgressRepository :  GeneralRepository<Progress, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public ProgressRepository(Address address, string request = "Progresses/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };

        }
        
    }
}

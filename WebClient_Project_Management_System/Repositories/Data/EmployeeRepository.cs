﻿using API.Models;
using API.Models.FormModel;
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
    public class EmployeeRepository :  GeneralRepository<Employee, String>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public EmployeeRepository(Address address, string request = "Employees/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };

        }
        
            public Employee Find(KeyForm entity)
        {
            Employee entitesss = new Employee();
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            using (var response = httpClient.PostAsync(address.link + request + "Find", content).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                entitesss = JsonConvert.DeserializeObject<Employee>(apiResponse);
            }

            return entitesss;
        }

    }
}

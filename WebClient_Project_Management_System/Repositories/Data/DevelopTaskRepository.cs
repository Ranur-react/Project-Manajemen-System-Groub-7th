﻿using API.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient_Project_Management_System.Base;

namespace WebClient_Project_Management_System.Repositories.Data
{
    public class DevelopTaskRepository : GeneralRepository<DevelopTask, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public DevelopTaskRepository(Address address, string request = "DevelopTasks") : base(address, request)
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
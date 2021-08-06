// <copyright file="HomeController.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeamService teamService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            this._logger = logger;
            this.teamService = teamService;
        }

        [HttpPost]
        public int AddTeamMember(string name)
        {
            int index = this.teamService.GetTeamInfo().TeamMembers.Count + 2;
            Member member = new Member(name, index);
            this.teamService.AddTeamMember(member);
            return index;
        }

        [HttpPost]
        public void DeleteTeamMember(int id)
        {
            string name = "";
            foreach (Member m in this.teamService.GetTeamInfo().TeamMembers)
            {
                if (m.Id == id)
                {
                    Member member = new Member(name, id);
                    this.teamService.DeleteTeamMember(member);
                }
            }
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return this.View(this.teamService.GetTeamInfo());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

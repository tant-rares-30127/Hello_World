// <copyright file="Member.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Services;

namespace HelloWorldWeb.Models
{
    public class Member
    {
        private readonly ITimeService timeService;

        public Member(string name, int id, ITimeService timeService)
        {
            this.timeService = timeService;
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public DateTime Birthdate { get; set; }

        public int GetAge()
        {
            var age = this.timeService.Now().Subtract(this.Birthdate).Days;
            age = age / 365;

            return age;
        }
    }
}
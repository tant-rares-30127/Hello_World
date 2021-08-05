// <copyright file="TeamInfo.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace HelloWorldWeb.Models
{
    public class TeamInfo
    {
        public string TeamName { get; set; }

        public List<Member> TeamMembers { get; set; }
    }
}
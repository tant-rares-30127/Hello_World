// <copyright file="TeamInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
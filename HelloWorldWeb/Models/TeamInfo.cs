// <copyright file="TeamInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace HelloWorldWeb.Models
{
    public class TeamInfo
    {
        public TeamInfo(string teamName, List<Member> teamMembers)
        {
            TeamName = teamName;
            TeamMembers = teamMembers;
        }

        public string TeamName { get; set; }

        public List<Member> TeamMembers { get; set; }
    }
}
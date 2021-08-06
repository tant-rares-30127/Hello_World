// <copyright file="TeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo { TeamName = "name", TeamMembers = new List<Member>() { new Member("Gabriel", 1), new Member("Delia", 2), new Member("Rares", 3), new Member("Catalin", 4) } };
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public void AddTeamMember(Member member)
        {
            this.teamInfo.TeamMembers.Add(member);
        }

        void ITeamService.DeleteTeamMember(Member member)
        {
            this.teamInfo.TeamMembers.Remove(member);
        }

        void ITeamService.EditTeamMember(int id, string name)
        {
            this.teamInfo.TeamMembers[id].Name = name;
        }
    }
}
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
        private ITimeService timeService;

        public TeamService()
        {
            this.teamInfo = new TeamInfo("name", new List<Member>()
                {
                    new Member("Gabriel", 1, this.timeService),
                    new Member("Delia", 2, this.timeService),
                    new Member("Rares", 3, this.timeService),
                    new Member("Catalin", 4, this.timeService),
                });
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public void AddTeamMemberAsync(Member member)
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
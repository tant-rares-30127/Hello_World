// <copyright file="TeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWeb.Models;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly IBroadcastServices broadcastService;
        private ITimeService timeService = new TimeService();

        public TeamService(IBroadcastServices broadcastService)
        {
            this.teamInfo = new TeamInfo { TeamName = "name", TeamMembers = new List<Member>() { new Member("Gabriel", 1, this.timeService), new Member("Delia", 2, this.timeService), new Member("Rares", 3, this.timeService), new Member("Catalin", 4, this.timeService) } };
            this.broadcastService = broadcastService;
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public void AddTeamMember(Member member)
        {
            this.teamInfo.TeamMembers.Add(member);
            broadcastService.NewTeamMemberAdded(member.Name, member.Id);
        }

        void ITeamService.DeleteTeamMember(Member member)
        {
            this.teamInfo.TeamMembers.Remove(member);
            this.broadcastService.DeleteTheTeamMember(member.Id);
        }

        void ITeamService.EditTeamMember(int id, string name)
        {
            this.teamInfo.TeamMembers[id - 1].Name = name;
            this.broadcastService.EditTheTeamMember(id, name);
        }
    }
}
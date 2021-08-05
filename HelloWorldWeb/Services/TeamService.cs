using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
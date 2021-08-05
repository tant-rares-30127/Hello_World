using System;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            Member member = new Member("George", 5);
            teamService.AddTeamMember(member);

            // Assert
            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
   
        }
    }
}

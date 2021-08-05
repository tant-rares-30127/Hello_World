using System;
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

            teamService.AddTeamMember("George");

            // Assert
            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
   
        }
    }
}

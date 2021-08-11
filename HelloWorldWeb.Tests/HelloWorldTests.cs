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

        [Fact]
        public void DeleteTeamMemberToTheTeam()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            Member member = new Member("George", 5);
            Member member2 = teamService.GetTeamInfo().TeamMembers[2];
            teamService.AddTeamMember(member);
            teamService.DeleteTeamMember(member);
            teamService.DeleteTeamMember(member2);

            // Assert
            Assert.Equal(3, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void EditTeamMember()
        {
            // Assume

            ITeamService teamService = new TeamService();

            // Act

            teamService.EditTeamMember(4, "NewName");

            // Assert

            Assert.Equal("NewName", teamService.GetTeamInfo().TeamMembers[3].Name);
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);

        }
    }
}

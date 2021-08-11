using System;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class NewTeamServiceTests
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

            teamService.EditTeamMember(3, "NewName");

            // Assert

            Assert.Equal("NewName", teamService.GetTeamInfo().TeamMembers[3].Name);
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);

        }

        [Fact]
        public void CheckIdWhenDeleted()
        {
            // Assume
            ITeamService teamService = new TeamService();
            var teamMember = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMember = new Member("Borys", 5);

            // Act
            teamService.DeleteTeamMember(teamMember);
            teamService.AddTeamMember(newMember);
            teamService.DeleteTeamMember(newMember);

            // Assert
            newMember = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == "Borys");
            Assert.Null(newMember);
        }
    }
}
